using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//UI�ɕύX��������̂ɕK�v
using UnityEngine.UI;
using TMPro;
using static UnityEngine.Rendering.DebugUI;


public class TimeCounter : MonoBehaviour
{
    //hit���̐��l��\��
    private float set_time = 20;
    private float step_time;
    public static int CountResult;

    private float time = 0;

    //text�̒��g��\��
    private TextMeshProUGUI hitlabelPro;



    // Start is called before the first frame update
    void Start()
    {
        //�R���|�[�l���g�̎擾
        hitlabelPro = GetComponent<TextMeshProUGUI>();
        //hitlabelPro.text = count.ToString() + "Hit!!";
        hitlabelPro.text = set_time.ToString() + "";
    }

    public void AddCount(int amount)
    {
        //count += amount;
        //hitlabelPro.text = count.ToString() + "Hit!!";

    }

    // Update is called once per frame
    void Update()
    {
        step_time += Time.deltaTime;
        time = set_time - step_time;
        string formattedValue = time.ToString("F1");
        //Mathf.Ceil(time);
        hitlabelPro.text = formattedValue.ToString() + "";
    }
}
