using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class HD_EnemyHPSystemA1 : MonoBehaviour
{
    [SerializeField] private AudioSource audiobarrier; // AudioSource型の変数

    private float startTime; // 開始時間
    bool isAnimationPlayed = false;//animationFlag


    public GameObject HitEffectStrong; // 強攻撃のエフェクト
    public GameObject HitEffectWeak; // 弱攻撃のエフェクト
    public static float F1Time; // シーンが変わるまでの時間
    public float StrongDamage = 20; // 強攻撃のダメージ量
    public float WeakDamage = 20; // 弱攻撃のダメージ量
    public Slider hpSlider; // 体力を表示するスライダー
    public RawImage rawImage;
    public Animator rawImageAnimator;
    private float step_time;    // 経過時間カウント用
    public float set_time = 20; //制限時間


    /* private GameObject golemObj;
     private Animator Animator;*/

    void Start()
    {
        step_time = 0.0f;
        startTime = Time.time; // 開始時間を記録
        hpSlider.value = 100; // 体力スライダーの値を最大値に設定
        rawImage.gameObject.SetActive(false);

        /*golemObj = GameObject.Find("golem_armorture");
        Animator = golemObj.GetComponent<Animator>();*/
    }

    public float GetValue()
    {
        return hpSlider.value; // 体力の現在値を取得
    }

    // 他のコライダーとの衝突を検出する
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "strong_PB")
        {
            // 強攻撃を受けた場合
            TakeDamage(StrongDamage); // ダメージを受ける
            Destroy(collision.gameObject); // 衝突したオブジェクトを破壊

            // 爆発エフェクトを生成して1秒後に破壊
            GameObject explosion = Instantiate(HitEffectStrong, collision.ClosestPoint(this.transform.position), Quaternion.identity);
            Destroy(explosion, 1f);

            // ゴーレムの被弾モーションを描画
            //Animator.SetTrigger("SmallDamage");

            audiobarrier.Play(); // AudioSourceを再生
        }
        else if (collision.gameObject.tag == "weak_PB")
        {
            // 弱攻撃を受けた場合
            TakeDamage(WeakDamage); // ダメージを受ける
            Destroy(collision.gameObject); // 衝突したオブジェクトを破壊

            // 爆発エフェクトを生成して1秒後に破壊
            GameObject explosion = Instantiate(HitEffectWeak, collision.ClosestPoint(this.transform.position), Quaternion.identity);
            Destroy(explosion, 1f);

            // ゴーレムの被弾モーションを描画
            //Animator.SetTrigger("SmallDamage");

            audiobarrier.Play(); // AudioSourceを再生
        }
    }

    void Update()
    {
        step_time += Time.deltaTime;
        // 体力が0以下になったらシーンを切り替える
        if (hpSlider.value <= 0)
        {
            rawImage.gameObject.SetActive(true);
            float endTime = Time.time; // シーン変化時の時間を記録
            F1Time = endTime - startTime; // 経過時間を計算
            hpSlider.value = 0; // 体力スライダーの値を0に設定
            isAnimationPlayed = true;
            StartCoroutine(PlayAnimationWait());
            //SceneManager.LoadScene("F2_Diffence1Test"); // 次のシーンを読み込む
        }
        else if (step_time >= set_time)
        {
            rawImage.gameObject.SetActive(true);
            float endTime = Time.time; // シーン変化時の時間を記録
            F1Time = endTime - startTime; // 経過時間を計算
            //hpSlider.value = 0; // 体力スライダーの値を0に設定
            isAnimationPlayed = true;
            StartCoroutine(PlayAnimationWait());
        }
    }

    // ダメージを受ける関数
    public void TakeDamage(float damageAmount)
    {
        hpSlider.value -= damageAmount; // 体力を減少させる
    }

    IEnumerator PlayAnimationWait()
    {
        rawImageAnimator.SetTrigger("PlayAnimation");
        isAnimationPlayed = false;

        yield return new WaitForSeconds(rawImageAnimator.GetCurrentAnimatorStateInfo(0).length);
        SceneManager.LoadScene("Hard_2_Diffence"); // 次のシーンを読み込む

    }
}
