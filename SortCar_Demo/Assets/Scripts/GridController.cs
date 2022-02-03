using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    private bool[] yellowCarGrids;

    private bool[] purpleCarGrids;

    private int purpleGridPosition, yellowGridPosition;

    public int PurpleCarGridPosition { get { return purpleGridPosition; } }

    public int YellowCarGridPosition { get { return yellowGridPosition; } }


    void Start()
    {
        purpleCarGrids = new bool[7];
        yellowCarGrids = new bool[9];
    }

    private void FindPositionForPurpleCar()
    {
        for (int i = 0; i < purpleCarGrids.Length; i++)
        {
            if (purpleCarGrids[i] == false)
            {
                purpleGridPosition = i;
                purpleCarGrids[i] = true;
                CheckCommonGridsOfPurple(i);
                break;
            }
        }
    }

    private void FindPositionForYellowCar()
    {
        for (int i = 0; i < yellowCarGrids.Length; i++)
        {
            if (yellowCarGrids[i] == false)
            {
                yellowGridPosition = i;
                yellowCarGrids[i] = true;
                CheckCommonGridsOfYellow(i);
                break;
            }
        }
    }

    private void CheckCommonGridsOfPurple(int index)
    {
        switch (index)
        {
            case 0:
                yellowCarGrids[4] = true;
                break;
            case 1:
                yellowCarGrids[5] = true;
                break;
            case 2:
                yellowCarGrids[0] = true;
                break;
            case 3:
                yellowCarGrids[1] = true;
                break;
            case 4:
                yellowCarGrids[6] = true;
                break;
            case 5:
                yellowCarGrids[7] = true;
                break;
            case 6:
                yellowCarGrids[8] = true;
                break;
        }
    }

    private void CheckCommonGridsOfYellow(int index)
    {
        switch (index)
        {
            case 0:
                purpleCarGrids[2] = true;
                break;
            case 1:
                purpleCarGrids[3] = true;
                break;
            case 4:
                purpleCarGrids[0] = true;
                break;
            case 5:
                purpleCarGrids[1] = true;
                break;
            case 6:
                purpleCarGrids[4] = true;
                break;
            case 7:
                purpleCarGrids[5] = true;
                break;
            case 8:
                purpleCarGrids[6] = true;
                break;
        }
    }
}
