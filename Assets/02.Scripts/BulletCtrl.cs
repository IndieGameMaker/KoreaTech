using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // 물리력 전달
        rb.AddRelativeForce(Vector3.forward * 800.0f);
    }

}
