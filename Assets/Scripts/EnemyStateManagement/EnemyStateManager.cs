using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    [SerializeField]
    private EnemyState defaultState;

    private State currentState;
    private static Dictionary<EnemyState, Type> types = new Dictionary<EnemyState, Type> {
        { EnemyState.Wandering, typeof(StateWandering) },
        { EnemyState.FollowingPlayer, typeof(StateFollowingPlayer) },
        { EnemyState.Attacking, typeof(StateAttacking) }
    };

    public void ChangeState(EnemyState newState) {
        if (currentState) {
            currentState.enabled = false;
        }
        currentState = gameObject.AddComponent(types[newState]) as State;
        Debug.Log(currentState);
    }

    public void TryToChangeState() {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentState == null) {
            ChangeState(defaultState);
            return;
        }
        var newState = currentState.TryToChangeState();
        if(newState != currentState.EnemyState) {
            ChangeState(newState);
        }
    }
}

public enum EnemyState
{
    Wandering,
    FollowingPlayer,
    Attacking
}
