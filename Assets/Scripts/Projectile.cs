using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Faction faction;
    public Faction Faction {
        get { return faction; }
        set { faction = value; }
    }

    private int damage = 10;
    public int Damage {
        get { return damage; }
        set { damage = value; }
    }

    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    private float projectileSpeed;
    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack(Vector3 target) {
        var dir = target - transform.position;
        dir.Normalize();
        transform.LookAt(target);
        rb.AddForce(dir * projectileSpeed, ForceMode.Impulse);  
    }

    private void OnCollisionEnter(Collision collision) {
        var unit = collision.collider.GetComponent<Unit>();
        if (unit) {
            if(unit.Faction != faction) {
                unit.DealDamage(this);
            }
        }
        Destroy(gameObject);
    }
}
