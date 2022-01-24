using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public event Action<Unit> HpChanged;
    public event Action<Unit> Died;

    [SerializeField]
    private Faction faction;

    public Faction Faction {
        get { return faction; }
    }

    private int hp;
    private int maxHp = 100;

    public int Hp {
        get { return hp; }
        set {
            hp = value;
            HpChanged?.Invoke(this);
        }
    }
    public int MaxHp => maxHp;

    private Weapon weapon;

    protected virtual void Start() {
        Hp = MaxHp;
    }

    public void DealDamage(Projectile projectile) {
        Hp -= projectile.Damage;
        if (Hp <= 0) {
            Died?.Invoke(this);
        }
    }
}

public enum Faction
{
    Friendly,
    Enemy
}
