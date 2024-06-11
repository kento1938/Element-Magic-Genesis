using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FillGage : MonoBehaviour
{
    public Image gage;
    public float Rate = 200;

    private float EMG_data;//筋電のデータ

    public float emg_max;

    public GameObject Strong_Word;
    public GameObject Weak_Word;

    // Update is called once per frame
    void Update()
    {
        //筋電の最大値
        emg_max = Calibration.emg_max;
        float EMG_data = emg_move.emg;
        gage.fillAmount = EMG_data / emg_max;
        if (EMG_Attack.flag_attack)
        {
            Strong_Word.SetActive(true);
            Weak_Word.SetActive(false);
        }
        else
        {
            Strong_Word.SetActive(false);
            Weak_Word.SetActive(true);
        }

    }



}
