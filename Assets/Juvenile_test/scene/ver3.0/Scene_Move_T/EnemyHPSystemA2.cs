using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EnemyHPSystemA2_T1 : MonoBehaviour
{
    [SerializeField] private AudioSource audiobarrier; // AudioSource�^�̕ϐ�
    private float startTime; // �J�n����

    bool isAnimationPlayed = false;//animationFlag

    public GameObject HitEffectStrong; // ���U���̃G�t�F�N�g
    public GameObject HitEffectWeak; // ��U���̃G�t�F�N�g
    public static float F3Time; // �V�[�����ς��܂ł̎���
    public float StrongDamage = 20; // ���U���̃_���[�W��
    public float WeakDamage = 20; // ��U���̃_���[�W��
    public Slider hpSlider; // �̗͂�\������X���C�_�[
    public float walkWidth = 2;
    private float walkDiff = 0.01f;
    private float plusMinusSign = 1;

    private GameObject golemObj;
    private Animator Animator;

    public RawImage rawImage;
    public Animator rawImageAnimator;

    private float step_time;    // �o�ߎ��ԃJ�E���g�p
    public float set_time = 20; //��������

    // Start is called before the first frame update
    void Start()
    {
        step_time = 0.0f;
        startTime = Time.time; // �J�n���Ԃ��L�^
        startTime = Time.time; // �J�n���Ԃ��L�^
        hpSlider.value = 100; // �̗̓X���C�_�[�̒l���ő�l�ɐݒ�
        rawImage.gameObject.SetActive(false);

        golemObj = GameObject.Find("golem_armorture");
        Animator = golemObj.GetComponent<Animator>();
    }

    public float GetValue()
    {
        return hpSlider.value; // �̗͂̌��ݒl���擾
    }

    // ���̃R���C�_�[�Ƃ̏Փ˂����o����
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "strong_PB")
        {
            // ���U�����󂯂��ꍇ
            TakeDamage(StrongDamage); // �_���[�W���󂯂�
            Destroy(collision.gameObject); // �Փ˂����I�u�W�F�N�g��j��

            // �����G�t�F�N�g�𐶐�����1�b��ɔj��
            GameObject explosion = Instantiate(HitEffectStrong, collision.ClosestPoint(this.transform.position), Quaternion.identity);
            Destroy(explosion, 1f);

            // �S�[�����̔�e���[�V������`��
            Animator.SetTrigger("SmallDamage");

            audiobarrier.Play(); // AudioSource���Đ�
        }
        else if (collision.gameObject.tag == "weak_PB")
        {
            // ��U�����󂯂��ꍇ
            TakeDamage(WeakDamage); // �_���[�W���󂯂�
            Destroy(collision.gameObject); // �Փ˂����I�u�W�F�N�g��j��

            // �����G�t�F�N�g�𐶐�����1�b��ɔj��
            GameObject explosion = Instantiate(HitEffectWeak, collision.ClosestPoint(this.transform.position), Quaternion.identity);
            Destroy(explosion, 1f);

            // �S�[�����̔�e���[�V������`��
            Animator.SetTrigger("SmallDamage");

            audiobarrier.Play(); // AudioSource���Đ�
        }
    }

    // Update is called once per frame
    void Update()
    {
        step_time += Time.deltaTime;
        // �̗͂�0�ȉ��ɂȂ�����V�[����؂�ւ���
        if (hpSlider.value <= 0)
        {
            rawImage.gameObject.SetActive(true);
            hpSlider.value = 0; // �̗̓X���C�_�[�̒l��0�ɐݒ�
            float endTime = Time.time; // �V�[���ω����̎��Ԃ��L�^
            F3Time = endTime - startTime; // �o�ߎ��Ԃ��v�Z

            isAnimationPlayed = true;
            StartCoroutine(PlayAnimationWait());
            //SceneManager.LoadScene("F4_Diffence2Test"); // ���̃V�[����ǂݍ���
        }
        else if (step_time >= set_time)
        {
            rawImage.gameObject.SetActive(true);
            float endTime = Time.time; // �V�[���ω����̎��Ԃ��L�^
            F3Time = endTime - startTime; // �o�ߎ��Ԃ��v�Z
            //hpSlider.value = 0; // �̗̓X���C�_�[�̒l��0�ɐݒ�
            isAnimationPlayed = true;
            StartCoroutine(PlayAnimationWait());
        }

        //�S�[�������������
        transform.position += new Vector3(walkDiff, 0, 0) * plusMinusSign;

        if (Math.Abs(transform.position.x) > walkWidth)
        {
            plusMinusSign = -1 * plusMinusSign;
        }
    }

    // �_���[�W���󂯂�֐�
    public void TakeDamage(float damageAmount)
    {
        hpSlider.value -= damageAmount; // �̗͂�����������
    }

    IEnumerator PlayAnimationWait()
    {
        rawImageAnimator.SetTrigger("PlayAnimation");
        isAnimationPlayed = false;

        yield return new WaitForSeconds(rawImageAnimator.GetCurrentAnimatorStateInfo(0).length);
        SceneManager.LoadScene("F4_Diffence2Test"); // ���̃V�[����ǂݍ���

    }
}
