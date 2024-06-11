using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public GameObject PrefabTarget;

    // 衝突時に呼び出されるメソッド
    private void OnCollisionEnter(Collision collision)
    {
        // このスクリプトがアタッチされているオブジェクトを破壊
        Destroy(gameObject);

        //ランダムな位置に生成
        /*float x = Random.Range(-4.0f, 4.0f);
        float y = Random.Range(0.0f, 10.0f);
        Vector3 pos = new Vector3(x, y, 6.0f);

        Instantiate(PrefabTarget, pos, Quaternion.identity);*/
    }

    // トリガー衝突時に呼び出されるメソッド
    private void OnTriggerEnter(Collider other)
    {
        // このスクリプトがアタッチされているオブジェクトを破壊
        Destroy(gameObject);

        //ランダムな位置に生成
        /*float x = Random.Range(-4.0f, 4.0f);
        float y = Random.Range(0.0f, 10.0f);
        Vector3 pos = new Vector3(x, y, 6.0f);

        Instantiate(PrefabTarget, pos, Quaternion.identity);*/
    }
}
