using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    PlayerController playerController;

    private int CurrentWeaponIndex = 0;
    public List<Weapon> weapons;

    private TargetFinder targetFinder;

    private Weapon CurrentWeapon => weapons[CurrentWeaponIndex];

    [SerializeField]
    private Transform shootPoint;
    [SerializeField]
    private Transform graphics;

    private Unit target;

    private void Awake() {
        targetFinder = GetComponent<TargetFinder>();
        playerController = GetComponent<PlayerController>();
    }

    // Start is called before the first frame update
    void Start() {

    }



    // Update is called once per frame
    void Update() {
        CurrentWeapon.LowerCooldown(Time.deltaTime);

        target = targetFinder.GetClosestEnemy();
        if (!target)
            return;

        if (playerController.CurrentMoveVector.sqrMagnitude == 0) {
            var dir = target.transform.position - transform.position;

            //graphics.LookAt(target);
            transform.rotation = Quaternion.LookRotation(dir.normalized);
            if (CurrentWeapon.CanShoot) {
                var projectile = CurrentWeapon.Projectile;

                var proj = Instantiate(projectile, shootPoint.position, Quaternion.identity);
                proj.Faction = Faction.Friendly;
                CurrentWeapon.Shoot(proj, target.transform.position);
                //Instantiate()
            }
        }
    }
}
