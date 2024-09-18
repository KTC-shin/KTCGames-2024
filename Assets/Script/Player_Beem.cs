using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Beem : MonoBehaviour
{
    public GameObject beamPrefab;   // �r�[����Prefab
    public Camera mainCamera;       // ���C���J����
    public float spawnInterval = 0.1f; // �����Ԋu�i�b�j
    public float beamSpeed = 10f;   // �r�[���̑��x
    public LayerMask playerLayer;   // �v���C���[�̃��C���[�}�X�N

    private bool isSpawning = false;
    private bool isBlockedByPlayer = false;

    void Update()
    {
        // �}�E�X�̍��N���b�N�����o
        if (Input.GetMouseButtonDown(0))
        {
            isSpawning = true;
            StartCoroutine(SpawnBeam());
        }

        // ���N���b�N��������琶�����~
        if (Input.GetMouseButtonUp(0))
        {
            isSpawning = false;
        }
    }

    private IEnumerator SpawnBeam()
    {
        while (isSpawning)
        {
            // �J�[�\���̃X�N���[�����W�����[���h���W�ɕϊ�
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = mainCamera.ScreenPointToRay(mousePosition);
            RaycastHit hit;

            // �v���C���[�ɑ΂��郌�C�L���X�g���s��
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, playerLayer))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    // �q�b�g�����I�u�W�F�N�g���v���C���[���g�̏ꍇ�A�r�[���𔭎˂��Ȃ�
                    isBlockedByPlayer = true;
                    yield return null;
                    continue;
                }
            }

            // �v���C���[�ɐG��Ă��Ȃ��ꍇ
            if (isBlockedByPlayer)
            {
                isBlockedByPlayer = false;
            }

            Vector3 targetPosition;
            if (Physics.Raycast(ray, out hit))
            {
                // ���C�����̃I�u�W�F�N�g�Ƀq�b�g�����ꍇ�A�q�b�g�ʒu���^�[�Q�b�g�Ƃ���
                targetPosition = hit.point;
            }
            else
            {
                // ���C���q�b�g���Ȃ������ꍇ�A�����̈ʒu���^�[�Q�b�g�Ƃ���
                targetPosition = ray.GetPoint(1000); // 1000�̓��C�̒����̗�
            }

            // �v���C���[�̈ʒu���x�[�X�Ƀr�[���𐶐�
            Vector3 spawnPosition = transform.position + (targetPosition - transform.position).normalized * 1f;

            // �r�[����Prefab�𐶐����A�v���C���[�̈ʒu�ɔz�u
            GameObject beam = Instantiate(beamPrefab, spawnPosition, Quaternion.identity);

            // �r�[�����J�[�\���̈ʒu�Ɍ������Đi�ނ悤�ɐݒ�
            Vector3 direction = (targetPosition - spawnPosition).normalized;
            Rigidbody rb = beam.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.useGravity = false; // �d�͂𖳌��ɂ���
                rb.velocity = direction * beamSpeed;
            }
            else
            {
                // Rigidbody���Ȃ��ꍇ�̂��߂̈ړ�
                beam.transform.forward = direction; // �r�[���̌�����ݒ�
                beam.transform.Translate(direction * beamSpeed * spawnInterval);
            }

            // �w�肵���Ԋu�ҋ@
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}