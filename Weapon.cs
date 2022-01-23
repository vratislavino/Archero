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
    public Projectile2 ProjectilePrefab;

    private float Damage = 10;
    private float Cooldown = 0.5f;

    private float currentCooldown = 0;
   
    public bool CanShoot {
        get { return currentCooldown <= 0; }
    }

    public void Shoot(Projectile2 projectile) {
        currentCooldown = Cooldown;
    }

    public void LowerCooldown(float time) {
        currentCooldown -= time;
    }
}

public class Projectile2
{

}
