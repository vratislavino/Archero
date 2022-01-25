using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAttacking : State
{
    private float currentPlayerDist;

    private void Awake() {
        EnemyState = EnemyState.Attacking;
    }

    public override void InitState(PlayerUnit player, Enemy enemy) {
        base.InitState(player, enemy);
        currentPlayerDist = GetDistanceToPlayer();
    }

    public override void Act() {
        enemy.Animator.SetFloat("PlayerRange", currentPlayerDist);
        
    }

    public override EnemyState TryToChangeState() {
        currentPlayerDist = GetDistanceToPlayer();

        if (currentPlayerDist > 2) {
            return EnemyState.FollowingPlayer;
        }
        return EnemyState;
    }
}
