using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneF5_F6 : MonoBehaviour
{
    public static float step_time;    // �o�ߎ��ԃJ�E���g�p
    public static float set_time=20; //��������

    // Start is called before the first frame update
    void Start()
    {
        step_time = 0.0f;       // �o�ߎ��ԏ�����
    }

    // Update is called once per frame
    void Update()
    {
        // �o�ߎ��Ԃ��J�E���g
        step_time += Time.deltaTime;

        // 3�b��ɉ�ʑJ��
        if (step_time >= set_time)
        {
            SceneManager.LoadScene("F6_ResultTest");
        }
    }
}
