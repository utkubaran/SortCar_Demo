using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowCarQueueController : MonoBehaviour
{
    [SerializeField]
    private float queueStepSize;

    private YellowCarPathFollower yellowCarPathFollower;

    private void OnEnable()
    {
        EventManager.OnYellowButtonPressed.AddListener(MoveOneStep);
    }

    private void OnDisable()
    {
        EventManager.OnYellowButtonPressed.RemoveListener(MoveOneStep);
    }

    private void Awake()
    {
        yellowCarPathFollower = this.GetComponent<YellowCarPathFollower>();
    }

    private void OnTriggerEnter(Collider other)
    {
        bool isQueuePoint = other.gameObject.GetComponent<QueuePoint>();

        if (!isQueuePoint) return;

        yellowCarPathFollower.IsFirstInQueue = true;
    }

    private void MoveOneStep()
    {
        if (yellowCarPathFollower.IsFirstInQueue || !yellowCarPathFollower.IsInQueue) return;

        LeanTween.move(this.gameObject, transform.position + transform.forward * queueStepSize, 1f).setEaseInOutSine();
    }
}
