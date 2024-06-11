using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHPManager : MonoBehaviour
{
    public Slider hpSlider;

    public static float F2MyHP = 0;//F2�̃v���C���[�̂�������_���[�W�ʂ�Max�l

    [SerializeField] private AudioSource audiobarrier;



    // ���݂̗̑�
    //private int currentHealth;
    public static int currentHealth ;

    // Start is called before the first frame update
    void Start()
    {
        //�����̃_���[�W�ʂ�0�ɐݒ�
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
            //10�_���[�W�H�炤
            TakeDamage(1);
            //�������������u�Ԃɏ���
            Destroy(other.gameObject);
            audiobarrier.Play();
        }
    }

  

    // Update is called once per frame
    void Update()
    {
        F2MyHP = hpSlider.value;
        //HP��0�ɂȂ�ƃQ�[���I�[�o�[��ʂɑJ��
        if (currentHealth <= 0)
        {
            //�J�ڂ���R�[�h������
        }
    }

    //�_���[�W�̊֐�
    public void TakeDamage(int damageAmount)
    {
        currentHealth += damageAmount;
        hpSlider.value = currentHealth;
    }
}
