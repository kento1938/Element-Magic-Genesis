using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMG_Attack : MonoBehaviour
{
    //[SerializeField]private Calibration Calibration;
    [SerializeField] private emg_move EMG_move;

    //�ؓd�l�̊i�[�ϐ�
    private float emg_update = 0;

    //�ő�ؓd�̊i�[
    float emg_max;

    //���U���p�̃t���O
    public static bool flag_attack = false;

    void Start()
    {
        EMG_move = GetComponent<emg_move>();
        //�ؓd�̍ő�l
        emg_max = EMG_move.Getemgmax();
        emg_max = Calibration.emg_max;
    }

    // Update is called once per frame
    void Update()
    {
        emg_update = emg_move.emg;

        if (emg_update > emg_max*0.3)
        {
            flag_attack = true;
        }
        else
        {
            flag_attack = false;
        }
    }

    //�f�[�^�̏o�͊֐�
    public bool Flag_Attack()
    {
        return flag_attack;
    }
}
