using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateWandering : State
{
    private Vector3 currentTarget;
    private bool inited = false;

    private LayerMask layerMask;

    private void Awake() {
        layerMask = ~(1 << LayerMask.NameToLayer("Projectiles"));
        EnemyState = EnemyState.Wandering;
    }

    public override void InitState(PlayerUnit player, Enemy enemy) {
        base.InitState(player, enemy);
        enemy.Animator.SetFloat("PlayerRange", GetDistanceToPlayer());
    }

    public override void Act() {
        var v1 = enemy.transform.position;
        v1.y = 0;
        var v2 = currentTarget;
        v2.y = 0;

        if (!inited || Vector3.Distance(v1,v2) < 0.1f) {
            inited = true;
            currentTarget = RandomNavmeshLocation(5f);
            enemy.Agent.SetDestination(currentTarget);
        }

    }

    public Vector3 RandomNavmeshLocation(float radius) {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1)) {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

    public override EnemyState TryToChangeState() {
        bool isPlayerInLineOfSight = IsPlayerInLineOfSight();
        if (isPlayerInLineOfSight)
            return EnemyState.FollowingPlayer;

        return EnemyState;
    }

    private bool IsPlayerInLineOfSight() {
        var dir = player.transform.position - transform.position;
        if (Physics.Raycast(transform.position, dir, out RaycastHit hit, Mathf.Infinity, layerMask)) {
            if (hit.collider.CompareTag("Player"))
                return true;
            return false;
        }
        return false;
    }
}
