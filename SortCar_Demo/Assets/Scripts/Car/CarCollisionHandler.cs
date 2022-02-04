using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        bool isPurpleCar = other.gameObject.GetComponent<PurpleCar>();
        bool isYellowCar = other.gameObject.GetComponent<YellowCar>();

        if (!isPurpleCar && !isYellowCar) return;

        EventManager.OnLevelFail?.Invoke();
    }
}
