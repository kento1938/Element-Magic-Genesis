using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EnemyHPSystemA2 : MonoBehaviour
{
    private float startTime;//開始時間
    public static float F3Time;//シーンが変わるまでの時間

    //public VideoPlayer videoPlayer;

    public float StrongDamage = 20;
    public float WeakDamage = 20;

    public Slider hpSlider;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        //敵の最大体力を設定（SliderのMax Valueと同じ値にする）
        hpSlider.value = 100;
        //videoPlayer.loopPointReached += OnVideoFinished;
    }

    public float GetValue()
    {
        return hpSlider.value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "strong_PB")
        {
            //10ダメージ食らう
            TakeDamage(StrongDamage);
            //球があたった瞬間に消滅
            Destroy(other.gameObject);
            Debug.Log("相手に強ダメージ与えた！");
        }
        else if (other.gameObject.tag == "weak_PB")
        {
            //10ダメージ食らう
            TakeDamage(WeakDamage);
            //球があたった瞬間に消滅
            Destroy(other.gameObject);
            Debug.Log("相手に弱ダメージ与えた！");
        }
    }
    // Update is called once per frame
    void Update()
    {

        //HPが0になると敵オブジェクトが消滅
        if (hpSlider.value <= 0)
        {
            /*if (!videoPlayer.isPlaying)
            {
                videoPlayer.Play();
                hpSlider.value = 0;
            }*/
            hpSlider.value = 0;
            float endTime = Time.time;//シーン変化時の時間を記録
            F3Time = endTime - startTime;//経過時間を計算

            SceneManager.LoadScene("F4_Diffence2");
        }

        //HPが0になると敵オブジェクトが消滅
        //if (hpSlider.value <= 0)
        //{
        //  Destroy(this.gameObject);
        //}
    }

    /*void OnVideoFinished(VideoPlayer player)
    {
        //SceneManager.LoadScene("F4_Diffence2");
    }*/

    //ダメージの関数
    public void TakeDamage(float damageAmount)
    {
        hpSlider.value -= damageAmount;
    }
}
