using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowCarPathFollower : MonoBehaviour
{
    private GameObject[] pathArray;
    
    private float waypointRadius = 0.01f;

    private bool canMove;

    private bool isInQueue;
    public bool IsInQueue { get { return isInQueue; } }

    private bool isFirstInQueue;
    public bool IsFirstInQueue { get { return isFirstInQueue; } set { isFirstInQueue = value; } }

    private int waypointIndex = 0;

    private void OnEnable()
    {
        EventManager.OnGridFoundForYellowCar.AddListener(GetPath);
    }

    private void OnDisable()
    {
        EventManager.OnGridFoundForYellowCar.RemoveListener(GetPath);
    }

    private void Start()
    {
        isInQueue = true;
        canMove = false;
    }

    private void Update()
    {
        if (!canMove) return;

        // Move();
    }

    private void GetPath(int index)
    {
        if (!isFirstInQueue) return;

        Path path = YellowPathController.instance.YellowCarPaths[index];
        pathArray = path.waypoints;
        isFirstInQueue = false;
        canMove = true;
        isInQueue = false;
        Move();
        transform.position = pathArray[waypointIndex].transform.position;
    }

    private void Move()
    {                
        if (Vector3.Distance(transform.position, pathArray[waypointIndex].transform.position) < waypointRadius)
        {
            waypointIndex++;

            if (waypointIndex >= pathArray.Length)
            {
                waypointIndex = 0;
                canMove = false;
                return;
            }

            MoveWithEasing();
        }
    }

    private void MoveWithEasing()
    {
        LeanTween.move(this.gameObject, pathArray[waypointIndex].transform.position, 2f).setEaseInOutSine();
    }
}
