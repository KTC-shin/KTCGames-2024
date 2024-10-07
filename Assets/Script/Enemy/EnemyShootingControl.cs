using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingControl : MonoBehaviour
{
    public GameObject enemyBeamPrefab;   // �G�l�~�[�̃r�[��Prefab
    public Transform firePoint;          // ���ˈʒu
    public float fireRate = 1f;          // ���ˊԊu
    public float beamSpeed = 10f;        // �r�[���̑��x
    private Transform player;            // �v���C���[��Transform
    private bool canShoot = true;        // �r�[�������ˉ\��

    private void Start()
    {
        // �v���C���[��Tag�Ō���
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // ���Ԋu�Ńr�[���𔭎˂���
        InvokeRepeating("ShootAtPlayer", fireRate, fireRate);
    }

    void ShootAtPlayer()
    {
        if (player != null && canShoot)
        {
            // �v���C���[�ւ̕������v�Z
            Vector3 direction = (player.position - firePoint.position).normalized;

            // �r�[���𐶐�
            GameObject beam = Instantiate(enemyBeamPrefab, firePoint.position, Quaternion.LookRotation(direction));

            // �r�[���� Rigidbody �R���|�[�l���g���擾���ĕ����ɉ������͂�������
            Rigidbody rb = beam.GetComponent<Rigidbody>();
            rb.velocity = direction * beamSpeed;
        }
    }

    // �v���C���[�̃r�[�����G�l�~�[�ɓ��������ꍇ�Ƀr�[�����˂��~����
    public void StopShooting()
    {
        canShoot = false;  // �r�[�����~�߂�
    }

    // �G�l�~�[���v���C���[�̃r�[���ɓ����������̏���
    private void OnTriggerEnter(Collider other)
    {
        // �v���C���[�̃r�[���ɓ����������ǂ������m�F�iPlayerBeam�Ƃ����^�O�����Ă���O��j
        if (other.CompareTag("Laser"))
        {
            StopShooting();  // �r�[�����˂��~����
        }
    }
}

