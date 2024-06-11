using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    // 敵の最大体力
    public int maxHealth = 100;
    
    // 現在の体力
    private int currentHealth;

    void Start()
    {
        // 初期状態では現在の体力を最大体力と同じ値に設定する
        currentHealth = maxHealth;
    }

    // ダメージを受ける処理
    public void TakeDamage(int damageAmount)
    {
        // 受けたダメージを現在の体力から引く
        currentHealth -= damageAmount;
        
        // 現在の体力をデバッグログで表示
        Debug.Log(currentHealth);

        // もし現在の体力が0以下になった場合、死亡処理を呼び出す
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // 死亡時の処理
    void Die()
    {
        // 敵の死亡処理を行う。この場合は、敵のゲームオブジェクトを破棄する
        Destroy(gameObject);
    }

    // 他のコライダーとの衝突時に呼ばれるメソッド
    private void OnTriggerEnter(Collider other)
    {
        // 衝突したオブジェクトが"EnemyShell"タグを持っている場合
        if(other.CompareTag("EnemyShell"))
        {
            // 衝突したオブジェクトを破棄する
            Destroy(other.gameObject);
 
            // ダメージを受ける
            TakeDamage(10);
        }
    }
}
