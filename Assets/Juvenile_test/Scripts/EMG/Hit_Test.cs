using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string targetTag = "target";

    void OnTriggerEnter(Collider other)
    {
        // �Փ˂����I�u�W�F�N�g�̃^�O���w�肵���^�O�ƈ�v���邩���m�F
        if (other.gameObject.CompareTag(targetTag))
        {
            Debug.Log("hit");
        }
    }
}

