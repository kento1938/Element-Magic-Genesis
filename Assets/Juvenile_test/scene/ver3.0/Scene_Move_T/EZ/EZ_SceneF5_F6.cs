using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EZ_SceneF5_F6 : MonoBehaviour
{
    private float step_time;    // �o�ߎ��ԃJ�E���g�p
    public float set_time; //��������

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
            SceneManager.LoadScene("EZ_F6_ResultTest");
        }
    }
}
