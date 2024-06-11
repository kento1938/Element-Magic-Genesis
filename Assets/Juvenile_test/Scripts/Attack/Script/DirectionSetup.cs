using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using static Cinemachine.CinemachineOrbitalTransposer;

public class DirectionSetup : MonoBehaviour
{

    [SerializeField]
    InputActionProperty m_LeftHandSnapTurnAction = new InputActionProperty(new InputAction("Left Hand Snap Turn", expectedControlType: "Vector2"));
    // ����R���g���[���[���� Snap Turn �f�[�^��ǂݎ�邽�߂� Input System Action

    [SerializeField]
    InputActionProperty m_RightHandSnapTurnAction = new InputActionProperty(new InputAction("Right Hand Snap Turn", expectedControlType: "Vector2"));
    // �E��R���g���[���[���� Snap Turn �f�[�^��ǂݎ�邽�߂� Input System Action


    public GameObject DirectionObjectRight;
    public GameObject DirectionObjectLeft;
    public static Quaternion Direction;

    // �p�x�̃X�e�b�v�l
    private float rotationStep = 15f;
    private bool hasRotated = false;

    public static float RightrotationalphaX;
    public static float LeftrotationalphaX;
    public static float RightrotationalphaY;
    public static float LeftrotationalphaY;

    void Start()
    {
        // �A�N�V������L��������
        m_LeftHandSnapTurnAction.EnableDirectAction();
        m_RightHandSnapTurnAction.EnableDirectAction();
    }

    void Update()
    {
        // �E��̓��͒l���擾���ď������`�F�b�N����
        Vector2 rightHandValue = m_RightHandSnapTurnAction.action.ReadValue<Vector2>();
        // ����̓��͒l���擾���ď������`�F�b�N����
        Vector2 leftHandValue = m_LeftHandSnapTurnAction.action.ReadValue<Vector2>();

        // �[���x�N�g���ł���΁A��]�t���O�����Z�b�g����
        if (rightHandValue.x == 0f && rightHandValue.y == 0f)
        {
            hasRotated = false;
        }

        // �E��R���g���[���[��X���̒l�Ɋ�Â���]����
        if (!hasRotated && rightHandValue.x >= 0.85f)
        {
            // �E�ɉ�]������
            Quaternion currentRotation = DirectionObjectRight.transform.rotation;
            Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y + rotationStep, currentRotation.eulerAngles.z);
            DirectionObjectRight.transform.rotation = newRotation;
            Direction = newRotation;
            RightrotationalphaY += rotationStep;
            hasRotated = true; // �t���O��ݒ肵�Ĉ�x�������s�����悤�ɂ���
        }
        else if (!hasRotated && rightHandValue.x <= -0.85f)
        {
            // ���ɉ�]������
            Quaternion currentRotation = DirectionObjectRight.transform.rotation;
            Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y - rotationStep, currentRotation.eulerAngles.z);
            DirectionObjectRight.transform.rotation = newRotation;
            Direction = newRotation;
            RightrotationalphaY -= rotationStep;
            hasRotated = true; // �t���O��ݒ肵�Ĉ�x�������s�����悤�ɂ���
        }
        // �E��R���g���[���[��Y���̒l�Ɋ�Â���]����
        else if (!hasRotated && rightHandValue.y >= 0.85f)
        {
            // ��ɉ�]������
            Quaternion currentRotation = DirectionObjectRight.transform.rotation;
            Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles.x + rotationStep, currentRotation.eulerAngles.y, currentRotation.eulerAngles.z);
            DirectionObjectRight.transform.rotation = newRotation;
            Direction = newRotation;
            RightrotationalphaX += rotationStep;
            hasRotated = true; // �t���O��ݒ肵�Ĉ�x�������s�����悤�ɂ���
        }
        else if (!hasRotated && rightHandValue.y <= -0.85f )
        {
            // ���ɉ�]������
            Quaternion currentRotation = DirectionObjectRight.transform.rotation;
            Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles.x - rotationStep, currentRotation.eulerAngles.y, currentRotation.eulerAngles.z);
            DirectionObjectRight.transform.rotation = newRotation;
            Direction = newRotation;
            LeftrotationalphaX -= rotationStep;
            hasRotated = true; // �t���O��ݒ肵�Ĉ�x�������s�����悤�ɂ���
        }

        // ����R���g���[���[��X���̒l�Ɋ�Â���]����
        if (!hasRotated && leftHandValue.x >= 0.85f)
        {
            // �E�ɉ�]������
            Quaternion currentRotation = DirectionObjectLeft.transform.rotation;
            Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y + rotationStep, currentRotation.eulerAngles.z);
            DirectionObjectLeft.transform.rotation = newRotation;
            Direction = newRotation;
            LeftrotationalphaY += rotationStep;
            hasRotated = true; // �t���O��ݒ肵�Ĉ�x�������s�����悤�ɂ���
        }
        else if (!hasRotated && leftHandValue.x <= -0.85f)
        {
            // ���ɉ�]������
            Quaternion currentRotation = DirectionObjectLeft.transform.rotation;
            Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y - rotationStep, currentRotation.eulerAngles.z);
            DirectionObjectLeft.transform.rotation = newRotation;
            Direction = newRotation;
            LeftrotationalphaY -= rotationStep;
            hasRotated = true; // �t���O��ݒ肵�Ĉ�x�������s�����悤�ɂ���
        }
        // ����R���g���[���[��Y���̒l�Ɋ�Â���]����
        else if (!hasRotated && leftHandValue.y >= 0.85f)
        {
            // ��ɉ�]������
            Quaternion currentRotation = DirectionObjectLeft.transform.rotation;
            Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles.x + rotationStep, currentRotation.eulerAngles.y, currentRotation.eulerAngles.z);
            DirectionObjectLeft.transform.rotation = newRotation;
            Direction = newRotation;
            RightrotationalphaX += rotationStep;
            hasRotated = true; // �t���O��ݒ肵�Ĉ�x�������s�����悤�ɂ���
        }
        else if (!hasRotated && leftHandValue.y <= -0.85f )
        {
            // ���ɉ�]������
            Quaternion currentRotation = DirectionObjectLeft.transform.rotation;
            Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles.x - rotationStep, currentRotation.eulerAngles.y, currentRotation.eulerAngles.z);
            DirectionObjectLeft.transform.rotation = newRotation;
            Direction = newRotation;
            LeftrotationalphaX -= rotationStep;
            hasRotated = true; // �t���O��ݒ肵�Ĉ�x�������s�����悤�ɂ���
        }
    }


    void OnDisable()
    {
        // �A�N�V�����𖳌�������
        m_LeftHandSnapTurnAction.DisableDirectAction();
        m_RightHandSnapTurnAction.DisableDirectAction();
    }
}
