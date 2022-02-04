using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    #region Level Events
    public static UnityEvent OnSceneStart = new UnityEvent();
    public static UnityEvent OnLevelStart = new UnityEvent();
    public static UnityEvent OnLevelFail = new UnityEvent();
    public static UnityEvent OnLevelFinish = new UnityEvent();
    public static UnityEvent OnSceneFinish = new UnityEvent();
    #endregion

    #region Button Events
    public static UnityEvent OnPurpleButtonPressed = new UnityEvent();
    public static UnityEvent OnYellowButtonPressed = new UnityEvent();
    #endregion

    #region Grid Events
    public static GridEvent OnGridFoundForPurpleCar = new GridEvent();
    public static GridEvent OnGridFoundForYellowCar = new GridEvent();
    #endregion

    #region Level Events
    public static UnityEvent OnCarPlacedRightGrid = new UnityEvent();
    #endregion
}
public class GridEvent: UnityEvent<int> { }
