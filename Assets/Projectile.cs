using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
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
        Destroy(gameObject);
    }
}
