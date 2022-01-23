using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    PlayerController playerController;

    private int CurrentWeaponIndex = 0;
    public List<Weapon> weapons;


    private Weapon CurrentWeapon => weapons[CurrentWeaponIndex];

    [SerializeField]
    private Transform shootPoint;
    [SerializeField]
    private Transform graphics;

    [SerializeField]
    private Transform target;

    private void Awake() {
        playerController = GetComponent<PlayerController>();
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        CurrentWeapon.LowerCooldown(Time.deltaTime);

        if (playerController.CurrentMoveVector.sqrMagnitude == 0) {
            var dir = target.position - transform.position;

            graphics.LookAt(target);

            if (CurrentWeapon.CanShoot) {
                var projectile = CurrentWeapon.Projectile;

                var proj = Instantiate(projectile, shootPoint.position, Quaternion.identity);
                CurrentWeapon.Shoot(proj, target.position);
                //Instantiate()
            }
        }
    }
}
