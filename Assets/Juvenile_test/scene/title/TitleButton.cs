using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//�Q�l�Fhttps://www.youtube.com/watch?v=NguKeMzV08U

public class TitleButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //MainEasy切り替え
    public void StartBtnEasy()
    {
        SceneManager.LoadScene("MainEasy");
    }

    //MainNormal
    public void StartBtnNormal()
    {
        SceneManager.LoadScene("MainNormal");
    }

    //MainHard
    public void StartBtnHard()
    {
        SceneManager.LoadScene("MainHard");
    }

    //gameoverからtitleへrestart
    public void ReStartBtn()
    {
        SceneManager.LoadScene("Title");
    }
}
