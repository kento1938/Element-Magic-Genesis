using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHPManager : MonoBehaviour
{
    public Slider hpSlider;

    public static float F2MyHP = 0;//F2のプレイヤーのくらったダメージ量のMax値

    [SerializeField] private AudioSource audiobarrier;



    // 現在の体力
    //private int currentHealth;
    public static int currentHealth ;

    // Start is called before the first frame update
    void Start()
    {
        //初期のダメージ量は0に設定
        hpSlider.value = F2MyHP;
        
    }

    public float GetValue()
    {
        return hpSlider.value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "weak_EB" || other.gameObject.tag == "strong_EB")
        {
            //10ダメージ食らう
            TakeDamage(1);
            //球があたった瞬間に消滅
            Destroy(other.gameObject);
            audiobarrier.Play();
        }
    }

  

    // Update is called once per frame
    void Update()
    {
        F2MyHP = hpSlider.value;
        //HPが0になるとゲームオーバー画面に遷移
        if (currentHealth <= 0)
        {
            //遷移するコードを書く
        }
    }

    //ダメージの関数
    public void TakeDamage(int damageAmount)
    {
        currentHealth += damageAmount;
        hpSlider.value = currentHealth;
    }
}
