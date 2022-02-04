using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private Camera mainCam;

    private void Awake()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        PressButton();
    }
    
    private void PressButton()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            bool isPurpleButton = hit.transform.gameObject.GetComponent<PurpleButton>();
            bool isYellowButton = hit.transform.gameObject.GetComponent<YellowButton>();

            if (isPurpleButton)
            {
                EventManager.OnPurpleButtonPressed?.Invoke();
            }
            else if (isYellowButton)
            {
                EventManager.OnYellowButtonPressed?.Invoke();
            }
        }
    }
}
