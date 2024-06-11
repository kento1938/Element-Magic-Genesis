using UnityEngine;

public class EMGOutputTest : MonoBehaviour
{
    private float timer = 0f;
    private float interval = 3f; // 出力間隔
    private int outputValue = 1; // 初期値

    // 外部に出力値を公開するプロパティ
    public int OutputValue
    {
        get { return outputValue; }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            timer = 0f; // タイマーをリセット

            // 出力値を更新して出力
            if (outputValue == 1)
            {
                outputValue = 0;
            }
            else if (outputValue == 0)
            {
                outputValue = -1;
            }
            else // outputValue == -1 の場合
            {
                outputValue = 1;
            }

            Debug.Log("Output Value: " + outputValue);
        }
    }
}
