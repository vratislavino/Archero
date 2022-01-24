using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateFollowingPlayer : State
{
    private void Awake() {
        EnemyState = EnemyState.FollowingPlayer;
    }

    public override void Act() {
        print("Following Player");
    }

    public override EnemyState TryToChangeState() {
        float playerDist = GetDistanceToPlayer();
        enemy.Animator.SetFloat("PlayerRange", playerDist);
        if (playerDist > 2) {
            enemy.Agent.SetDestination(player.transform.position);
        }
        return EnemyState;
    }

}
