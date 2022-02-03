using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleCarQueueController : MonoBehaviour
{
    [SerializeField]
    private float queueStepSize;

    private PurpleCarPathFollower purpleCarPathFollower;

    private void OnEnable()
    {
        EventManager.OnPurpleButtonPressed.AddListener(MoveOneStep);
    }

    private void OnDisable()
    {
        EventManager.OnPurpleButtonPressed.RemoveListener(MoveOneStep);
    }

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

    private void MoveOneStep()
    {
        if (purpleCarPathFollower.IsFirstInQueue || !purpleCarPathFollower.IsInQueue) return;

        LeanTween.move(this.gameObject, transform.position + transform.forward * queueStepSize, 1f).setEaseInOutSine();
    }
}
