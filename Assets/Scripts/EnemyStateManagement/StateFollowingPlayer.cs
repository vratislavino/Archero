using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateFollowingPlayer : State
{
    private float currentPlayerDist;

    private void Awake() {
        EnemyState = EnemyState.FollowingPlayer;
    }

    public override void InitState(PlayerUnit player, Enemy enemy) {
        base.InitState(player, enemy);
        currentPlayerDist = GetDistanceToPlayer();
        print("Following Player");
    }

    public override void Act() {
        float playerDist = GetDistanceToPlayer();
        enemy.Animator.SetFloat("PlayerRange", playerDist);
        enemy.Agent.SetDestination(player.transform.position);
    }

    public override EnemyState TryToChangeState() {
        currentPlayerDist = GetDistanceToPlayer();

        if (currentPlayerDist < 2) {
            return EnemyState.Attacking;
        }
        return EnemyState;
    }

}
