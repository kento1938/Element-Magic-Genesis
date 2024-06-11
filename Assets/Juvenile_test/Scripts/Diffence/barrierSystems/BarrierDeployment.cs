using UnityEngine;
using System.Runtime;
using System.Net.Sockets;

public class Shiled_R : MonoBehaviour
{
    [SerializeField] private AudioSource audiobarrier; // AudioSource�^�̕ϐ���錾

    public GameObject Shield_R; // �Q�[���I�u�W�F�N�g�̃v���n�u���w�肷�邽�߂̕ϐ�
    public GameObject Shield_L;
    //public GameObject Shield_L; // �Q�[���I�u�W�F�N�g�̃v���n�u���w�肷�邽�߂̕ϐ�
    public float Border = 15f;

    public GameObject explosionPrefab;
    private float changeTime = 3f;
    private float currentTime = 0f;
    private EMGOutputTest outputController; // OutputController�ւ̎Q�Ƃ�ێ�����ϐ�
    private float maxScaleFactor = 2f;
    private float minScaleFactor = 0.5f;

    private float EMG_data; // �ؓd�̃f�[�^�̎󂯎��
    

    void Update()
    {
        // EMG�f�[�^���X�V����
        EMG_data = emg_move.emg;
        

        change(EMG_data);

        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "weak_EB" || collision.gameObject.tag == "strong_EB")
        {
            // �Փ˂����I�u�W�F�N�g���폜����
            Destroy(collision.gameObject);




            // �I�u�W�F�N�g�̔����G�t�F�N�g�𐶐�
            GameObject explosion = Instantiate(explosionPrefab, collision.contacts[0].point, Quaternion.identity);

            // 1�b��ɔ����G�t�F�N�g���폜
            Destroy(explosion, 1f);

            // AudioSource�^�������Ă���ϐ�audioPunch���Đ�
            audiobarrier.Play();

        }
    }

    void change(float data)
    {
        if (EMG_data >= Border)
        {

            // GameObject1���\���ɂ��AGameObject2��\������
            Shield_L.SetActive(true);
            Shield_R.SetActive(false);
            

        }else if (EMG_data < Border)
        {
            // GameObject1��\�����AGameObject2���\���ɂ���
            Shield_R.SetActive(true);
            Shield_L.SetActive(false);
            
        }
    }
}