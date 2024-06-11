using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calibration : MonoBehaviour
{
    //筋電の差審のデータ
    public float EMG_update = emg_move.emg;
    //筋電の最大値
    public static float emg_max = 0;

    private bool flag = false;

    // Update is called once per frame
    void Update()
    {
        //スペース押している間だけ計測
        if (Input.GetKey(KeyCode.Space)) flag = true;

        
        if (flag == true)
        {
            EMG_update = emg_move.emg;
            if (emg_max < EMG_update)
            {
                emg_max = EMG_update;
            }
            Debug.Log("最大値は: " + emg_max);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("最大値は: " + emg_max);
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

    /*取得用の関数
    public float Getemgmax()
    {
        return emg_max;
    }
    */
    
}
