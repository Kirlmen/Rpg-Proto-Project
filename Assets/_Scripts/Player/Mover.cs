using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    NavMeshAgent navMesh;


    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MoveClick();
        }
        MovementAnimation();
    }

    private void MoveClick()
    {

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        bool hasHit = Physics.Raycast(ray, out hit);
        if (hasHit)
        {
            navMesh.destination = hit.point;
        }

        Debug.DrawRay(ray.origin, ray.direction * 40, Color.red);
    }

    private Vector3 playerSpeed;
    private void MovementAnimation()
    {
        playerSpeed = navMesh.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(playerSpeed);
        float speed = localVelocity.z;
        GetComponent<Animator>().SetFloat("forwardSpeed", speed);
    }
}
