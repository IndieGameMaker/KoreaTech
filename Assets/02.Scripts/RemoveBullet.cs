using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    public GameObject sparkEffect;

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("BULLET"))
        {
            Destroy(coll.gameObject);
            ShowSparkEffect(coll);
        }
    }

    void ShowSparkEffect(Collision coll)
    {
        // 충돌 지점(좌표)
        ContactPoint cp = coll.GetContact(0);
        Vector3 contactPoint = cp.point;

        // 충돌 지점의 법선벡터
        Vector3 normalVector = -cp.normal;
        // 법선벡터를 쿼터니언으로 변환
        Quaternion rot = Quaternion.LookRotation(normalVector);

        // 스파크 생성
        GameObject obj = Instantiate(sparkEffect, contactPoint, rot);
        Destroy(obj, 0.4f);
    }
}
