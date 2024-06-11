using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//UIに変更を加えるのに必要
using UnityEngine.UI;
using TMPro;
using static UnityEngine.Rendering.DebugUI;


public class HitCounter : MonoBehaviour
{
    //hit数の数値を表す
    /*private float set_time = 20;
    private float step_time;*/
    public static int CountResult;

    //private float time = 0; 
    //private int count = 0;
 
    //textの中身を表す
    private TextMeshProUGUI hitlabelPro;



    // Start is called before the first frame update
    void Start()
    {
        //コンポーネントの取得
        hitlabelPro = GetComponent<TextMeshProUGUI>();
        hitlabelPro.text = CountResult.ToString() + "Hit!!";
        //hitlabelPro.text = set_time.ToString() + "!!";
    }

    public void AddCount(int amount)
    {
        CountResult += amount;
        hitlabelPro.text = CountResult.ToString() + "Hit!!";
        
    }

    // Update is called once per frame
    void Update()
    {
        //step_time += Time.deltaTime;
        //time = set_time - step_time;
        //Mathf.Ceil(time);
        hitlabelPro.text = CountResult.ToString() + "Hit!!";
    }
}
