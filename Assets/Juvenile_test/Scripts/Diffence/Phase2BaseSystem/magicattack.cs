using UnityEngine;

public class magicattack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject magicCirclePrefab; // 魔法陣のプレハブ
    public float bulletSpeed = 10f;
    public float fireRate = 1f; // 1秒ごとに打つ
    public float fixedHeight = 1f; // EnemyShotの高さ
    public float minDistanceFromPlayer = 10f; // プレイヤーからの最小距離
    public float maxDistanceFromPlayer = 20f; // プレイヤーからの最大距離
    public float bulletLifetime = 5f; // 弾の生存時間
    public float magicCircleLifetime = 3f; // 魔法陣の生存時間
    public float magicCircleScale = 2f; // 魔法陣の大きさの倍率
    public float randomAngleRange = 180f; // プレイヤーの周囲の角度

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("Shoot", 0f, fireRate);
    }

    void Shoot()
    {
        // プレイヤーの座標を取得
        Vector3 playerPosition = player.position;

        // プレイヤーとEnemyShotの距離を一定に保つ
        float distance = Random.Range(minDistanceFromPlayer, maxDistanceFromPlayer);

        // プレイヤーを中心とした半円上の点をランダムに選択
        float randomAngle = Random.Range(0f, randomAngleRange) * Mathf.Deg2Rad;
        Vector3 randomPoint = new Vector3(Mathf.Cos(randomAngle), 0f, Mathf.Sin(randomAngle)) * distance + playerPosition;

        // 高さを調整
        randomPoint.y = fixedHeight;

        // プレイヤーの方向に弾を発射
        GameObject bullet = Instantiate(bulletPrefab, randomPoint, Quaternion.identity);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        if (bulletRigidbody != null)
        {
            Vector3 bulletDirection = (playerPosition - randomPoint).normalized;
            bulletRigidbody.velocity = bulletDirection * bulletSpeed;
        }

        // 魔法陣のプレハブを生成
        GameObject magicCircle = Instantiate(magicCirclePrefab, randomPoint, Quaternion.identity);
        // 魔法陣の大きさを変更
        magicCircle.transform.localScale *= magicCircleScale;
        // 魔法陣が打つ方向を向く
        magicCircle.transform.forward = (playerPosition - randomPoint).normalized;
        // さらに90度回転させる
        magicCircle.transform.Rotate(90, 0, 0);
        // 一定時間後に魔法陣を削除
        Destroy(magicCircle, magicCircleLifetime);

        // 一定時間後に弾を削除
        Destroy(bullet, bulletLifetime);
    }
}
