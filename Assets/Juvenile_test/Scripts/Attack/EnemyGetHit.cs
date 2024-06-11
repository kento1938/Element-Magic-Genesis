using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// EnemyGetHit�N���X�̒�`
public class EnemyGetHit : MonoBehaviour
{
    // AudioSource�^�̕ϐ���錾
    [SerializeField] private AudioSource audiobarrier; 

    // �G�����q�b�g��
    public int hitCount;
    public GameObject HitEffect;
    // HitCounter�N���X�̃C���X�^���X
    private HitCounter hitCounter;

    //�S�[�����̔�e�A�j���[�V�����p�̕ϐ�
    private GameObject golemObj;
    private Animator Animator;

    // Start���\�b�h�͍ŏ��̃t���[���̒��O�ɌĂяo�����
    void Start()
    {
        // "HitLabelPro"�Ƃ������O�̃I�u�W�F�N�g����HitCounter�R���|�[�l���g���擾����hitCounter�ɑ��
        hitCounter = GameObject.Find("HitLabelPro").GetComponent<HitCounter>();

        //�S�[�����̃I�u�W�F�N�g����Animator�R���|�[�l���g���擾
        golemObj = GameObject.Find("golem_armorture");
        Animator = golemObj.GetComponent<Animator>();
    }

    // ���̃R���C�_�[�Ƃ̏Փ˂����o����
    private void OnTriggerEnter(Collider collision)
    {
        // �Փ˂����I�u�W�F�N�g�̃^�O��"target"�ł���ꍇ
        if (collision.gameObject.tag == "target")
        {
            // HitCounter�N���X��AddCount���\�b�h���Ăяo���AhitCount��n��
            hitCounter.AddCount(hitCount);

            // �Փ˂����I�u�W�F�N�g���폜����
            Destroy(collision.gameObject);

            // �I�u�W�F�N�g�̔����G�t�F�N�g�𐶐�
            GameObject explosion = Instantiate(HitEffect, collision.ClosestPoint(this.transform.position), Quaternion.identity);

            // 1�b��ɔ����G�t�F�N�g���폜
            Destroy(explosion, 1f);

            // AudioSource�^�������Ă���ϐ�audioPunch���Đ�
            audiobarrier.Play();

            // �S�[�����̔�e���[�V������`��
            Animator.SetTrigger("SmallDamage");
        }
    }

    
}
