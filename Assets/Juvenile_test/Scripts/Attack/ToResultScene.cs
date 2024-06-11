using UnityEngine;
using UnityEngine.SceneManagement;

public class ToResultScene : MonoBehaviour
{
    private float step_time;    // 経過時間カウント用
    public float set_time=180000; //制限時間

    void Start()
    {
        step_time = 0.0f;       // 経過時間初期化
    }

    void Update()
    {
        // 経過時間をカウント
        step_time += Time.deltaTime;

        // 3秒後に画面遷移
        if (step_time >= set_time)
        {
            SceneManager.LoadScene("Result");
        }

    }
}