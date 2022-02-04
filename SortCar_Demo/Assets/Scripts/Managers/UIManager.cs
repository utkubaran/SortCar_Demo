using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject levelFinishPanel;

    [SerializeField]
    private GameObject levelFailPanel;

    private void OnEnable()
    {
        EventManager.OnSceneStart.AddListener( () => levelFinishPanel.SetActive(false) );
        EventManager.OnSceneStart.AddListener( () => levelFailPanel.SetActive(false) );

        EventManager.OnLevelFail.AddListener( () => levelFailPanel.SetActive(true) );

        EventManager.OnLevelFinish.AddListener( () => levelFinishPanel.SetActive(true) );
    }

    private void OnDisable()
    {
        EventManager.OnSceneStart.RemoveListener( () => levelFinishPanel.SetActive(false) );
        EventManager.OnSceneStart.RemoveListener( () => levelFailPanel.SetActive(false) );

        EventManager.OnLevelFail.RemoveListener( () => levelFailPanel.SetActive(true) );

        EventManager.OnLevelFinish.RemoveListener( () => levelFinishPanel.SetActive(true) );
    }

    public void PressNextLevelButton()
    {
        EventManager.OnNextLevelButtonPressed?.Invoke();
    }

    public void PressRetryButton()
    {
        EventManager.OnRetryButtonPressed?.Invoke();
    }
}
