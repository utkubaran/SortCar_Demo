using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowCarPathFollower : MonoBehaviour
{
    [SerializeField]
    private float totalTravelDuration = 2f;

    [SerializeField]
    private float rotationSpeed = 10f;

    private GameObject[] pathArray;

    private YellowCar yellowCar;
    
    private float waypointRadius = 0.5f;

    private bool canMove;

    private bool isInQueue;
    public bool IsInQueue { get { return isInQueue; } }

    private bool isFirstInQueue;
    public bool IsFirstInQueue { get { return isFirstInQueue; } set { isFirstInQueue = value; } }

    private int waypointIndex = 0;

    private float stepDuration;

    private void OnEnable()
    {
        EventManager.OnGridFoundForYellowCar.AddListener(GetPath);
    }

    private void OnDisable()
    {
        EventManager.OnGridFoundForYellowCar.RemoveListener(GetPath);
    }

    private void Awake()
    {
        yellowCar = GetComponent<YellowCar>();
    }

    private void Start()
    {
        isInQueue = true;
        canMove = false;
    }

    private void Update()
    {
        if (!canMove) return;

        Move();
    }

    private void GetPath(int index)
    {
        if (!isFirstInQueue) return;

        Path path = YellowPathController.instance.YellowCarPaths[index];
        pathArray = path.waypoints;
        isFirstInQueue = false;
        canMove = true;
        isInQueue = false;
        transform.position = pathArray[waypointIndex].transform.position;
        stepDuration = (pathArray.Length > 2) ? ((totalTravelDuration * 1.5f) / (pathArray.Length - 1)) : (totalTravelDuration / (pathArray.Length - 1));
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
                yellowCar.IsParked = true;
                return;
            }

            MoveWithEasing();
        }

        RotateTowardsNextWaypoint();
    }

    private void MoveWithEasing()
    {
        LeanTween.move(this.gameObject, pathArray[waypointIndex].transform.position, stepDuration).setEaseInOutSine();
    }

    private void RotateTowardsNextWaypoint()
    {
        Vector3 direction = pathArray[waypointIndex].transform.position - this.transform.position;
        Quaternion toRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }
}
