using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class PunchWithEMG : MonoBehaviour
{
    [Header("Internal References")]
    [SerializeField] GameObject controllerObject; // �R���g���[���[�I�u�W�F�N�g�ւ̎Q��
    [SerializeField] GameObject objectToLaunchPrefabWeak; // ��U���𔭎˂���I�u�W�F�N�g�̃v���n�u
    [SerializeField] GameObject objectToLaunchPrefabStrong; // ���U���𔭎˂���I�u�W�F�N�g�̃v���n�u
    [SerializeField] GameObject objectToLaunchPrefab3; // ���˂���I�u�W�F�N�g�̃v���n�u3�ւ̎Q��
    [SerializeField] GameObject MuzzlePrefab1; // ��U���̔��ˎ��G�t�F�N�g�̃v���n�u
    [SerializeField] GameObject MuzzlePrefab2; // ���U���̔��ˎ��G�t�F�N�g�̃v���n�u
    [SerializeField] GameObject MuzzlePrefab3; // ���˂���I�u�W�F�N�g�̃v���n�u3�ւ̎Q��
    [SerializeField] private AudioSource audioPunch; // �p���`�����Đ����邽�߂̃I�[�f�B�I�\�[�X

    [Header("Launch Parameters")]
    [SerializeField] float launchForce = 100f; // �p���`�̔��˗�

    [Header("Haptics Parameters")]
    [SerializeField] float amplitude = 0.5f; // �G�o�U��
    [SerializeField] float duration = 0.5f; // �G�o��������
    [SerializeField] float cooldownTime = 0.5f; // �g���K�[�̃N�[���_�E������

    //[SerializeField] private EMG_Attack emg_attack;

    private bool canTrigger = true; // �g���K�[���\���ǂ����̃t���O
    private float EMG_data; // �ؓd�̃f�[�^

    public float Border = 30f; // ���U���Ǝ�U������ʂ��鋫�E�l
    GameObject objectToLaunchPrefab; // EMG�f�[�^�Ɋ�Â��đI�����ꂽ�U���̃v���n�u
    GameObject MuzzlePrefab; // EMG�f�[�^�Ɋ�Â��đI�����ꂽ���ˎ��G�t�F�N�g�̃v���n�u

    private bool attack_flag;

    //���˕����̒���
    public float DirectionRightSetUpX;
    public float DirectionLeftSetUpX;
    public float DirectionSetUpRightY;
    public float DirectionSetUpLeftY;
    

    void Update()
    {
        EMG_data = emg_move.emg; // EMG�f�[�^���X�V
        attack_flag = EMG_Attack.flag_attack;
        DirectionRightSetUpX = DirectionSetup.RightrotationalphaX;
        DirectionLeftSetUpX = DirectionSetup.LeftrotationalphaX;
        DirectionSetUpRightY = DirectionSetup.RightrotationalphaY;
        DirectionSetUpLeftY = DirectionSetup.RightrotationalphaY;
    }

    // ���̃R���C�_�[�ɐڐG�����Ƃ��̏���
    private void OnTriggerEnter(Collider other)
    {
        // �g���K�[���L���ȏꍇ
        if (canTrigger)
        {
            // ����̃^�O�����g���K�[�R���C�_�[�ƏՓ˂����ꍇ
            if (other.CompareTag("Line") && other.isTrigger)
            {
                StartCoroutine(TriggerCooldown()); // �g���K�[�̃N�[���_�E�����J�n
                audioPunch.Play(); // �p���`�����Đ�

                // �R���g���[���[�̈ʒu�Ɖ�]���擾
                Vector3 controllerPosition = controllerObject.transform.position;
                Quaternion controllerRotation = controllerObject.transform.rotation;
                Quaternion newRotation = Quaternion.Euler(controllerRotation.eulerAngles.x , controllerRotation.eulerAngles.y , controllerRotation.eulerAngles.z);

                // �I�u�W�F�N�g�̃^�O�� "Right" ���ǂ������m�F����
                if (controllerObject.tag == "Right")
                {
                    // �^�O�� "Right" �̏ꍇ�̏���
                    // �E��R���g���[���[��Y���̉�]��ǉ�����
                    newRotation = Quaternion.Euler(controllerRotation.eulerAngles.x * DirectionRightSetUpX, controllerRotation.eulerAngles.y * DirectionSetUpRightY, controllerRotation.eulerAngles.z);
                }

                // �I�u�W�F�N�g�̃^�O�� "Left" ���ǂ������m�F����
                if (controllerObject.tag == "Left")
                {
                    // �^�O�� "Left" �̏ꍇ�̏���
                    // ����R���g���[���[��Y���̉�]��ǉ�����
                    newRotation = Quaternion.Euler(controllerRotation.eulerAngles.x + DirectionLeftSetUpX, controllerRotation.eulerAngles.y + DirectionSetUpLeftY, controllerRotation.eulerAngles.z);
                }

                // �R���g���[���[�̑O���Ɍ����Ĕ��˂���������擾
                Vector3 launchDirection = controllerObject.transform.forward;

                if (attack_flag==false)
                {
                    objectToLaunchPrefab = objectToLaunchPrefabWeak; // ��U���̃v���n�u��I��
                    MuzzlePrefab = MuzzlePrefab1; // ��U���̔��ˎ��G�t�F�N�g�̃v���n�u��I��             
                }
                else if (attack_flag==true)
                {
                    objectToLaunchPrefab = objectToLaunchPrefabStrong; // ���U���̃v���n�u��I��
                    MuzzlePrefab = MuzzlePrefab2; // ���U���̔��ˎ��G�t�F�N�g�̃v���n�u��I��                  
                }
                else
                {
                    objectToLaunchPrefab = objectToLaunchPrefab3; // Y���W��0�̏ꍇ�̃v���n�u��I��
                    MuzzlePrefab = MuzzlePrefab3;
                }

                // ���˂���I�u�W�F�N�g�̃C���X�^���X�𐶐�
                GameObject objectToLaunch = Instantiate(objectToLaunchPrefab, controllerPosition, newRotation);
                GameObject Muzzle = Instantiate(MuzzlePrefab, controllerPosition, controllerRotation);

                // ���˂���I�u�W�F�N�g�ɗ͂������đO���ɔ�΂�
                Rigidbody objectRigidbody = objectToLaunch.GetComponent<Rigidbody>();
                objectRigidbody.AddForce(launchDirection * launchForce, ForceMode.Impulse);

                TriggerHaptics(); // �G�o�t�B�[�h�o�b�N���g���K�[����
            }
        }
    }

    // �G�o�t�B�[�h�o�b�N���g���K�[���郁�\�b�h
    private void TriggerHaptics()
    {
        controllerObject.GetComponent<XRBaseController>().SendHapticImpulse(amplitude, duration);
    }

    // �g���K�[�̃N�[���_�E�����Ǘ�����R���[�`��
    private IEnumerator TriggerCooldown()
    {
        canTrigger = false; // �g���K�[�𖳌��ɂ���
        yield return new WaitForSeconds(cooldownTime); // �N�[���_�E������
        canTrigger = true; // �g���K�[���ĂїL���ɂ���
    }
}
