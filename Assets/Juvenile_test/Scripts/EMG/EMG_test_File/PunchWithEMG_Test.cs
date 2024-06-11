using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PunchWithEMG_Test : MonoBehaviour
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

    private bool canTrigger = true; // トリガーが可能かどうかのフラグ
    private float EMG_data; // 筋電のデータ

    //---------------------------------------------
    private EMG_Attack EMG_Attack;

    public float Border = 30f; // 強攻撃と弱攻撃を区別する境界値
    GameObject objectToLaunchPrefab; // EMGデータに基づいて選択された攻撃のプレハブ
    GameObject MuzzlePrefab; // EMGデータに基づいて選択された発射時エフェクトのプレハブ

    void Update()
    {
        EMG_data = emg_move.emg; // EMGデータを更新
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

                // コントローラーの前方に向けて発射する方向を取得
                Vector3 launchDirection = controllerObject.transform.forward;

                if (EMG_Attack.Flag_Attack())
                {
                    objectToLaunchPrefab = objectToLaunchPrefabStrong; // 強攻撃のプレハブを選択
                    MuzzlePrefab = MuzzlePrefab2; // 強攻撃の発射時エフェクトのプレハブを選択     
                    Debug.Log("aaaaa");
                }
                else
                {
                    objectToLaunchPrefab = objectToLaunchPrefabWeak; // 弱攻撃のプレハブを選択
                    MuzzlePrefab = MuzzlePrefab1; // 弱攻撃の発射時エフェクトのプレハブを選択
                }
                /*else
                {
                    objectToLaunchPrefab = objectToLaunchPrefab3; // Y座標が0の場合のプレハブを選択
                    MuzzlePrefab = MuzzlePrefab3;
                }
                */

                // 発射するオブジェクトのインスタンスを生成
                GameObject objectToLaunch = Instantiate(objectToLaunchPrefab, controllerPosition, controllerRotation);
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
