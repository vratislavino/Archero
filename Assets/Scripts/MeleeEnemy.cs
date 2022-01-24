using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemy : Enemy
{
    private PlayerUnit player;
    private Animator animator;
    private NavMeshAgent agent;
    public NavMeshAgent Agent => agent;

    // Start is called before the first frame update
    protected override void Start() {
        base.Start();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindObjectOfType<PlayerUnit>();
        animator = GetComponentInChildren<Animator>();
    }



    // Update is called once per frame
    void Update()
    {
        float playerDist = GetDistanceToPlayer();
        Debug.Log(playerDist);
        animator.SetFloat("PlayerRange", playerDist);
        if (playerDist > 2) {
            agent.SetDestination(player.transform.position);
        }
    }

    private float GetDistanceToPlayer() {
        return Vector3.Distance(transform.position, player.transform.position);
    }
}
