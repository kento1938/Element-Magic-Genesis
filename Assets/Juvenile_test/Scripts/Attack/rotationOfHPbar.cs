using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationOfHPbar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //main camera�̌����ɍ��킹�āA�����ƃo�[���v���C���[�̐��ʂɌ����悤�ɂ��Ă���
        transform.rotation = Camera.main.transform.rotation;
    }
}
