using UnityEngine;

public class EMG_Y : MonoBehaviour
{
    // 目標のY座標
    public float targetY = 10f;

    // オブジェクトの速度
    public float speed = 5f;
    public emg_accept otherScript;

    void Start()
    {
        
    }

    void Update()
    {
        otherScript.ThreadMethod();
        
        // 目標のY座標に向かってオブジェクトを移動
        MoveToTargetY();
    }

    void MoveToTargetY()
    {
        // 目標の座標を作成
        Vector3 targetPosition = new Vector3(transform.position.x, targetY, transform.position.z);

        // 目標の座標までの方向ベクトルを計算
        Vector3 direction = (targetPosition - transform.position).normalized;

        // 目標の座標に向かって移動
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
