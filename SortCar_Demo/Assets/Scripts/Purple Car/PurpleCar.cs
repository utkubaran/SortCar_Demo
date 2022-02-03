using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleCar : MonoBehaviour
{
    [System.NonSerialized]
    public Car.CarColour purpleCarColour = Car.CarColour.Purple;

    private bool isParked = false;
    public bool IsParked { set { isParked = true; } }

    private void OnTriggerEnter(Collider other)
    {
        bool isParkingGrid = other.gameObject.GetComponent<ParkingGrid>();

        if (!isParkingGrid || !isParked) return;

        if (purpleCarColour == other.gameObject.GetComponent<ParkingGrid>().gridColour)
        {
            // todo enable check sign
        }
    }
}
