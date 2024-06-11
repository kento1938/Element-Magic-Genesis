using UnityEngine;


public class Shiled_Left : MonoBehaviour
{
    [SerializeField] public GameObject Shield_L;

    private float EMG_data; // 筋電のデータの受け取り

    //最大筋電の格納
    float emg_max;


    void Start()
    {
        emg_max = Calibration.emg_max;
    }


    void Update()
    {
        // EMGデータを更新する
        EMG_data = emg_move.emg;

        change(EMG_data);


    }

 

    void change(float data)
    {
        if (data >= emg_max*0.3)
        {
            Shield_L.SetActive(true);

        }
        else if (data < emg_max * 0.3)
        {
            Shield_L.SetActive(false);

        }
    }
}
