using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// EnemyGetHitクラスの定義
public class EnemyGetHit : MonoBehaviour
{
    // AudioSource型の変数を宣言
    [SerializeField] private AudioSource audiobarrier; 

    // 敵が被るヒット数
    public int hitCount;
    public GameObject HitEffect;
    // HitCounterクラスのインスタンス
    private HitCounter hitCounter;

    //ゴーレムの被弾アニメーション用の変数
    private GameObject golemObj;
    private Animator Animator;

    // Startメソッドは最初のフレームの直前に呼び出される
    void Start()
    {
        // "HitLabelPro"という名前のオブジェクトからHitCounterコンポーネントを取得してhitCounterに代入
        hitCounter = GameObject.Find("HitLabelPro").GetComponent<HitCounter>();

        //ゴーレムのオブジェクトからAnimatorコンポーネントを取得
        golemObj = GameObject.Find("golem_armorture");
        Animator = golemObj.GetComponent<Animator>();
    }

    // 他のコライダーとの衝突を検出する
    private void OnTriggerEnter(Collider collision)
    {
        // 衝突したオブジェクトのタグが"target"である場合
        if (collision.gameObject.tag == "target")
        {
            // HitCounterクラスのAddCountメソッドを呼び出し、hitCountを渡す
            hitCounter.AddCount(hitCount);

            // 衝突したオブジェクトを削除する
            Destroy(collision.gameObject);

            // オブジェクトの爆発エフェクトを生成
            GameObject explosion = Instantiate(HitEffect, collision.ClosestPoint(this.transform.position), Quaternion.identity);

            // 1秒後に爆発エフェクトを削除
            Destroy(explosion, 1f);

            // AudioSource型が入っている変数audioPunchを再生
            audiobarrier.Play();

            // ゴーレムの被弾モーションを描画
            Animator.SetTrigger("SmallDamage");
        }
    }

    
}
