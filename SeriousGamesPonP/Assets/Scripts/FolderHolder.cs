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
    public Animator animator;
    public void LoadAndMoveObject(GameObject cr)
    {
        animator.SetTrigger("Open");
        animator.SetTrigger("Close");
        LoadSceneAndMoveObjectCoroutine(cr);
    }

    private void Start()
    {
        if(!SceneManager.GetSceneByName(targetSceneName).isLoaded)
            StartCoroutine(onloadingScene(SceneManager.LoadSceneAsync(targetSceneName, LoadSceneMode.Additive)));
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    private void Awake()
    {
        GetClicks = 0;
        animator = gameObject.GetComponentInChildren<Animator>();
        animator.SetTrigger("Close");
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
        GetClicks=0;
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
            GetClicks=0;
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
        if(GetClicks==1)
            animator.SetTrigger("Open");
        yield return new WaitForSeconds(sceneTransitionSensitivity);
        GetClicks--;
        if(GetClicks == 0)
            animator.SetTrigger("Close");
    }
}
