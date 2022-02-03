using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarQueueController : MonoBehaviour
{
    private PurpleCarPathFollower purpleCarPathFollower;

    private void Awake()
    {
        purpleCarPathFollower = this.GetComponent<PurpleCarPathFollower>();
    }

    private void OnTriggerEnter(Collider other)
    {
        bool isQueuePoint = other.gameObject.GetComponent<QueuePoint>();

        if (!isQueuePoint) return;

        purpleCarPathFollower.IsFirstInQueue = true;
    }
}
