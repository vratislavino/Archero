using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Unit
{
    private PlayerUnit player;
    public PlayerUnit PlayerUnit => PlayerUnit;
    private Animator animator;
    public Animator Animator => animator;
    private NavMeshAgent agent;
    public NavMeshAgent Agent => agent;

    // Start is called before the first frame update
    protected override void Start() {
        base.Start();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindObjectOfType<PlayerUnit>();
        animator = GetComponentInChildren<Animator>();
    }
    
}
