using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneF5_F6 : MonoBehaviour
{
    public static float step_time;    // 経過時間カウント用
    public static float set_time=20; //制限時間

    // Start is called before the first frame update
    void Start()
    {
        step_time = 0.0f;       // 経過時間初期化
    }

    // Update is called once per frame
    void Update()
    {
        // 経過時間をカウント
        step_time += Time.deltaTime;

        // 3秒後に画面遷移
        if (step_time >= set_time)
        {
            SceneManager.LoadScene("F6_ResultTest");
        }
    }
}
