using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurplePathController : MonoBehaviour
{
    [System.Serializable]
    public class Path 
    {
        public GameObject[] waypoints;
    }

    [SerializeField]
    private List<Path> purpleCarPaths = new List<Path>();

    // [SerializeField]
    // public Dictionary<int, List<GameObject>> purpleCarPaths = new Dictionary<int, List<GameObject>> ();

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
