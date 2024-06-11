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
    // 左手コントローラーから Snap Turn データを読み取るための Input System Action

    [SerializeField]
    InputActionProperty m_RightHandSnapTurnAction = new InputActionProperty(new InputAction("Right Hand Snap Turn", expectedControlType: "Vector2"));
    // 右手コントローラーから Snap Turn データを読み取るための Input System Action


    public GameObject DirectionObjectRight;
    public GameObject DirectionObjectLeft;
    public static Quaternion Direction;

    // 角度のステップ値
    private float rotationStep = 15f;
    private bool hasRotated = false;

    public static float RightrotationalphaX;
    public static float LeftrotationalphaX;
    public static float RightrotationalphaY;
    public static float LeftrotationalphaY;

    void Start()
    {
        // アクションを有効化する
        m_LeftHandSnapTurnAction.EnableDirectAction();
        m_RightHandSnapTurnAction.EnableDirectAction();
    }

    void Update()
    {
        // 右手の入力値を取得して条件をチェックする
        Vector2 rightHandValue = m_RightHandSnapTurnAction.action.ReadValue<Vector2>();
        // 左手の入力値を取得して条件をチェックする
        Vector2 leftHandValue = m_LeftHandSnapTurnAction.action.ReadValue<Vector2>();

        // ゼロベクトルであれば、回転フラグをリセットする
        if (rightHandValue.x == 0f && rightHandValue.y == 0f)
        {
            hasRotated = false;
        }

        // 右手コントローラーのX軸の値に基づく回転処理
        if (!hasRotated && rightHandValue.x >= 0.85f)
        {
            // 右に回転させる
            Quaternion currentRotation = DirectionObjectRight.transform.rotation;
            Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y + rotationStep, currentRotation.eulerAngles.z);
            DirectionObjectRight.transform.rotation = newRotation;
            Direction = newRotation;
            RightrotationalphaY += rotationStep;
            hasRotated = true; // フラグを設定して一度だけ実行されるようにする
        }
        else if (!hasRotated && rightHandValue.x <= -0.85f)
        {
            // 左に回転させる
            Quaternion currentRotation = DirectionObjectRight.transform.rotation;
            Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y - rotationStep, currentRotation.eulerAngles.z);
            DirectionObjectRight.transform.rotation = newRotation;
            Direction = newRotation;
            RightrotationalphaY -= rotationStep;
            hasRotated = true; // フラグを設定して一度だけ実行されるようにする
        }
        // 右手コントローラーのY軸の値に基づく回転処理
        else if (!hasRotated && rightHandValue.y >= 0.85f)
        {
            // 上に回転させる
            Quaternion currentRotation = DirectionObjectRight.transform.rotation;
            Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles.x + rotationStep, currentRotation.eulerAngles.y, currentRotation.eulerAngles.z);
            DirectionObjectRight.transform.rotation = newRotation;
            Direction = newRotation;
            RightrotationalphaX += rotationStep;
            hasRotated = true; // フラグを設定して一度だけ実行されるようにする
        }
        else if (!hasRotated && rightHandValue.y <= -0.85f )
        {
            // 下に回転させる
            Quaternion currentRotation = DirectionObjectRight.transform.rotation;
            Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles.x - rotationStep, currentRotation.eulerAngles.y, currentRotation.eulerAngles.z);
            DirectionObjectRight.transform.rotation = newRotation;
            Direction = newRotation;
            LeftrotationalphaX -= rotationStep;
            hasRotated = true; // フラグを設定して一度だけ実行されるようにする
        }

        // 左手コントローラーのX軸の値に基づく回転処理
        if (!hasRotated && leftHandValue.x >= 0.85f)
        {
            // 右に回転させる
            Quaternion currentRotation = DirectionObjectLeft.transform.rotation;
            Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y + rotationStep, currentRotation.eulerAngles.z);
            DirectionObjectLeft.transform.rotation = newRotation;
            Direction = newRotation;
            LeftrotationalphaY += rotationStep;
            hasRotated = true; // フラグを設定して一度だけ実行されるようにする
        }
        else if (!hasRotated && leftHandValue.x <= -0.85f)
        {
            // 左に回転させる
            Quaternion currentRotation = DirectionObjectLeft.transform.rotation;
            Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y - rotationStep, currentRotation.eulerAngles.z);
            DirectionObjectLeft.transform.rotation = newRotation;
            Direction = newRotation;
            LeftrotationalphaY -= rotationStep;
            hasRotated = true; // フラグを設定して一度だけ実行されるようにする
        }
        // 左手コントローラーのY軸の値に基づく回転処理
        else if (!hasRotated && leftHandValue.y >= 0.85f)
        {
            // 上に回転させる
            Quaternion currentRotation = DirectionObjectLeft.transform.rotation;
            Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles.x + rotationStep, currentRotation.eulerAngles.y, currentRotation.eulerAngles.z);
            DirectionObjectLeft.transform.rotation = newRotation;
            Direction = newRotation;
            RightrotationalphaX += rotationStep;
            hasRotated = true; // フラグを設定して一度だけ実行されるようにする
        }
        else if (!hasRotated && leftHandValue.y <= -0.85f )
        {
            // 下に回転させる
            Quaternion currentRotation = DirectionObjectLeft.transform.rotation;
            Quaternion newRotation = Quaternion.Euler(currentRotation.eulerAngles.x - rotationStep, currentRotation.eulerAngles.y, currentRotation.eulerAngles.z);
            DirectionObjectLeft.transform.rotation = newRotation;
            Direction = newRotation;
            LeftrotationalphaX -= rotationStep;
            hasRotated = true; // フラグを設定して一度だけ実行されるようにする
        }
    }


    void OnDisable()
    {
        // アクションを無効化する
        m_LeftHandSnapTurnAction.DisableDirectAction();
        m_RightHandSnapTurnAction.DisableDirectAction();
    }
}
