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
                // �g���K�[��������Ă���Ƃ��̓I�u�W�F�N�g�Q��\�����A�I�u�W�F�N�g�P���\��
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
                // �g���K�[��������Ă��Ȃ��Ƃ��̓I�u�W�F�N�g�P��\�����A�I�u�W�F�N�g�Q���\��
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
