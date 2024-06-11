using UnityEngine;
using System.Collections;

public class MagicBulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefabWeak; // �e�̃v���n�u
    public GameObject bulletPrefabStrong;
    public GameObject MGCircleWeak;
    public GameObject MGCircleStrong;
    public Transform target; // �^�[�Q�b�g��Transform
    public float interval = 3f; // �e�̔��ˊԊu
    public int numberOfBullets = 5; // ���˂���e�̐�
    public float power = 10f;
    private int bulletsFired = 0; // ���˂����e�̐�

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
        // interval�b���Ƃ�Shoot���\�b�h���Ăяo��
        InvokeRepeating("Shoot", interval, interval);
        golemObj = GameObject.Find("golem_armorture");
        Animator = golemObj.GetComponent<Animator>();
        
    }

    void Shoot()
    {
        // �^�[�Q�b�g���w�肳��Ă��Ȃ��ꍇ�͉������Ȃ�
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

        // �e�̎�ނ𒊑I
        int chooseBulletType = Random.Range(1, 3); // 1�|2�̂��������_��

        if (chooseBulletType == 1) 
        {
            LaunchMGCircle = MGCircleWeak;
            LaubchBullet = bulletPrefabWeak;
        }else
        {
            LaunchMGCircle = MGCircleStrong;
            LaubchBullet = bulletPrefabStrong;
        }

        // �e�𔭎�
        GameObject MGCircle = Instantiate(LaunchMGCircle, transform.position, Quaternion.identity);
        audiobarrier.Play(); // AudioSource���Đ�

        MGCircle.transform.LookAt(target.position);//change
        MGCircle.transform.Rotate(90, 0, 0);

        //�S�[�����̃A�j���[�V�������U�����ɕύX
        Animator.SetTrigger("DeffenceAtkWide");
        audioGolem.Play();

        // �x���H
        Vector3 direction = (target.position - transform.position).normalized;
        GameObject bullet = Instantiate(LaubchBullet, transform.position, Quaternion.identity);      
        bullet.transform.LookAt(target.position);//change
        bullet.GetComponent<Rigidbody>().velocity = direction * power; // �e�̑��x��ݒ�

        Invoke("StopAudio", 2f);


        // �e�𔭎˂��������J�E���g�A�b�v
        bulletsFired++;

        // �w�肵���e�̐��𔭎˂�����AInvoke���~����
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
