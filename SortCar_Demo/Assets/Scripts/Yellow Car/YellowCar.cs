using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowCar : MonoBehaviour
{
    [System.NonSerialized]
    public Car.CarColour yellowCarColour = Car.CarColour.Yellow;

    private bool isParked = false;
    public bool IsParked { set { isParked = true; } }

    private void OnTriggerEnter(Collider other)
    {
        bool isParkingGrid = other.gameObject.GetComponent<ParkingGrid>();

        if (!isParkingGrid || !isParked) return;

        if (yellowCarColour == other.gameObject.GetComponent<ParkingGrid>().gridColour)
        {
            // todo enable check sign
        }
    }
}
