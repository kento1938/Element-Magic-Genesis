using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left_effect : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource audiobarrier; // AudioSource型の変数を宣言

    // ゲームオブジェクトのプレハブを指定するための変数
    [SerializeField] public GameObject explosionPrefab;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "weak_EB")
        {
            // 衝突したオブジェクトを削除する
            Destroy(collision.gameObject);

            // オブジェクトの爆発エフェクトを生成
            GameObject explosion = Instantiate(explosionPrefab, collision.ClosestPoint(this.transform.position), Quaternion.identity);

            // 1秒後に爆発エフェクトを削除
            Destroy(explosion, 1f);

            // AudioSource型が入っている変数audioPunchを再生
            audiobarrier.Play();

        }
    }
}
