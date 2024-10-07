using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // エネミーのPrefab
    public Transform[] spawnPoints; // エネミーをスポーンさせる地点のリスト
    public float spawnInterval = 5f; // エネミーが現れる時間間隔

    private void Start()
    {
        // スポーンを開始する
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            // 指定した間隔待機
            yield return new WaitForSeconds(spawnInterval);

            // ランダムなスポーン地点を選択
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            // エネミーをスポーン地点に生成
            GameObject gameObject1 = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
