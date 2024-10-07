using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // �G�l�~�[��Prefab
    public Transform[] spawnPoints; // �G�l�~�[���X�|�[��������n�_�̃��X�g
    public float spawnInterval = 5f; // �G�l�~�[������鎞�ԊԊu

    private void Start()
    {
        // �X�|�[�����J�n����
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            // �w�肵���Ԋu�ҋ@
            yield return new WaitForSeconds(spawnInterval);

            // �����_���ȃX�|�[���n�_��I��
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            // �G�l�~�[���X�|�[���n�_�ɐ���
            GameObject gameObject1 = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
