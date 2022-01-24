using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateAttacking : State
{
    private void Awake() {
        EnemyState = EnemyState.Attacking;
    }

    public override void Act() {
        print("Attacking");
    }

    public override EnemyState TryToChangeState() {
        return EnemyState;
    }
}
