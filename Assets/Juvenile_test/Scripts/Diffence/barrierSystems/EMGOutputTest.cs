using UnityEngine;

public class EMGOutputTest : MonoBehaviour
{
    private float timer = 0f;
    private float interval = 3f; // �o�͊Ԋu
    private int outputValue = 1; // �����l

    // �O���ɏo�͒l�����J����v���p�e�B
    public int OutputValue
    {
        get { return outputValue; }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            timer = 0f; // �^�C�}�[�����Z�b�g

            // �o�͒l���X�V���ďo��
            if (outputValue == 1)
            {
                outputValue = 0;
            }
            else if (outputValue == 0)
            {
                outputValue = -1;
            }
            else // outputValue == -1 �̏ꍇ
            {
                outputValue = 1;
            }

            Debug.Log("Output Value: " + outputValue);
        }
    }
}
