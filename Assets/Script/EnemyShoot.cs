using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject beamPrefab;  // �r�[���̃v���n�u
    public Transform firePoint;    // �r�[���𔭎˂���ʒu
    public float fireRate = 1.0f;  // ���ˊԊu
    public float beamSpeed = 10f;  // �r�[���̑��x
    private Transform player;      // �v���C���[�̈ʒu
    private float nextFireTime;    // ���ɔ��˂ł��鎞��
    private bool canShoot = true;  // �G�l�~�[���r�[���𔭎˂ł��邩���Ǘ�����t���O

    void Start()
    {
        // �v���C���[��������
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // ���ˉ\�ŁA���̔��ˎ��Ԃ𒴂����ꍇ�Ƀr�[��������
        if (canShoot && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        // �r�[���̃C���X�^���X�𐶐�
        GameObject beam = Instantiate(beamPrefab, firePoint.position, firePoint.rotation);

        // �v���C���[�̈ʒu�Ɍ������ăr�[�����΂�
        Vector3 direction = (player.position - firePoint.position).normalized;

        // Rigidbody���g���ăr�[���ɗ͂�������
        Rigidbody rb = beam.GetComponent<Rigidbody>();
        rb.velocity = direction * beamSpeed;
    }

    // �v���C���[�̃��[�U�[�ɓ��������Ƃ��ɔ��˂��~���郁�\�b�h
    public void StopShooting()
    {
        canShoot = false;
    }
}

