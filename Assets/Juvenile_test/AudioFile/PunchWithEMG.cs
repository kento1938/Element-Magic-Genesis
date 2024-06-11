using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class PunchWithEMG : MonoBehaviour
{
    [Header("Internal References")]
    [SerializeField] GameObject controllerObject; // コントローラーオブジェクトへの参照
    [SerializeField] GameObject objectToLaunchPrefabWeak; // 弱攻撃を発射するオブジェクトのプレハブ
    [SerializeField] GameObject objectToLaunchPrefabStrong; // 強攻撃を発射するオブジェクトのプレハブ
    [SerializeField] GameObject objectToLaunchPrefab3; // 発射するオブジェクトのプレハブ3への参照
    [SerializeField] GameObject MuzzlePrefab1; // 弱攻撃の発射時エフェクトのプレハブ
    [SerializeField] GameObject MuzzlePrefab2; // 強攻撃の発射時エフェクトのプレハブ
    [SerializeField] GameObject MuzzlePrefab3; // 発射するオブジェクトのプレハブ3への参照
    [SerializeField] private AudioSource audioPunch; // パンチ音を再生するためのオーディオソース

    [Header("Launch Parameters")]
    [SerializeField] float launchForce = 100f; // パンチの発射力

    [Header("Haptics Parameters")]
    [SerializeField] float amplitude = 0.5f; // 触覚振幅
    [SerializeField] float duration = 0.5f; // 触覚持続時間
    [SerializeField] float cooldownTime = 0.5f; // トリガーのクールダウン時間

    //[SerializeField] private EMG_Attack emg_attack;

    private bool canTrigger = true; // トリガーが可能かどうかのフラグ
    private float EMG_data; // 筋電のデータ

    public float Border = 30f; // 強攻撃と弱攻撃を区別する境界値
    GameObject objectToLaunchPrefab; // EMGデータに基づいて選択された攻撃のプレハブ
    GameObject MuzzlePrefab; // EMGデータに基づいて選択された発射時エフェクトのプレハブ

    private bool attack_flag;

    //発射方向の調節
    public float DirectionRightSetUpX;
    public float DirectionLeftSetUpX;
    public float DirectionSetUpRightY;
    public float DirectionSetUpLeftY;
    

    void Update()
    {
        EMG_data = emg_move.emg; // EMGデータを更新
        attack_flag = EMG_Attack.flag_attack;
        DirectionRightSetUpX = DirectionSetup.RightrotationalphaX;
        DirectionLeftSetUpX = DirectionSetup.LeftrotationalphaX;
        DirectionSetUpRightY = DirectionSetup.RightrotationalphaY;
        DirectionSetUpLeftY = DirectionSetup.RightrotationalphaY;
    }

    // 他のコライダーに接触したときの処理
    private void OnTriggerEnter(Collider other)
    {
        // トリガーが有効な場合
        if (canTrigger)
        {
            // 特定のタグを持つトリガーコライダーと衝突した場合
            if (other.CompareTag("Line") && other.isTrigger)
            {
                StartCoroutine(TriggerCooldown()); // トリガーのクールダウンを開始
                audioPunch.Play(); // パンチ音を再生

                // コントローラーの位置と回転を取得
                Vector3 controllerPosition = controllerObject.transform.position;
                Quaternion controllerRotation = controllerObject.transform.rotation;
                Quaternion newRotation = Quaternion.Euler(controllerRotation.eulerAngles.x , controllerRotation.eulerAngles.y , controllerRotation.eulerAngles.z);

                // オブジェクトのタグが "Right" かどうかを確認する
                if (controllerObject.tag == "Right")
                {
                    // タグが "Right" の場合の処理
                    // 右手コントローラーのY軸の回転を追加する
                    newRotation = Quaternion.Euler(controllerRotation.eulerAngles.x * DirectionRightSetUpX, controllerRotation.eulerAngles.y * DirectionSetUpRightY, controllerRotation.eulerAngles.z);
                }

                // オブジェクトのタグが "Left" かどうかを確認する
                if (controllerObject.tag == "Left")
                {
                    // タグが "Left" の場合の処理
                    // 左手コントローラーのY軸の回転を追加する
                    newRotation = Quaternion.Euler(controllerRotation.eulerAngles.x + DirectionLeftSetUpX, controllerRotation.eulerAngles.y + DirectionSetUpLeftY, controllerRotation.eulerAngles.z);
                }

                // コントローラーの前方に向けて発射する方向を取得
                Vector3 launchDirection = controllerObject.transform.forward;

                if (attack_flag==false)
                {
                    objectToLaunchPrefab = objectToLaunchPrefabWeak; // 弱攻撃のプレハブを選択
                    MuzzlePrefab = MuzzlePrefab1; // 弱攻撃の発射時エフェクトのプレハブを選択             
                }
                else if (attack_flag==true)
                {
                    objectToLaunchPrefab = objectToLaunchPrefabStrong; // 強攻撃のプレハブを選択
                    MuzzlePrefab = MuzzlePrefab2; // 強攻撃の発射時エフェクトのプレハブを選択                  
                }
                else
                {
                    objectToLaunchPrefab = objectToLaunchPrefab3; // Y座標が0の場合のプレハブを選択
                    MuzzlePrefab = MuzzlePrefab3;
                }

                // 発射するオブジェクトのインスタンスを生成
                GameObject objectToLaunch = Instantiate(objectToLaunchPrefab, controllerPosition, newRotation);
                GameObject Muzzle = Instantiate(MuzzlePrefab, controllerPosition, controllerRotation);

                // 発射するオブジェクトに力を加えて前方に飛ばす
                Rigidbody objectRigidbody = objectToLaunch.GetComponent<Rigidbody>();
                objectRigidbody.AddForce(launchDirection * launchForce, ForceMode.Impulse);

                TriggerHaptics(); // 触覚フィードバックをトリガーする
            }
        }
    }

    // 触覚フィードバックをトリガーするメソッド
    private void TriggerHaptics()
    {
        controllerObject.GetComponent<XRBaseController>().SendHapticImpulse(amplitude, duration);
    }

    // トリガーのクールダウンを管理するコルーチン
    private IEnumerator TriggerCooldown()
    {
        canTrigger = false; // トリガーを無効にする
        yield return new WaitForSeconds(cooldownTime); // クールダウン時間
        canTrigger = true; // トリガーを再び有効にする
    }
}
