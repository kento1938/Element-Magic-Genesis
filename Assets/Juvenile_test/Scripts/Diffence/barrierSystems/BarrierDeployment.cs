using UnityEngine;
using System.Runtime;
using System.Net.Sockets;

public class Shiled_R : MonoBehaviour
{
    [SerializeField] private AudioSource audiobarrier; // AudioSource型の変数を宣言

    public GameObject Shield_R; // ゲームオブジェクトのプレハブを指定するための変数
    public GameObject Shield_L;
    //public GameObject Shield_L; // ゲームオブジェクトのプレハブを指定するための変数
    public float Border = 15f;

    public GameObject explosionPrefab;
    private float changeTime = 3f;
    private float currentTime = 0f;
    private EMGOutputTest outputController; // OutputControllerへの参照を保持する変数
    private float maxScaleFactor = 2f;
    private float minScaleFactor = 0.5f;

    private float EMG_data; // 筋電のデータの受け取り
    

    void Update()
    {
        // EMGデータを更新する
        EMG_data = emg_move.emg;
        

        change(EMG_data);

        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "weak_EB" || collision.gameObject.tag == "strong_EB")
        {
            // 衝突したオブジェクトを削除する
            Destroy(collision.gameObject);




            // オブジェクトの爆発エフェクトを生成
            GameObject explosion = Instantiate(explosionPrefab, collision.contacts[0].point, Quaternion.identity);

            // 1秒後に爆発エフェクトを削除
            Destroy(explosion, 1f);

            // AudioSource型が入っている変数audioPunchを再生
            audiobarrier.Play();

        }
    }

    void change(float data)
    {
        if (EMG_data >= Border)
        {

            // GameObject1を非表示にし、GameObject2を表示する
            Shield_L.SetActive(true);
            Shield_R.SetActive(false);
            

        }else if (EMG_data < Border)
        {
            // GameObject1を表示し、GameObject2を非表示にする
            Shield_R.SetActive(true);
            Shield_L.SetActive(false);
            
        }
    }
}