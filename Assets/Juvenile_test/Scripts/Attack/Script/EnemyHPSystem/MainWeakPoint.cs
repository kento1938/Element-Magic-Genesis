using UnityEngine;

public class MainWeakPoint : MonoBehaviour
{
    public GameObject[] colliders; // 3つの当たり判定を持つGameObjectの配列
    private int currentColliderIndex = 0; // 現在アクティブな当たり判定のインデックス
    public float switchInterval = 5f; // 切り替え間隔（秒）

    void Start()
    {
        // 最初の当たり判定をアクティブにする
        //ActivateCollider(currentColliderIndex);

        // 最初にすべての当たり判定を非アクティブにする
        DeactivateAllColliders();
        
        // 指定した間隔で切り替える処理を開始する
        InvokeRepeating("SwitchCollider", switchInterval, switchInterval);
    }

    // 当たり判定の切り替え
    void SwitchCollider()
    {
        // 現在の当たり判定を非アクティブにする
        DeactivateCollider(currentColliderIndex);

        // 次の当たり判定のインデックスに切り替える
        //currentColliderIndex = (currentColliderIndex + 1) % colliders.Length;

        //currentColliderIndex = Random.Range(0, colliders.Length);

        // 次の当たり判定のインデックスにランダムに切り替える
        int nextIndex;
        do
        {
            nextIndex = Random.Range(0, colliders.Length);
        } while (nextIndex == currentColliderIndex);

        currentColliderIndex = nextIndex;


        // 新しい当たり判定をアクティブにする
        ActivateCollider(currentColliderIndex);
    }

    // 指定されたインデックスの当たり判定をアクティブにする
    void ActivateCollider(int index)
    {
        colliders[index].SetActive(true);
    }

    // 指定されたインデックスの当たり判定を非アクティブにする
    void DeactivateCollider(int index)
    {
        colliders[index].SetActive(false);
    }

    // すべての当たり判定を非アクティブにする
    void DeactivateAllColliders()
    {
        foreach (GameObject collider in colliders)
        {
            collider.SetActive(false);
        }
    }
}
