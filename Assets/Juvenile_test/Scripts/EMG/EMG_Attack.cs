using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMG_Attack : MonoBehaviour
{
    //[SerializeField]private Calibration Calibration;
    [SerializeField] private emg_move EMG_move;

    //筋電値の格納変数
    private float emg_update = 0;

    //最大筋電の格納
    float emg_max;

    //強攻撃用のフラグ
    public static bool flag_attack = false;

    void Start()
    {
        EMG_move = GetComponent<emg_move>();
        //筋電の最大値
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

    //データの出力関数
    public bool Flag_Attack()
    {
        return flag_attack;
    }
}
