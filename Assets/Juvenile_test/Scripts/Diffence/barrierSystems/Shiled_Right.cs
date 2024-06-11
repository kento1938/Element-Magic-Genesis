using UnityEngine;


public class Shiled_Right : MonoBehaviour
{
    [SerializeField]public GameObject Shield_R; // ゲームオブジェクトのプレハブを指定するための変数
    //public GameObject Shield_L; // ゲームオブジェクトのプレハブを指定するための変数


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
        if (data >= emg_max * 0.3)
        {

            // GameObject1を非表示にし、GameObject2を表示する
            Shield_R.SetActive(true);

        }
        else if (data < emg_max * 0.3)
        {

            // GameObject1を表示し、GameObject2を非表示にする
            Shield_R.SetActive(false);

        }
    }
}
