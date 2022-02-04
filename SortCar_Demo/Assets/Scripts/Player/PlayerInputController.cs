using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            EventManager.OnPurpleButtonPressed?.Invoke();
            Debug.Log("Purple car is sent!");
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            EventManager.OnYellowButtonPressed?.Invoke();
            Debug.Log("Yellow car is sent!");
        }
    }
}
