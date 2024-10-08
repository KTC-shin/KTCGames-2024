using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Beem : MonoBehaviour
{
    public GameObject beamPrefab;   // ビームのPrefab
    public Camera mainCamera;       // メインカメラ
    public float spawnInterval = 0.1f; // 生成間隔（秒）
    public float beamSpeed = 10f;   // ビームの速度
    public LayerMask playerLayer;   // プレイヤーのレイヤーマスク

    private bool isSpawning = false;
    private bool isBlockedByPlayer = false;

    void Update()
    {
        // マウスの左クリックを検出
        if (Input.GetMouseButtonDown(0))
        {
            // カーソルがプレイヤーに触れていない場合のみビームを発射
            if (!IsCursorOnPlayer())
            {
                isSpawning = true;
                StartCoroutine(SpawnBeam());
            }
        }

        // 左クリックを放したら生成を停止
        if (Input.GetMouseButtonUp(0))
        {
            isSpawning = false;
        }

        // カーソルがプレイヤーから離れた後、まだ左クリックが押されていればビームを再発射
        if (Input.GetMouseButton(0) && isBlockedByPlayer && !IsCursorOnPlayer())
        {
            isBlockedByPlayer = false;
            isSpawning = true;
            StartCoroutine(SpawnBeam());
        }
    }

    // カーソルがプレイヤー上にあるかどうかを確認するメソッド
    private bool IsCursorOnPlayer()
    {
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = mainCamera.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        // プレイヤーに対するレイキャストを行う
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, playerLayer))
        {
            if (hit.collider.gameObject == gameObject)
            {
                // カーソルがプレイヤーに触れている場合
                isBlockedByPlayer = true;
                return true;
            }
        }
        return false;
    }

    private IEnumerator SpawnBeam()
    {
        while (isSpawning)
        {
            // カーソルがプレイヤーに触れていない場合のみビームを生成
            if (isBlockedByPlayer)
            {
                yield return null;
                continue;
            }

            Vector3 mousePosition = Input.mousePosition;
            Ray ray = mainCamera.ScreenPointToRay(mousePosition);
            RaycastHit hit;

            Vector3 targetPosition;
            if (Physics.Raycast(ray, out hit))
            {
                // レイが他のオブジェクトにヒットした場合、ヒット位置をターゲットとする
                targetPosition = hit.point;
            }
            else
            {
                // レイがヒットしなかった場合、遠くの位置をターゲットとする
                targetPosition = ray.GetPoint(1000); // 1000はレイの長さの例
            }

            // プレイヤーの位置をベースにビームを生成
            Vector3 spawnPosition = transform.position + (targetPosition - transform.position).normalized * 1f;

            // ビームのPrefabを生成し、プレイヤーの位置に配置
            GameObject beam = Instantiate(beamPrefab, spawnPosition, Quaternion.identity);

            // ビームがカーソルの位置に向かって進むように設定
            Vector3 direction = (targetPosition - spawnPosition).normalized;
            Rigidbody rb = beam.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.useGravity = false; // 重力を無効にする
                rb.velocity = direction * beamSpeed;
            }
            else
            {
                // Rigidbodyがない場合のための移動
                beam.transform.forward = direction; // ビームの向きを設定
                beam.transform.Translate(direction * beamSpeed * spawnInterval);
            }

            // 指定した間隔待機
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}