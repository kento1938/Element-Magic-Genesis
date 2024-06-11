using Unity.VisualScripting;
using UnityEngine;

public class WeakPoint : MonoBehaviour
{
    public int weakPointDamageMultiplier = 10; // 弱点に当たった場合のダメージ倍率

    //public AudioSource audioSource;
    [SerializeField] private AudioSource audiobarrier;

    private void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("strong_PB"))
        {
            Destroy(other.gameObject);
            //audioSource.PlayOneShot(audioSource.clip);
            audiobarrier.Play(); // AudioSourceを再生
            Debug.Log("weak");

          

            // ダメージを適用する
            //EnemyHPManager hpSlider = GetComponentInParent<EnemyHPManager>(); // 親オブジェクトからEnemyHPコンポーネントを取得する
            EnemyHPSystemA2_T1 hpSlider = GetComponentInParent<EnemyHPSystemA2_T1>(); // 親オブジェクトからEnemyHPコンポーネントを取得する
            float strongDamageValue = hpSlider.StrongDamage; // 仮のプロパティ名を使用してStrongDamageを取得する
            float weakDamageValue = hpSlider.WeakDamage; // 仮のプロパティ名を使用してWeakDamageを取得する

            float value = hpSlider.GetValue();
            if (value != 0)
            {
                hpSlider.TakeDamage(weakPointDamageMultiplier * strongDamageValue);
            }
        }
        else if (other.CompareTag("weak_PB"))
        {
            Destroy(other.gameObject);
            //audioSource.PlayOneShot(audioSource.clip);
            audiobarrier.Play(); // AudioSourceを再生
            Debug.Log("weak");

           

            // ダメージを適用する
            //EnemyHPManager hpSlider = GetComponentInParent<EnemyHPManager>(); // 親オブジェクトからEnemyHPコンポーネントを取得する
            EnemyHPSystemA2_T1 hpSlider = GetComponentInParent<EnemyHPSystemA2_T1>(); // 親オブジェクトからEnemyHPコンポーネントを取得する
            float strongDamageValue = hpSlider.StrongDamage; // 仮のプロパティ名を使用してStrongDamageを取得する
            float weakDamageValue = hpSlider.WeakDamage; // 仮のプロパティ名を使用してWeakDamageを取得する

            float value = hpSlider.GetValue();
            if (value != 0)
            {
                hpSlider.TakeDamage(weakPointDamageMultiplier * weakDamageValue);
            }
        }
    }
}
