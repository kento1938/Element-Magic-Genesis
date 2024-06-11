using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHPManager : MonoBehaviour
{
    private float startTime;//�J�n����
    public static float F3Time;//�V�[�����ς��܂ł̎���

    public static bool SceneFlag = false;

    public Slider hpSlider;

    // �G�̍ő�̗�
    public int maxHealth = 100;

    // ���݂̗̑�
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        //�G�̍ő�̗͂�ݒ�iSlider��Max Value�Ɠ����l�ɂ���j
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
            //10�_���[�W�H�炤
            TakeDamage(10);
            //�������������u�Ԃɏ���
            Destroy(other.gameObject);
            Debug.Log(currentHealth);
        }
    }
    // Update is called once per frame
    void Update()
    {

        /*if (currentHealth <= 0)
        {
            //1��ڂ̃A�^�b�N�t�F�[�Y
            if (SceneFlag == false)
            {
                //HP��0�ɂȂ�ƓG�I�u�W�F�N�g������
                SceneFlag = true;
                SceneManager.LoadScene("F2_Diffence1");
                
            }
            else //�Q��ڂ̃A�^�b�N�t�F�[�Y
            {
                SceneManager.LoadScene("F4_Diffence2");
            }
        }*/

        if (currentHealth <= 0)
        {
            float endTime = Time.time;//�V�[���ω����̎��Ԃ��L�^
            F3Time = endTime - startTime;//�o�ߎ��Ԃ��v�Z

            SceneManager.LoadScene("F4_Diffence2");
                
        }

        //HP��0�ɂȂ�ƓG�I�u�W�F�N�g������
        /*if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }*/
    }

    //�_���[�W�̊֐�
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        hpSlider.value = currentHealth;
    }
}
