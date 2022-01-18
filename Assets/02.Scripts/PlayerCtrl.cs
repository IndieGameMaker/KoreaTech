using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private float v;
    private float h;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        v = Input.GetAxis("Vertical"); // -1.0f ~ 0.0f ~ +1.0f
        h = Input.GetAxis("Horizontal"); // -1.0f ~ 0.0f ~ +1.0f

        // (전후진벡터) + (좌우벡터)
        Vector3 dir = (Vector3.forward * v) + (Vector3.right * h);
        transform.Translate(dir.normalized * 0.1f);

        Debug.Log(dir.magnitude);
        Debug.Log(dir.normalized.magnitude);    // 정규화 벡터


        // transform.Translate(Vector3.forward * 0.1f * v); //전/후진
        // transform.Translate(Vector3.right * 0.1f * h);   //좌/우

        /* 정규화 벡터(Normalized Vector), 단위벡터(Unit Vector)
            Vector3.forward = Vector3(0, 0, 1)
            Vector3.up      = Vector3(0, 1, 0)
            Vector3.right   = Vector3(1, 0, 0)

            Vector3.one     = Vector3(1, 1, 1)
            Vector3.zero    = Vector3(0, 0, 0)
        */
    }
}
