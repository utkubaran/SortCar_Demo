using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleGateController : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)]
    private float gateMovementDuration = 0.5f;

    private float bufferTime = 0.15f;

    public float GateMovementDuration { get { return gateMovementDuration * 2f + bufferTime; } }

    private void OnEnable()
    {
        EventManager.OnPurpleButtonPressed.AddListener(StartGateSequence);
    }

    private void OnDisable()
    {
        EventManager.OnPurpleButtonPressed.RemoveListener(StartGateSequence);
    }

    private void StartGateSequence()
    {
        StartCoroutine(GateSequenceWithDelay());
    }

    private IEnumerator GateSequenceWithDelay()
    {
        LeanTween.rotateZ(this.gameObject, -90f, gateMovementDuration);
        yield return new WaitForSeconds(gateMovementDuration + bufferTime);
        LeanTween.rotateZ(this.gameObject, 0f, gateMovementDuration);
    }
}
