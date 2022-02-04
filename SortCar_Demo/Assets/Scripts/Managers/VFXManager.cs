using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    [SerializeField]
    private GameObject confettiVFX;

    private void OnEnable()
    {
        EventManager.OnSceneStart.AddListener( () => confettiVFX.SetActive(false) );
        EventManager.OnLevelFinish.AddListener( () => confettiVFX.SetActive(true) );
    }

    private void OnDisable()
    {
        EventManager.OnSceneStart.RemoveListener( () => confettiVFX.SetActive(false) );
        EventManager.OnLevelFinish.RemoveListener( () => confettiVFX.SetActive(true) );
    }
}
