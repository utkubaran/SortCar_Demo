using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowCar : MonoBehaviour
{
    [System.NonSerialized]
    public Car.CarColour yellowCarColour = Car.CarColour.Yellow;

    private bool isParked = false;
    public bool IsParked { set { isParked = true; } }

    private bool isProcessCompleted = false;

    private void OnTriggerStay(Collider other)
    {
        bool isParkingGrid = other.gameObject.GetComponent<ParkingGrid>();

        if (!isParkingGrid || !isParked || isProcessCompleted) return;

        isProcessCompleted = true;

        if (yellowCarColour == other.gameObject.GetComponent<ParkingGrid>().gridColour)
        {
            EventManager.OnCarPlacedRightGrid?.Invoke();
            Debug.Log("Yellow is placed!");
            // todo enable check sign
        }
        else
        {
            EventManager.OnLevelFail?.Invoke();
        }
    }
}
