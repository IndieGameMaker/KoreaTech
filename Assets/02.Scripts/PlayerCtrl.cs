using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private float v;
    private float h;
    private float r;

    public float speed = 20.0f;

    [System.NonSerialized]  //C#
    [HideInInspector]       // UnityEngine
    public Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animation>(); // Generic Syntax
        anim.Play("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        v = Input.GetAxis("Vertical"); // -1.0f ~ 0.0f ~ +1.0f
        h = Input.GetAxis("Horizontal"); // -1.0f ~ 0.0f ~ +1.0f
        r = Input.GetAxis("Mouse X");

        // (전후진벡터) + (좌우벡터)
        Vector3 dir = (Vector3.forward * v) + (Vector3.right * h);
        transform.Translate(dir.normalized * Time.deltaTime * speed);
        transform.Rotate(Vector3.up * 80.0f * Time.deltaTime * r);

        PlayerAnimation();
    }

    void PlayerAnimation()
    {
        if (v >= 0.1f) // 전진
        {
            anim.CrossFade("RunF", 0.3f);
        }
        else if (v <= -0.1f) // 후진
        {
            anim.CrossFade("RunB", 0.3f);
        }
        else if (h >= 0.1f) // 오른쪽 이동
        {
            anim.CrossFade("RunR", 0.3f);
        }
        else if (h <= -0.1f) // 왼쪽으로 이동
        {
            anim.CrossFade("RunL", 0.3f);
        }
        else
        {
            anim.CrossFade("Idle", 0.2f);
        }
    }
}
