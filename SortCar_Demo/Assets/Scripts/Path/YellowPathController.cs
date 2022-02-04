using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPathController : MonoBehaviour
{
    [SerializeField]
    private List<Path> yellowCarPaths = new List<Path>();

    public List<Path> YellowCarPaths { get { return yellowCarPaths; } }

    #region Singleton
    public static YellowPathController instance;
    private void Awake()
    {
        if (instance != null) return;
        
        instance = this;
    }
    #endregion
}
