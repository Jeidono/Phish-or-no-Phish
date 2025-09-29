using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FolderHolder : MonoBehaviour
{
    public string targetSceneName;
    private int GetClicks=0;
    [SerializeField] private float sceneTransitionSensitivity=0.5f;
    public void LoadAndMoveObject(GameObject cr)
    {
        LoadSceneAndMoveObjectCoroutine(cr);
    }

    private void Start()
    {
        if(!SceneManager.GetSceneByName(targetSceneName).isLoaded)
            StartCoroutine(onloadingScene(SceneManager.LoadSceneAsync(targetSceneName, LoadSceneMode.Additive)));
    }

    IEnumerator onloadingScene(AsyncOperation async)
    {
        while (!async.isDone)
        {
            yield return null;
        }
        foreach (GameObject rootObj in SceneManager.GetSceneByName(targetSceneName).GetRootGameObjects())
        {
            rootObj.SetActive(false);
        }
    }

    void LoadSceneAndMoveObjectCoroutine(GameObject objectToMove)
    {
        // Load the target scene additively

        // Wait until the scene is fully loaded

        // Get a reference to the newly loaded scene
        Scene targetScene = SceneManager.GetSceneByName(targetSceneName);
        
        
        // Move the GameObject to the target scene
        SceneManager.MoveGameObjectToScene(objectToMove, targetScene);
        objectToMove.SetActive(false);
        // Optionally, unload the previous scene if no longer needed
    }

    private void OnMouseUp()
    {
        GetClicks++;
        StartCoroutine(IMAREDUCECLICKS());
        if (GetClicks > 1)
        {
            foreach (GameObject rootObj in SceneManager.GetActiveScene().GetRootGameObjects())
            {
                rootObj.SetActive(false);
            }

            SceneManager.SetActiveScene(SceneManager.GetSceneByName(targetSceneName));
            foreach (GameObject rootObj in SceneManager.GetActiveScene().GetRootGameObjects())
            {
                rootObj.SetActive(true);
            }
        }
    }

    IEnumerator IMAREDUCECLICKS()
    {
        yield return new WaitForSeconds(sceneTransitionSensitivity);
        GetClicks--;
    }
}
