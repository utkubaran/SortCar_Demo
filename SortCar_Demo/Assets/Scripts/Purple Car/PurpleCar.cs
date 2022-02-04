using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleCar : MonoBehaviour
{
    [System.NonSerialized]
    public Car.CarColour purpleCarColour = Car.CarColour.Purple;

    private GameObject carUI;

    private bool isParked = false;
    public bool IsParked { set { isParked = true; } }

    private bool isProcessCompleted = false;        // It's a precaution to sent event once.

    private void OnEnable()
    {
        EventManager.OnSceneStart.AddListener( () => carUI.SetActive(false) );
    }

    private void OnDisable()
    {
        EventManager.OnSceneStart.RemoveListener( () => carUI.SetActive(false) );
    }

    private void Awake()
    {
        carUI = GetComponentInChildren<CarUI>().gameObject;
    }

    private void OnTriggerStay(Collider other)
    {
        bool isParkingGrid = other.gameObject.GetComponent<ParkingGrid>();

        if (!isParkingGrid || !isParked || isProcessCompleted) return;

        isProcessCompleted = true;

        if (purpleCarColour == other.gameObject.GetComponent<ParkingGrid>().gridColour)
        {
            EventManager.OnCarPlacedRightGrid?.Invoke();
            carUI.SetActive(true);
            carUI.GetComponent<CarUI>().SetUIRotation();
        }
        else
        {
            EventManager.OnLevelFail?.Invoke();
        }
    }
}
