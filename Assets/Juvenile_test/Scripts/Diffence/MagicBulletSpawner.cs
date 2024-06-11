using UnityEngine;
using System.Collections;

public class MagicBulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefabWeak; // 弾のプレハブ
    public GameObject bulletPrefabStrong;
    public GameObject MGCircleWeak;
    public GameObject MGCircleStrong;
    public Transform target; // ターゲットのTransform
    public float interval = 3f; // 弾の発射間隔
    public int numberOfBullets = 5; // 発射する弾の数
    public float power = 10f;
    private int bulletsFired = 0; // 発射した弾の数

    public float randomMinX = -5;
    public float randomMaxX = 5;
    public float randomMinY = -1;
    public float randomMaxY = 3;
    public float randomAngleRange = 180f;//change
    public float distance = 10f;//change

    private GameObject LaubchBullet;
    private GameObject LaunchMGCircle;

    private GameObject golemObj;
    private Animator Animator;

    [SerializeField] private AudioSource audiobarrier;
    [SerializeField] private AudioSource audioGolem;

    void Start()
    {
        // interval秒ごとにShootメソッドを呼び出す
        InvokeRepeating("Shoot", interval, interval);
        golemObj = GameObject.Find("golem_armorture");
        Animator = golemObj.GetComponent<Animator>();
        
    }

    void Shoot()
    {
        // ターゲットが指定されていない場合は何もしない
        if (target == null)
        {
            Debug.LogWarning("Target is not specified.");
            return;
        }

        float difX = Random.Range(randomMinX, randomMaxX);
        float difY = Random.Range(randomMinY, randomMaxY);


        float randomAngle = Random.Range(0f, randomAngleRange) * Mathf.Deg2Rad;//change
        //transform.position += new Vector3(difX, difY, 0);
        transform.position = new Vector3(Mathf.Cos(randomAngle)*distance, difY, Mathf.Sin(randomAngle) * distance);//change

        // 弾の種類を抽選
        int chooseBulletType = Random.Range(1, 3); // 1－2のうちランダム

        if (chooseBulletType == 1) 
        {
            LaunchMGCircle = MGCircleWeak;
            LaubchBullet = bulletPrefabWeak;
        }else
        {
            LaunchMGCircle = MGCircleStrong;
            LaubchBullet = bulletPrefabStrong;
        }

        // 弾を発射
        GameObject MGCircle = Instantiate(LaunchMGCircle, transform.position, Quaternion.identity);
        audiobarrier.Play(); // AudioSourceを再生

        MGCircle.transform.LookAt(target.position);//change
        MGCircle.transform.Rotate(90, 0, 0);

        //ゴーレムのアニメーションを攻撃中に変更
        Animator.SetTrigger("DeffenceAtkWide");
        audioGolem.Play();

        // 遅延？
        Vector3 direction = (target.position - transform.position).normalized;
        GameObject bullet = Instantiate(LaubchBullet, transform.position, Quaternion.identity);      
        bullet.transform.LookAt(target.position);//change
        bullet.GetComponent<Rigidbody>().velocity = direction * power; // 弾の速度を設定

        Invoke("StopAudio", 2f);


        // 弾を発射した数をカウントアップ
        bulletsFired++;

        // 指定した弾の数を発射したら、Invokeを停止する
        if (bulletsFired >= numberOfBullets)
        {
            CancelInvoke("Shoot");
        }
    }

    void StopAudio()
    {
        audiobarrier.Stop();
    }
}
