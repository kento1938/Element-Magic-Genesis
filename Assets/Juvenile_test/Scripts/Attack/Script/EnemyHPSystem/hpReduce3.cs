using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class hpReduce3 : MonoBehaviour
{
    public Slider hpSlider;
    // Start is called before the first frame update
    void Start()
    {
        //敵の最大体力を設定（SliderのMax Valueと同じ値にする）
        hpSlider.value = 100;
    }

    public float GetValue()
    {
        return hpSlider.value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "target")
        {
            //10ダメージ食らう
            TakeDamage(10);
            //球があたった瞬間に消滅
            Destroy(other.gameObject);
            Debug.Log("相手に10ダメージ与えた！");
        }
    }
    // Update is called once per frame
    void Update()
    {

        //HPが0になると敵オブジェクトが消滅
        if (hpSlider.value <= 0)
        {
            SceneManager.LoadScene("F6_Result");
        }



        //HPが0になると敵オブジェクトが消滅
        if (hpSlider.value <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    //ダメージの関数
    public void TakeDamage(float damageAmount)
    {
        hpSlider.value -= damageAmount;
    }
}
