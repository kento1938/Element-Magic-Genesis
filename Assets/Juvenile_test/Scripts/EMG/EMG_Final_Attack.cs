using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMG_Final_Attack : MonoBehaviour
{
    [SerializeField] private emg_move EMG_move;

    //�ؓd�̍��R�̃f�[�^
    private float emg_update = 0;

    //�ؓd�f�[�^�̊i�[
    private float sec = 0;

    //�ő�ؓd�̊i�[
    float emg_max;

    private bool flag_time = true;

    private bool flag_attack = false;

    private int add = 2;

    private int count_now = 0;

    private int count_bef = 0;

    public static int score = 0;

    private int num = 0;
    void Start()
    {
        EMG_move = GetComponent<emg_move>();
        //�ؓd�̍ő�l
        //emg_max = Calibration.Getemgmax();
        emg_max = EMG_move.Getemgmax();
    }

    // Update is called once per frame
    void Update()
    {
        emg_update = emg_move.emg;
        if (emg_update > emg_max *0.3)
        {
            count_now = HitCounter.CountResult;
            score += (count_now - count_bef) * add;
            count_bef = count_now;
            sec += Time.deltaTime;
            if (sec > 2f)
            {
                add += 2;
                sec = 0;
            }
        }
    }
}
