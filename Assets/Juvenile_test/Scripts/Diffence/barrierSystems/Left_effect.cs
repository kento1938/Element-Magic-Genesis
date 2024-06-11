using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left_effect : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource audiobarrier; // AudioSource�^�̕ϐ���錾

    // �Q�[���I�u�W�F�N�g�̃v���n�u���w�肷�邽�߂̕ϐ�
    [SerializeField] public GameObject explosionPrefab;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "weak_EB")
        {
            // �Փ˂����I�u�W�F�N�g���폜����
            Destroy(collision.gameObject);

            // �I�u�W�F�N�g�̔����G�t�F�N�g�𐶐�
            GameObject explosion = Instantiate(explosionPrefab, collision.ClosestPoint(this.transform.position), Quaternion.identity);

            // 1�b��ɔ����G�t�F�N�g���폜
            Destroy(explosion, 1f);

            // AudioSource�^�������Ă���ϐ�audioPunch���Đ�
            audiobarrier.Play();

        }
    }
}
