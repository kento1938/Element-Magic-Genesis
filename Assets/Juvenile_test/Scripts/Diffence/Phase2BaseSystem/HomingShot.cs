//プレイヤーとの当たり判定の追加（一番下）
//TAG:MainCameraはオブジェクトMainCameraについている

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HomingShot : MonoBehaviour
{
    public GameObject shellPrefab;
    public Transform player; // プレイヤーの位置
    public float period = 5f; // 周期（秒）
    public float amplitudeZ = 18f; // x軸方向の振幅
    public float amplitudeX = 5f; // z軸方向の振幅

    private int count;

    void Update()
    {
        count += 1;

        // ６０フレームごとに砲弾を発射する
        if (count % 120 == 0)
        {
            GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity);
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();

            // 弾速
            shellRb.AddForce(transform.forward * 500);

            // 弾の制御に楕円状の移動を行う
            
            StartCoroutine(MoveShell(shell));

            // ５秒後に砲弾を破壊する
            //Destroy(shell, 8.0f);
        }
    }

    IEnumerator MoveShell(GameObject shell)
    {
        float timeElapsed = 0f;

        // プレイヤーと発射位置の中点を計算
        Vector3 center = (transform.position + player.position) / 2f;

        // 周期をamplitudeXに応じて動的に計算
        period = Mathf.Lerp(2f, 30f, amplitudeX / 100f); // amplitudeXの値によって、周期を2から30の範囲で調整

        // ランダムなamplitudeZを生成
        float randomAmplitudeX = Random.Range(-20f, 20f);

        while (timeElapsed < 8.0f) // 5秒間移動させる（破壊時刻と同じ）
        {
            // 楕円の x 座標を計算
            float z = center.z + Mathf.Cos(2f * Mathf.PI * timeElapsed / period) * amplitudeZ;
            float distanceY = transform.position.y - player.position.y; // 砲台とプレイヤーのy座標の差を計算

            // 比例的にy座標を減少させる
            //float y = y = player.position.y + distanceY * (1 - timeElapsed / (period / 2));

            // 楕円の y 座標を計算
            float y = player.position.y + (transform.position.y - player.position.y) * Mathf.Exp(-timeElapsed * 1f);
            // 楕円の z 座標を計算
            float x = center.x + Mathf.Sin(2f * Mathf.PI * timeElapsed / period) * randomAmplitudeX;

            Vector3 position = new Vector3(x, y, z);
            shell.transform.position = position;

            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }
}
