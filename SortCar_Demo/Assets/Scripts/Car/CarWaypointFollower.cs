using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWaypointFollower : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;

    [SerializeField]
    private float moveSpeed;

    private float waypointRadius = 0.75f;

    private Vector3 lastPosition;

    int waypointIndex = 0;

    void Start()
    {
        lastPosition = transform.position;
        transform.position = waypoints[waypointIndex].position;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Vector3.Distance(transform.position, waypoints[waypointIndex].position) < waypointRadius)
        {
            if (waypointIndex >= waypoints.Length)
            {
                waypointIndex = 0;
                return;
            }

            // float angle = Vector3.Angle(waypoints[waypointIndex - 1].position, waypoints[waypointIndex].position);
            // Debug.Log(angle);
            
            waypointIndex++;
            // Vector3 targetDirection = waypoints[waypointIndex].position - transform.position;
            // Vector3 rotationVec = Vector3.RotateTowards(transform.position, targetDirection, 15f, 0.0f);

            // LeanTween.rotate(this.gameObject, rotationVec, 1f).setEaseInOutSine();
            // lastPosition = transform.position;
            MoveWithEasing();
        }

        /*
        if (waypointIndex == waypoints.Length) return;

        LeanTween.move(this.gameObject, waypoints[waypointIndex].position, 2f).setEaseInOutSine();

        if (transform.position == waypoints[waypointIndex].transform.position) waypointIndex++;
        */
    }

    private void MoveWithEasing()
    {
        LeanTween.move(this.gameObject, waypoints[waypointIndex].position, 2f).setEaseInOutSine();
    }
}
