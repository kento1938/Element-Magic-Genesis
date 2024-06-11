//https://xn--sckyeodz49lj8c.com/unity%E3%81%A7%E3%83%9B%E3%83%BC%E3%83%9F%E3%83%B3%E3%82%B0%E5%BC%BE%E3%82%92%E4%BD%9C%E3%81%A3%E3%81%A6%E3%81%BF%E3%82%8B/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // 弾が追跡する対象のTransform
    private Transform target;

    // 弾の生存時間
    public float time = 1;

    // 加速度の制限をするかどうか
    public bool limitAcceleration = false;

    // 加速度の最大値
    public float maxAcceleration = 100;

    // 初期速度の最小値と最大値
    public Vector3 minInitVelocity;
    public Vector3 maxInitVelocity;

    // 弾の位置、速度、加速度、自身のTransform
    private Vector3 position;
    private Vector3 velocity;
    private Vector3 acceleration;
    private Transform thisTransform;

    // 初期化処理
    void Start()
    {
        // Playerという名前のゲームオブジェクトを検索し、そのTransformをtargetに設定
        target = GameObject.Find("Main Camera").transform;

        // 自身のTransformをthisTransformに設定
        thisTransform = transform;

        // 弾の初期位置を取得
        position = thisTransform.position;

        // 初期速度をランダムに設定
        velocity = new Vector3(Random.Range(minInitVelocity.x, maxInitVelocity.x), Random.Range(minInitVelocity.y, maxInitVelocity.y), Random.Range(minInitVelocity.z, maxInitVelocity.z));
    }

    // 更新処理
    void Update()
    {
        // もし対象が存在しない場合は処理を終了
        if (target == null)
        {
            return;
        }

        // 弾の加速度を計算
        acceleration = 2f / (time * time) * (target.position - position - time * velocity);

        // 加速度の制限が有効で、加速度の大きさが最大値を超えている場合は、加速度を最大値に制限する
        if (limitAcceleration && acceleration.sqrMagnitude > maxAcceleration * maxAcceleration)
        {
            acceleration = acceleration.normalized * maxAcceleration;
        }

        // 残り生存時間を減少させる
        time -= Time.deltaTime;

        // 残り生存時間が0以下ならば処理を終了
        if (time < 0f)
        {
            return;
        }

        // 速度に加速度を加算し、位置を更新する
        velocity += acceleration * Time.deltaTime;
        position += velocity * Time.deltaTime;

        // 弾の位置を更新
        thisTransform.position = position;

        // 弾の向きを速度に合わせて更新
        thisTransform.rotation = Quaternion.LookRotation(velocity);
    }
}

