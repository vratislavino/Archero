using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class Weapon
{
    [SerializeField]
    private Projectile ProjectilePrefab;
    public Projectile Projectile => ProjectilePrefab;

    [SerializeField]
    private float Damage = 10;

    [SerializeField]
    private float Cooldown = 0.5f;

    private float currentCooldown = 0;

    public bool CanShoot {
        get { return currentCooldown <= 0; }
    }

    public void Shoot(Projectile projectile, Vector3 direction) {
        currentCooldown = Cooldown;
        projectile.Damage = (int)Damage;
        projectile.Attack(direction);
    }

    public void LowerCooldown(float time) {
        currentCooldown -= time;
    }
}
