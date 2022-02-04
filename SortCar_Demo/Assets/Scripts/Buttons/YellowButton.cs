using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowButton : MonoBehaviour
{
    [SerializeField]
    private Transform buttonChamfer;

    private Collider buttonCollider;

    private void OnEnable()
    {
        EventManager.OnYellowButtonPressed.AddListener(MoveButton);
    }

    private void OnDisable()
    {
        EventManager.OnYellowButtonPressed.RemoveListener(MoveButton);  
    }

    private void Awake()
    {
        buttonCollider = GetComponent<Collider>();
    }

    private void MoveButton()
    {
        StartCoroutine(MoveButtonWithDelay());
        StartCoroutine(DisableButton());
    }

    private IEnumerator MoveButtonWithDelay()
    {
        LeanTween.moveLocalY(buttonChamfer.gameObject, -5.5f, 0.2f);
        yield return new WaitForSeconds(0.25f);
        LeanTween.moveLocalY(buttonChamfer.gameObject, 0f, 0.2f);
    }

    private IEnumerator DisableButton()
    {
        buttonCollider.enabled = false;
        yield return new WaitForSeconds(1.25f);
        buttonCollider.enabled = true;
    }
}
