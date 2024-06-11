using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneF4_F5_T : MonoBehaviour
{
    private float step_time;    // �o�ߎ��ԃJ�E���g�p
    public float set_time; //��������

    bool isAnimationPlayed = false;//animationFlag

    public RawImage rawImage;
    public Animator rawImageAnimator;

    // Start is called before the first frame update
    void Start()
    {
        rawImage.gameObject.SetActive(false);
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
        SceneManager.LoadScene("F5_AttackTest"); // ���̃V�[����ǂݍ���

    }
}
