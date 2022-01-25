using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : SceneSingleton<Indicator>
{
    private Animator animator;

    protected override void Awake() {
        base.Awake();
        animator = GetComponent<Animator>();
    }

    public void SetTarget(Unit unit) {
        transform.SetParent(unit.transform);
        transform.localPosition = Vector3.up * -1;
        animator.SetTrigger("ChangeTarget");
    }
}
