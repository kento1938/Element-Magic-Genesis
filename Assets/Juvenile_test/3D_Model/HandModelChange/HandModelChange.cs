using UnityEngine;
using UnityEngine.InputSystem;

namespace YourNamespace
{
    public class HandModelChange : MonoBehaviour
    {
        [SerializeField]
        InputActionProperty m_TriggerAction = new InputActionProperty(new InputAction("TriggerAction", type: InputActionType.Button));

        [SerializeField]
        GameObject Opening;

        [SerializeField]
        GameObject Holding;

        void OnEnable()
        {
            m_TriggerAction.action.Enable();
        }

        void OnDisable()
        {
            m_TriggerAction.action.Disable();
        }

        void Update()
        {
            if (m_TriggerAction.action.ReadValue<float>() > 0.5f)
            {
                // トリガーが押されているときはオブジェクト２を表示し、オブジェクト１を非表示
                if (Opening != null)
                {
                    Opening.SetActive(false);
                }

                if (Holding != null)
                {
                    Holding.SetActive(true);
                }
            }
            else
            {
                // トリガーが押されていないときはオブジェクト１を表示し、オブジェクト２を非表示
                if (Opening != null)
                {
                    Opening.SetActive(true);
                }

                if (Holding != null)
                {
                    Holding.SetActive(false);
                }
            }
        }
    }
}
