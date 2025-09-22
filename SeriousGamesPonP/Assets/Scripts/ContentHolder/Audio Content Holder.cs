using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[ExecuteAlways]
public class AudioContentHolder : MonoBehaviour
{
    [Header("Database")]
    public ContentDatabase database;

    [Header("Randomization Settings")]
    public bool useRandom = true;

    [Header("UI Elements")]
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private TMP_Text durationText;
    [SerializeField] private AudioSource audioSource;

    void Update()
    {
        if (database == null || database.audioItems == null || database.audioItems.Count == 0)
        {
            ClearUI();
            return;
        }

        int idx = useRandom
            ? UnityEngine.Random.Range(0, database.audioItems.Count)
            : 0;

        var audio = database.audioItems[idx];

        if (descriptionText != null)
            descriptionText.text = $"Description: {audio.description}";

        if (durationText != null)
            durationText.text = $"Duration: {audio.duration} sec";

        if (audioSource != null && audio.clip != null)
            audioSource.clip = audio.clip;
    }

    private void ClearUI()
    {
        if (descriptionText != null) descriptionText.text = "";
        if (durationText != null) durationText.text = "";
        if (audioSource != null) audioSource.clip = null;
    }
}
