using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
  // Start is called once before the first execution of Update after the MonoBehaviour is created

  public void Play()
  {
    UnityEngine.SceneManagement.SceneManager.LoadScene("Level");
  }
  
      public void HowToPlay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("HowToPlay");
  }
}
