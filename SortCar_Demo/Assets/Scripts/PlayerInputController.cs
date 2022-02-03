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
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            EventManager.OnYellowButtonPressed?.Invoke();
        }
    }
}
