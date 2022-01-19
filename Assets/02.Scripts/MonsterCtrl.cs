using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterCtrl : MonoBehaviour
{
    private NavMeshAgent agent;

    private Transform playerTr;
    private Transform monsterTr;

    [Range(10.0f, 50.0f)]
    public float traceDist = 10.0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        playerTr = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Transform>();
        monsterTr = transform; // GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // 추적 명령
        agent.SetDestination(playerTr.position);
    }
}
