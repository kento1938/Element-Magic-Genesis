using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calibration : MonoBehaviour
{
    //�ؓd�̍��R�̃f�[�^
    public float EMG_update = emg_move.emg;
    //�ؓd�̍ő�l
    public static float emg_max = 0;

    private bool flag = false;

    // Update is called once per frame
    void Update()
    {
        //�X�y�[�X�����Ă���Ԃ����v��
        if (Input.GetKey(KeyCode.Space)) flag = true;

        
        if (flag == true)
        {
            EMG_update = emg_move.emg;
            if (emg_max < EMG_update)
            {
                emg_max = EMG_update;
            }
            Debug.Log("�ő�l��: " + emg_max);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("�ő�l��: " + emg_max);
        }
        if (Input.GetKey(KeyCode.D))
        {
            emg_max = 80;
        }
        if (Input.GetKey(KeyCode.L))
        {
            emg_max = 0;
        }

        flag = false;

    }

    /*�擾�p�̊֐�
    public float Getemgmax()
    {
        return emg_max;
    }
    */
    
}
