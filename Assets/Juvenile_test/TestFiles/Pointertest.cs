using UnityEngine;

public class Pointertest : MonoBehaviour
{
    public Transform pointerTip; // ポインターの先端
    public GameObject cubePrefab; // 追従させるキューブのプレファブ
    public float deletionDelay = 0.03f; // 削除の遅延秒数

    private GameObject currentCube; // 現在のキューブ

    void Update()
    {
        RaycastHit hit;
        // ポインター先端からレイを飛ばしてコライダーとの衝突をチェック
        if (Physics.Raycast(pointerTip.position, pointerTip.forward, out hit))
        {
            if (hit.collider.CompareTag("Line")) // 衝突したものがIsTriggerのタグを持つコライダーなら
            {
                if (currentCube == null) // 現在のキューブがない場合
                {
                    // キューブを生成して接触点に移動させる
                    currentCube = Instantiate(cubePrefab, hit.point, Quaternion.identity);
                }
                else
                {
                    // 現在のキューブを接触点に移動させる
                    currentCube.transform.position = hit.point;
                }
            }
            else // 衝突したものがIsTriggerのタグを持たない場合
            {
                // 現在のキューブを削除する
                if (currentCube != null)
                {
                    // 遅延を加えてキューブを削除
                    Invoke("DeleteCube", deletionDelay);
                }
            }
        }
        else // 衝突していない場合
        {
            // 現在のキューブを削除する
            if (currentCube != null)
            {
                // 遅延を加えてキューブを削除
                Invoke("DeleteCube", deletionDelay);
            }
        }
    }

    // キューブを削除するメソッド
    void DeleteCube()
    {
        if (currentCube != null)
        {
            Destroy(currentCube);
            currentCube = null;
        }
    }
}
