using UnityEngine;
using UnityEngine.XR;

public class MultiCameraDisplay : MonoBehaviour
{
    Camera _thirdViewCamera;

    void Start()
    {
        //�J�����R���|�[�l���g���擾
        _thirdViewCamera = GetComponent<Camera>();
        //PC�f�B�X�v���C�\�����O�l�̎��_�J�����ɐ؂�ւ�
        OnThirdView();
    }

    //PC�f�B�X�v���C�Ƀv���C���[�ڐ���\��
    void OnPlayerView()
    {
        _thirdViewCamera.enabled = false;
        XRSettings.gameViewRenderMode = GameViewRenderMode.LeftEye;
    }

    //PC�f�B�X�v���C��ThirdViewCamera�f����\��
    void OnThirdView()
    {
        _thirdViewCamera.enabled = true;
        XRSettings.gameViewRenderMode = GameViewRenderMode.None;
    }
}
