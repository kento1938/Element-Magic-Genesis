using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_judge : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "target")
        {
            Debug.Log("�v���C���[�ɏՓ˂��܂���");
            //Destroy(other.gameObject);
        }
    }

}
