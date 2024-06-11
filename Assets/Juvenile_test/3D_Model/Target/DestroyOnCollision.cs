using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public GameObject PrefabTarget;

    // �Փˎ��ɌĂяo����郁�\�b�h
    private void OnCollisionEnter(Collision collision)
    {
        // ���̃X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g��j��
        Destroy(gameObject);

        //�����_���Ȉʒu�ɐ���
        /*float x = Random.Range(-4.0f, 4.0f);
        float y = Random.Range(0.0f, 10.0f);
        Vector3 pos = new Vector3(x, y, 6.0f);

        Instantiate(PrefabTarget, pos, Quaternion.identity);*/
    }

    // �g���K�[�Փˎ��ɌĂяo����郁�\�b�h
    private void OnTriggerEnter(Collider other)
    {
        // ���̃X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g��j��
        Destroy(gameObject);

        //�����_���Ȉʒu�ɐ���
        /*float x = Random.Range(-4.0f, 4.0f);
        float y = Random.Range(0.0f, 10.0f);
        Vector3 pos = new Vector3(x, y, 6.0f);

        Instantiate(PrefabTarget, pos, Quaternion.identity);*/
    }
}
