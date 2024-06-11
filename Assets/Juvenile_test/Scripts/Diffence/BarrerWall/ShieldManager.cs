//盾：https://mono-pro.net/archives/8731

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    private int shieldHP = 10;
 
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("EnemyShell"))
        {
            //Destroy(other.gameObject);
 
            shieldHP -= 1;
 
            if(shieldHP < 1)
            {
                Destroy(gameObject);
            }
        }
    }
}
