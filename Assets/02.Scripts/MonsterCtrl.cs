using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterCtrl : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;

    private Transform playerTr;
    private Transform monsterTr;

    [Range(10.0f, 50.0f)]
    public float traceDist = 10.0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        playerTr = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Transform>();
        monsterTr = transform; // GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // 두 좌표간의 거리를 계산
        float distance = Vector3.Distance(monsterTr.position, playerTr.position);

        // 추적사정거리 범위안에 들어온 경우
        if (distance <= traceDist)
        {
            // 추적 명령
            agent.SetDestination(playerTr.position);
            agent.isStopped = false;
            // Walk 애니메이션 실행
            anim.SetBool("IsTrace", true);
        }
        else
        {
            agent.isStopped = true;
            // Idle 애니메이션 실행
            anim.SetBool("IsTrace", false);
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        // 충돌한 객체의 태그를 비교해서 총알여부를 판단
        if (coll.collider.CompareTag("BULLET"))
        {
            //총알 삭제
            Destroy(coll.gameObject);
            //Hit 애니메이션 실행
            anim.SetTrigger("Hit");
        }
    }

    public void OnDamage()
    {
        anim.SetTrigger("Hit");
    }
}
