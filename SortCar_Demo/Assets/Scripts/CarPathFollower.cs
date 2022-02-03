using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class CarPathFollower : MonoBehaviour
{
    [SerializeField]
    private PathCreator pathCreator;
    
    [SerializeField]
    private float movementSpeed = 5f;

    private float distanceTravelled;

    void Update()
    {
        distanceTravelled += movementSpeed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        // transform.position = pathCreator.path.
        // transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
    }
}
