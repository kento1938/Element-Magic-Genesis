using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ScoreResult : MonoBehaviour
{

    public TextMeshProUGUI TimePro;
    public TextMeshProUGUI HPPro;
    public TextMeshProUGUI ScorePro;
    //public TextMeshProUGUI HitPro;

    private float score = 0;
    private float time = 0;

    float F1TimeResult = EnemyHPSystemA1_T1.F1Time;
    float F3TimeResult = EnemyHPSystemA2_T1.F3Time;
    float F2MyHPResult = PlayerHPManager.F2MyHP;

    int HP;

    String[] rank = {"SS","S","S","A", "A", "B" };

    String rank_point;

    //int F5CountResult = HitCounter.CountResult;

    // Start is called before the first frame update
    void Start()
    {
        HP = (int)F2MyHPResult;
        time = F1TimeResult+F3TimeResult;
        score = Mathf.Abs(100 - F1TimeResult)*30 +  - Mathf.Abs( - F2MyHPResult)*10 + EMG_Final_Attack.score;
        Debug.Log("F1‚ÌŽžŠÔ"+F1TimeResult);
        Debug.Log("F3‚ÌŽžŠÔ" + F3TimeResult);
        Debug.Log("F2‚ÌŽc‚è‘Ì—Í" + F2MyHPResult);
        //Debug.Log("F5‚Ìƒqƒbƒg”" + F5CountResult);
    }

    // Update is called once per frame
    void Update()
    {
        if (HP > 5) HP = 5;
        rank_point = rank[HP];
        //HitPro.text = string.Format("" + F5CountResult);
        TimePro.text = string.Format("" + Mathf.Ceil(time)+".0s");
        HPPro.text = string.Format("" + rank_point);
        ScorePro.text = string.Format("" + Mathf.Ceil(score));
    }
}
