using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgressTracker : MonoBehaviour
{
    [SerializeField]
    private int totalGridCount;

    private int counter;

    private void OnEnable()
    {
        EventManager.OnCarPlacedRightGrid.AddListener( () => counter++ );
        EventManager.OnCarPlacedRightGrid.AddListener(CheckWinCondition);
    }

    private void OnDisable()
    {
        EventManager.OnCarPlacedRightGrid.RemoveListener( () => counter++ );
        EventManager.OnCarPlacedRightGrid.RemoveListener(CheckWinCondition);
    }

    private void CheckWinCondition()
    {
        if (counter == totalGridCount)
        {
            EventManager.OnLevelFinish?.Invoke();
        }
    }
}
