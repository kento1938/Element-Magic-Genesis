using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneF4_F5_T : MonoBehaviour
{
    private float step_time;    // 経過時間カウント用
    public float set_time; //制限時間

    bool isAnimationPlayed = false;//animationFlag

    public RawImage rawImage;
    public Animator rawImageAnimator;

    // Start is called before the first frame update
    void Start()
    {
        rawImage.gameObject.SetActive(false);
        step_time = 0.0f;       // 経過時間初期化
    }

    // Update is called once per frame
    void Update()
    {
        // 経過時間をカウント
        step_time += Time.deltaTime;

        // 3秒後に画面遷移
        if (step_time >= set_time)
        {
            rawImage.gameObject.SetActive(true);
            isAnimationPlayed = true;
            StartCoroutine(PlayAnimationWait());
            //SceneManager.LoadScene("F5_AttackTest");
        }
    }

    IEnumerator PlayAnimationWait()
    {
        rawImageAnimator.SetTrigger("PlayAnimation");
        isAnimationPlayed = false;

        yield return new WaitForSeconds(rawImageAnimator.GetCurrentAnimatorStateInfo(0).length);
        SceneManager.LoadScene("F5_AttackTest"); // 次のシーンを読み込む

    }
}
