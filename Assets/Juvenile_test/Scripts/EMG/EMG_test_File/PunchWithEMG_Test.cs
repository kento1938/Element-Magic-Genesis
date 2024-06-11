using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PunchWithEMG_Test : MonoBehaviour
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

    private bool canTrigger = true; // �g���K�[���\���ǂ����̃t���O
    private float EMG_data; // �ؓd�̃f�[�^

    //---------------------------------------------
    private EMG_Attack EMG_Attack;

    public float Border = 30f; // ���U���Ǝ�U������ʂ��鋫�E�l
    GameObject objectToLaunchPrefab; // EMG�f�[�^�Ɋ�Â��đI�����ꂽ�U���̃v���n�u
    GameObject MuzzlePrefab; // EMG�f�[�^�Ɋ�Â��đI�����ꂽ���ˎ��G�t�F�N�g�̃v���n�u

    void Update()
    {
        EMG_data = emg_move.emg; // EMG�f�[�^���X�V
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

                // �R���g���[���[�̑O���Ɍ����Ĕ��˂���������擾
                Vector3 launchDirection = controllerObject.transform.forward;

                if (EMG_Attack.Flag_Attack())
                {
                    objectToLaunchPrefab = objectToLaunchPrefabStrong; // ���U���̃v���n�u��I��
                    MuzzlePrefab = MuzzlePrefab2; // ���U���̔��ˎ��G�t�F�N�g�̃v���n�u��I��     
                    Debug.Log("aaaaa");
                }
                else
                {
                    objectToLaunchPrefab = objectToLaunchPrefabWeak; // ��U���̃v���n�u��I��
                    MuzzlePrefab = MuzzlePrefab1; // ��U���̔��ˎ��G�t�F�N�g�̃v���n�u��I��
                }
                /*else
                {
                    objectToLaunchPrefab = objectToLaunchPrefab3; // Y���W��0�̏ꍇ�̃v���n�u��I��
                    MuzzlePrefab = MuzzlePrefab3;
                }
                */

                // ���˂���I�u�W�F�N�g�̃C���X�^���X�𐶐�
                GameObject objectToLaunch = Instantiate(objectToLaunchPrefab, controllerPosition, controllerRotation);
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
