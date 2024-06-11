using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button_F0 : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClickStartButtonEasy() {
        SceneManager.LoadScene("EZ_F1_Attack1Test");
    }

    public void OnClickStartButtonNormal()
    {
        SceneManager.LoadScene("F1_Attack1Test");
    }

    public void OnClickStartButtonHard()
    {
        SceneManager.LoadScene("Hard_1_Attack");
    }
}
