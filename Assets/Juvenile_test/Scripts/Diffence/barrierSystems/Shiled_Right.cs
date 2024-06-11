using UnityEngine;


public class Shiled_Right : MonoBehaviour
{
    [SerializeField]public GameObject Shield_R; // �Q�[���I�u�W�F�N�g�̃v���n�u���w�肷�邽�߂̕ϐ�
    //public GameObject Shield_L; // �Q�[���I�u�W�F�N�g�̃v���n�u���w�肷�邽�߂̕ϐ�


    private float EMG_data; // �ؓd�̃f�[�^�̎󂯎��

    //�ő�ؓd�̊i�[
    float emg_max;


    void Start()
    {
        emg_max = Calibration.emg_max;
    }


    void Update()
    {
        // EMG�f�[�^���X�V����
        EMG_data = emg_move.emg;

        change(EMG_data);


    }



    void change(float data)
    {
        if (data >= emg_max * 0.3)
        {

            // GameObject1���\���ɂ��AGameObject2��\������
            Shield_R.SetActive(true);

        }
        else if (data < emg_max * 0.3)
        {

            // GameObject1��\�����AGameObject2���\���ɂ���
            Shield_R.SetActive(false);

        }
    }
}
