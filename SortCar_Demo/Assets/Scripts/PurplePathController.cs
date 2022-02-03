using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurplePathController : MonoBehaviour
{
    [SerializeField]
    private List<Path> purpleCarPaths = new List<Path>();

    public List<Path> PurpleCarPaths { get { return purpleCarPaths; } }

    #region Singleton
    public static PurplePathController instance;
    private void Awake()
    {
        if (instance != null) return;
        
        instance = this;
    }
    #endregion
}
