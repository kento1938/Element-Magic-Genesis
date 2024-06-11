using UnityEngine;

public class EMG_Y : MonoBehaviour
{
    // �ڕW��Y���W
    public float targetY = 10f;

    // �I�u�W�F�N�g�̑��x
    public float speed = 5f;
    public emg_accept otherScript;

    void Start()
    {
        
    }

    void Update()
    {
        otherScript.ThreadMethod();
        
        // �ڕW��Y���W�Ɍ������ăI�u�W�F�N�g���ړ�
        MoveToTargetY();
    }

    void MoveToTargetY()
    {
        // �ڕW�̍��W���쐬
        Vector3 targetPosition = new Vector3(transform.position.x, targetY, transform.position.z);

        // �ڕW�̍��W�܂ł̕����x�N�g�����v�Z
        Vector3 direction = (targetPosition - transform.position).normalized;

        // �ڕW�̍��W�Ɍ������Ĉړ�
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
