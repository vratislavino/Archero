using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateWandering : State
{
    private void Awake() {
        EnemyState = EnemyState.Wandering;
    }

    public override void Act() {
        print("Wandering");
    }

    public override EnemyState TryToChangeState() {
        return EnemyState;
    }
}
