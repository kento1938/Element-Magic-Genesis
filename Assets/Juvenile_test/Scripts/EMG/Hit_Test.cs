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
        // 衝突したオブジェクトのタグが指定したタグと一致するかを確認
        if (other.gameObject.CompareTag(targetTag))
        {
            Debug.Log("hit");
        }
    }
}

