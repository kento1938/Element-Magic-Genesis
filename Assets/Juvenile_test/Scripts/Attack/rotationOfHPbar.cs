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
        //main cameraの向きに合わせて、ずっとバーがプレイヤーの正面に向くようにしている
        transform.rotation = Camera.main.transform.rotation;
    }
}
