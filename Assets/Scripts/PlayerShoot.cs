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
    private Unit lastTarget;
    private ShootPointsPositioner shootPointsPositioner;

    [Range(1f, 1.5f)]
    public float AttackSpeed = 1f;

    private void Awake() {
        targetFinder = GetComponent<TargetFinder>();
        playerController = GetComponent<PlayerController>();
        shootPointsPositioner = GetComponentInChildren<ShootPointsPositioner>();
    }

    // Start is called before the first frame update
    void Start() {

    }



    // Update is called once per frame
    void Update() {
        CurrentWeapon.LowerCooldown(Time.deltaTime * AttackSpeed);

        target = targetFinder.GetClosestEnemy();
        if (!target)
            return;

        if (lastTarget != target) {
            Indicator.Instance.SetTarget(target);
            lastTarget = target;
        }
        if (playerController.CurrentMoveVector.sqrMagnitude == 0) {
            var dir = target.transform.position - transform.position;

            //graphics.LookAt(target);
            transform.rotation = Quaternion.LookRotation(dir.normalized);
            if (CurrentWeapon.CanShoot) {
                transform.LookAt(target.transform.position);

                foreach (var point in shootPointsPositioner.GetShootingPoints()) {
                    var projectile = CurrentWeapon.Projectile;

                    var proj = Instantiate(projectile, point.transform.position, point.transform.rotation);
                    proj.Faction = Faction.Friendly;
                    CurrentWeapon.Shoot(proj, target.transform.position);
                    Destroy(proj, 2f);
                }
                
                //Instantiate()
            }
        }
    }
}
