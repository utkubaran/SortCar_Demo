using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleButton : MonoBehaviour
{
    [SerializeField]
    private Transform buttonChamfer;

    [SerializeField]
    private PurpleGateController purpleGateController;

    private Collider buttonCollider;

    private float buttonTimer, buttonMovementDuration = 0.2f;

    private void OnEnable()
    {
        EventManager.OnPurpleButtonPressed.AddListener(MoveButton);
    }

    private void OnDisable()
    {
        EventManager.OnPurpleButtonPressed.RemoveListener(MoveButton);  
    }

    private void Awake()
    {
        buttonCollider = GetComponent<Collider>();
    }

    private void Start()
    {
        buttonTimer = purpleGateController.GateMovementDuration;
    }

    private void MoveButton()
    {
        StartCoroutine(MoveButtonWithDelay());
        StartCoroutine(DisableButtonForAWhile());
    }

    private IEnumerator MoveButtonWithDelay()
    {
        LeanTween.moveLocalY(buttonChamfer.gameObject, -5.5f, buttonMovementDuration);
        yield return new WaitForSeconds(0.25f);
        LeanTween.moveLocalY(buttonChamfer.gameObject, 0f, buttonMovementDuration);
    }

    private IEnumerator DisableButtonForAWhile()
    {
        buttonCollider.enabled = false;
        yield return new WaitForSeconds(buttonTimer);
        buttonCollider.enabled = true;
    }
}
