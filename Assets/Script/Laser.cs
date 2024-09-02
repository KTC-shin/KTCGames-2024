using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    void Start()
    {
        // 自分自身のコライダーを取得
        Collider myCollider = GetComponent<Collider>();

        // 他の全てのレーザーのコライダーを取得して衝突を無視する
        foreach (var otherLaser in GameObject.FindGameObjectsWithTag("Laser"))
        {
            if (otherLaser != gameObject) // 自分自身との衝突は無視
            {
                Collider otherCollider = otherLaser.GetComponent<Collider>();
                if (otherCollider != null)
                {
                    Physics.IgnoreCollision(myCollider, otherCollider);
                }
            }
        }
    }

    void OnEnable()
    {
        // 新しいレーザーが生成されたときに他のレーザーとの衝突を無視
        foreach (var otherLaser in GameObject.FindGameObjectsWithTag("Laser"))
        {
            if (otherLaser != gameObject) // 自分自身との衝突は無視
            {
                Collider otherCollider = otherLaser.GetComponent<Collider>();
                if (otherCollider != null)
                {
                    Physics.IgnoreCollision(GetComponent<Collider>(), otherCollider);
                }
            }
        }
    }

    //void Start()
    //{
    //    // 他の全てのレーザーのコライダーを取得して衝突を無視する
    //    foreach (var otherLaser in GameObject.FindGameObjectsWithTag("Laser"))
    //    {
    //        if (otherLaser != gameObject) // 自分自身との衝突は無視
    //        {
    //            Physics.IgnoreCollision(GetComponent<Collider>(), otherLaser.GetComponent<Collider>());
    //        }
    //    }
    //}

}
