using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int currentSceneIndex;

    private void OnEnable()
    {
        EventManager.OnNextLevelButtonPressed.AddListener(LoadNextLevel);
        EventManager.OnRetryButtonPressed.AddListener(LoadSameLevel);
    }

    private void OnDisable()
    {
        EventManager.OnNextLevelButtonPressed.RemoveListener(LoadNextLevel);
        EventManager.OnRetryButtonPressed.RemoveListener(LoadSameLevel);
    }

    void Start()
    {
        EventManager.OnSceneStart?.Invoke();
    }

    private void LoadNextLevel()
    {
        // todo refactor when new level is added
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void LoadSameLevel()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }
}
