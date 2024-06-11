using UnityEngine;

public class Pointertest : MonoBehaviour
{
    public Transform pointerTip; // �|�C���^�[�̐�[
    public GameObject cubePrefab; // �Ǐ]������L���[�u�̃v���t�@�u
    public float deletionDelay = 0.03f; // �폜�̒x���b��

    private GameObject currentCube; // ���݂̃L���[�u

    void Update()
    {
        RaycastHit hit;
        // �|�C���^�[��[���烌�C���΂��ăR���C�_�[�Ƃ̏Փ˂��`�F�b�N
        if (Physics.Raycast(pointerTip.position, pointerTip.forward, out hit))
        {
            if (hit.collider.CompareTag("Line")) // �Փ˂������̂�IsTrigger�̃^�O�����R���C�_�[�Ȃ�
            {
                if (currentCube == null) // ���݂̃L���[�u���Ȃ��ꍇ
                {
                    // �L���[�u�𐶐����ĐڐG�_�Ɉړ�������
                    currentCube = Instantiate(cubePrefab, hit.point, Quaternion.identity);
                }
                else
                {
                    // ���݂̃L���[�u��ڐG�_�Ɉړ�������
                    currentCube.transform.position = hit.point;
                }
            }
            else // �Փ˂������̂�IsTrigger�̃^�O�������Ȃ��ꍇ
            {
                // ���݂̃L���[�u���폜����
                if (currentCube != null)
                {
                    // �x���������ăL���[�u���폜
                    Invoke("DeleteCube", deletionDelay);
                }
            }
        }
        else // �Փ˂��Ă��Ȃ��ꍇ
        {
            // ���݂̃L���[�u���폜����
            if (currentCube != null)
            {
                // �x���������ăL���[�u���폜
                Invoke("DeleteCube", deletionDelay);
            }
        }
    }

    // �L���[�u���폜���郁�\�b�h
    void DeleteCube()
    {
        if (currentCube != null)
        {
            Destroy(currentCube);
            currentCube = null;
        }
    }
}
