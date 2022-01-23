using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField]
    private float speed = 10;

    private Vector3 currentMoveVector;
    public Vector3 CurrentMoveVector => currentMoveVector;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        var hor = Input.GetAxisRaw("Horizontal");
        var vert = Input.GetAxisRaw("Vertical");

        currentMoveVector = new Vector3(hor, 0, vert).normalized;
        if(currentMoveVector.sqrMagnitude > 0) {
            agent.Move(currentMoveVector * Time.deltaTime * speed);
        }
    }
}
