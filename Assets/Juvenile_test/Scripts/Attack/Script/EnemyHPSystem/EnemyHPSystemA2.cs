using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EnemyHPSystemA2 : MonoBehaviour
{
    private float startTime;//�J�n����
    public static float F3Time;//�V�[�����ς��܂ł̎���

    //public VideoPlayer videoPlayer;

    public float StrongDamage = 20;
    public float WeakDamage = 20;

    public Slider hpSlider;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        //�G�̍ő�̗͂�ݒ�iSlider��Max Value�Ɠ����l�ɂ���j
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
            //10�_���[�W�H�炤
            TakeDamage(StrongDamage);
            //�������������u�Ԃɏ���
            Destroy(other.gameObject);
            Debug.Log("����ɋ��_���[�W�^�����I");
        }
        else if (other.gameObject.tag == "weak_PB")
        {
            //10�_���[�W�H�炤
            TakeDamage(WeakDamage);
            //�������������u�Ԃɏ���
            Destroy(other.gameObject);
            Debug.Log("����Ɏ�_���[�W�^�����I");
        }
    }
    // Update is called once per frame
    void Update()
    {

        //HP��0�ɂȂ�ƓG�I�u�W�F�N�g������
        if (hpSlider.value <= 0)
        {
            /*if (!videoPlayer.isPlaying)
            {
                videoPlayer.Play();
                hpSlider.value = 0;
            }*/
            hpSlider.value = 0;
            float endTime = Time.time;//�V�[���ω����̎��Ԃ��L�^
            F3Time = endTime - startTime;//�o�ߎ��Ԃ��v�Z

            SceneManager.LoadScene("F4_Diffence2");
        }

        //HP��0�ɂȂ�ƓG�I�u�W�F�N�g������
        //if (hpSlider.value <= 0)
        //{
        //  Destroy(this.gameObject);
        //}
    }

    /*void OnVideoFinished(VideoPlayer player)
    {
        //SceneManager.LoadScene("F4_Diffence2");
    }*/

    //�_���[�W�̊֐�
    public void TakeDamage(float damageAmount)
    {
        hpSlider.value -= damageAmount;
    }
}
