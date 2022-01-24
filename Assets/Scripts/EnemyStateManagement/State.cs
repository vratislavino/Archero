using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public EnemyState EnemyState;
    protected PlayerUnit player;
    protected Enemy enemy;

    public abstract EnemyState TryToChangeState();

    public abstract void Act();

    protected float GetDistanceToPlayer() {
        return Vector3.Distance(transform.position, player.transform.position);
    }
}
