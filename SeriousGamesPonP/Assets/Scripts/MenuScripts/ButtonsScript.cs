using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{
    public void RestartScene()
    {
        SceneManager.LoadScene("Level");
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ToResultScreen()
    {
        Results.PhishNums = 0;
        Results.NoPhishNums = 0;
        Results.PhishResl = 0;
        Results.NoPhishResl = 0;
        GameObject[] Phishes=SceneManager.GetSceneByName("Phish").GetRootGameObjects();
        GameObject[] NoPhishes=SceneManager.GetSceneByName("No Phish").GetRootGameObjects();
        GameObject[] MainLvl=SceneManager.GetSceneByName("Level").GetRootGameObjects();
        foreach (GameObject phish in Phishes)
        {
            ContentSpawner CS =phish.GetComponentInChildren<ContentSpawner>();
            if (!CS)
            {
                continue;
            }

            if (CS.Phishing)
            {
                Results.PhishNums++;
                Results.PhishResl++;
            }
            else
            {
                Results.NoPhishNums++;
            }

        }
        foreach (GameObject nophish in NoPhishes)
        {
            ContentSpawner CS =nophish.GetComponentInChildren<ContentSpawner>();
            if (!CS)
            {
                continue;
            }
            if (CS.Phishing)
            {
                Results.PhishNums++;
            }
            else
            {
                Results.NoPhishNums++;
                Results.NoPhishResl++;
            }

        }
        foreach (GameObject lvl in MainLvl)
        {
            ContentSpawner CS =lvl.GetComponentInChildren<ContentSpawner>();
            if (!CS)
            {
                continue;
            }

            if (CS.Phishing)
            {
                Results.PhishNums++;
            }
            else
            {
                Results.NoPhishNums++;
            }

        }

        SceneManager.LoadScene("Result");
    }

    public void RestartAllScenes()
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene != SceneManager.GetActiveScene())
            {
                SceneManager.UnloadSceneAsync(scene);
            }
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void mainmenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}