using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHPManager : MonoBehaviour
{
    private float startTime;//開始時間
    public static float F3Time;//シーンが変わるまでの時間

    public static bool SceneFlag = false;

    public Slider hpSlider;

    // 敵の最大体力
    public int maxHealth = 100;

    // 現在の体力
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        //敵の最大体力を設定（SliderのMax Valueと同じ値にする）
        hpSlider.value = 100;
        currentHealth = maxHealth;
    }

    public float GetValue()
    {
        return hpSlider.value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "strong_PB" || other.gameObject.tag == "weak_PB")
        {
            //10ダメージ食らう
            TakeDamage(10);
            //球があたった瞬間に消滅
            Destroy(other.gameObject);
            Debug.Log(currentHealth);
        }
    }
    // Update is called once per frame
    void Update()
    {

        /*if (currentHealth <= 0)
        {
            //1回目のアタックフェーズ
            if (SceneFlag == false)
            {
                //HPが0になると敵オブジェクトが消滅
                SceneFlag = true;
                SceneManager.LoadScene("F2_Diffence1");
                
            }
            else //２回目のアタックフェーズ
            {
                SceneManager.LoadScene("F4_Diffence2");
            }
        }*/

        if (currentHealth <= 0)
        {
            float endTime = Time.time;//シーン変化時の時間を記録
            F3Time = endTime - startTime;//経過時間を計算

            SceneManager.LoadScene("F4_Diffence2");
                
        }

        //HPが0になると敵オブジェクトが消滅
        /*if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }*/
    }

    //ダメージの関数
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        hpSlider.value = currentHealth;
    }
}
