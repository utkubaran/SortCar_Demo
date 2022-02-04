using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowGateController : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)]
    private float gateMovementDuration = 0.5f;

    private void OnEnable()
    {
        EventManager.OnYellowButtonPressed.AddListener(StartGateSequence);
    }

    private void OnDisable()
    {
        EventManager.OnYellowButtonPressed.RemoveListener(StartGateSequence);
    }

    private void StartGateSequence()
    {
        StartCoroutine(GateSequenceWithDelay());
    }

    private IEnumerator GateSequenceWithDelay()
    {
        LeanTween.rotateZ(this.gameObject, -90f, gateMovementDuration);
        yield return new WaitForSeconds(0.7f);
        LeanTween.rotateZ(this.gameObject, 0f, gateMovementDuration);
    }
}
