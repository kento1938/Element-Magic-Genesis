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
        //�G�̍ő�̗͂�ݒ�iSlider��Max Value�Ɠ����l�ɂ���j
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
            //10�_���[�W�H�炤
            TakeDamage(10);
            //�������������u�Ԃɏ���
            Destroy(other.gameObject);
            Debug.Log("�����10�_���[�W�^�����I");
        }
    }
    // Update is called once per frame
    void Update()
    {

        //HP��0�ɂȂ�ƓG�I�u�W�F�N�g������
        if (hpSlider.value <= 0)
        {
            SceneManager.LoadScene("F6_Result");
        }



        //HP��0�ɂȂ�ƓG�I�u�W�F�N�g������
        if (hpSlider.value <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    //�_���[�W�̊֐�
    public void TakeDamage(float damageAmount)
    {
        hpSlider.value -= damageAmount;
    }
}
