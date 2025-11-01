using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private static MusicManager _instance;
    private AudioSource _audioSource;

    void Awake()
    {
        // If an instance already exists and it's not this one, destroy this object
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Set this as the singleton instance
        _instance = this;

        // Make sure this object isn’t destroyed when loading new scenes
        DontDestroyOnLoad(gameObject);

        // Get (or add) the AudioSource component
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
            // configure defaults if needed: loop = true, volume, etc
            _audioSource.loop = true;
        }

        // If not already playing, start playing
        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }

        // Subscribe to scene loaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Example: change clip depending on scene name
        // You can use this to switch music, fade in/out, etc.
        // e.g.:
        // if (scene.name == "MainMenu")
        // {
        //     _audioSource.clip = menuClip;
        //     _audioSource.Play();
        // }
        // else if (scene.name == "Gameplay")
        // {
        //     _audioSource.clip = gameplayClip;
        //     _audioSource.Play();
        // }

        // If you don’t want to change music, leave blank.
    }

    void OnDestroy()
    {
        // Clean up subscription
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
