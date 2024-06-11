//敵から弾をうつ：https://mono-pro.net/archives/7734

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class EnemyShot : MonoBehaviour
{
    public GameObject shellPrefab;

    private int count;
 
    void Update()
    {
        count += 1;
 
        // ６０フレームごとに砲弾を発射する
        if(count % 60 == 0)
        {
            GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity);
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();
 
            // 弾速
            shellRb.AddForce(transform.forward * 500);
 
            // ５秒後に砲弾を破壊する
            Destroy(shell, 5.0f);
        }
    }
}
