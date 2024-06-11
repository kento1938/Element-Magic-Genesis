//https://xn--sckyeodz49lj8c.com/unity%E3%81%A7%E3%83%9B%E3%83%BC%E3%83%9F%E3%83%B3%E3%82%B0%E5%BC%BE%E3%82%92%E4%BD%9C%E3%81%A3%E3%81%A6%E3%81%BF%E3%82%8B/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    // 弾のプレハブ
    public GameObject Bullet;

    // 弾を生成する回数
    public int iterationCount;

    // 弾を生成する間隔
    public float interval = 0.1f;

    // 弾を生成する間隔を待つためのオブジェクト
    private WaitForSeconds intervalWait;

    // 弾が生成されてから消滅するまでの時間
    private float destroyTime = 0;

    // 初期化処理
    void Start()
    {
        // 弾の生成間隔を設定
        intervalWait = new WaitForSeconds(interval);

        // 弾の生成を開始する
        StartCoroutine("BulletSpawn");
    }

    // 更新処理
    void Update()
    {
        // 消滅までの時間を更新
        destroyTime += Time.deltaTime;

        // 一定時間が経過したら自身を破棄する
        if (destroyTime > 6.0f)
        {
            //Destroy(this.gameObject);
        }
    }

    // 弾の生成コルーチン
    IEnumerator BulletSpawn()
    {
        // 指定された回数だけ弾を生成する
        for (int i = 0; i < iterationCount; i++)
        {
            // 指定された間隔だけ待機する
            yield return intervalWait;

            // 弾を生成し、生成位置と回転を設定する
            Instantiate(Bullet, transform.position, Quaternion.identity).GetComponent<BulletController>();
        }
    }
}

