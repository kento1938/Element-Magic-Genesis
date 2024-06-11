using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Transform pointerTip; // �|�C���^�[�̐�[
    public GameObject cubePrefab; // �Ǐ]������L���[�u�̃v���t�@�u

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
                    Destroy(currentCube);
                    currentCube = null;
                }
            }
        }
        else // �Փ˂��Ă��Ȃ��ꍇ
        {
            // ���݂̃L���[�u���폜����
            if (currentCube != null)
            {
                Destroy(currentCube);
                currentCube = null;
            }
        }
    }
}
