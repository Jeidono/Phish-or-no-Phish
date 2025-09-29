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
}