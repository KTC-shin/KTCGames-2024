using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    void Start()
    {
        // �������g�̃R���C�_�[���擾
        Collider myCollider = GetComponent<Collider>();

        // ���̑S�Ẵ��[�U�[�̃R���C�_�[���擾���ďՓ˂𖳎�����
        foreach (var otherLaser in GameObject.FindGameObjectsWithTag("Laser"))
        {
            if (otherLaser != gameObject) // �������g�Ƃ̏Փ˂͖���
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
        // �V�������[�U�[���������ꂽ�Ƃ��ɑ��̃��[�U�[�Ƃ̏Փ˂𖳎�
        foreach (var otherLaser in GameObject.FindGameObjectsWithTag("Laser"))
        {
            if (otherLaser != gameObject) // �������g�Ƃ̏Փ˂͖���
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
    //    // ���̑S�Ẵ��[�U�[�̃R���C�_�[���擾���ďՓ˂𖳎�����
    //    foreach (var otherLaser in GameObject.FindGameObjectsWithTag("Laser"))
    //    {
    //        if (otherLaser != gameObject) // �������g�Ƃ̏Փ˂͖���
    //        {
    //            Physics.IgnoreCollision(GetComponent<Collider>(), otherLaser.GetComponent<Collider>());
    //        }
    //    }
    //}

}
