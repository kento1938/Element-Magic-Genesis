using UnityEngine;
using UnityEngine.SceneManagement;

public class ToResultScene : MonoBehaviour
{
    private float step_time;    // �o�ߎ��ԃJ�E���g�p
    public float set_time=180000; //��������

    void Start()
    {
        step_time = 0.0f;       // �o�ߎ��ԏ�����
    }

    void Update()
    {
        // �o�ߎ��Ԃ��J�E���g
        step_time += Time.deltaTime;

        // 3�b��ɉ�ʑJ��
        if (step_time >= set_time)
        {
            SceneManager.LoadScene("Result");
        }

    }
}