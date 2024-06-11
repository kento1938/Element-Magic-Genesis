using UnityEngine;


public class Shiled_Left : MonoBehaviour
{
    [SerializeField] public GameObject Shield_L;

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
        if (data >= emg_max*0.3)
        {
            Shield_L.SetActive(true);

        }
        else if (data < emg_max * 0.3)
        {
            Shield_L.SetActive(false);

        }
    }
}
