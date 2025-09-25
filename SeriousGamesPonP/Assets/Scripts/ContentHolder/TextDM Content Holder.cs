using System;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class TextDMContentHolder : MonoBehaviour
{
    [Header("Database")]
    public ContentDatabase database;

    [Header("Randomization Settings")]
    public bool useRandom = true;

    [Header("UI Elements")]
    [SerializeField] private TMP_Text platformText;
    [SerializeField] private TMP_Text senderReceiverText;
    [SerializeField] private TMP_Text messageText;
    [SerializeField] private TMP_Text timestampText;

    void Update()
    {
        if (database == null || database.textMessages == null || database.textMessages.Count == 0)
        {
            ClearUI();
            return;
        }

        int idx = useRandom
            ? UnityEngine.Random.Range(0, database.textMessages.Count)
            : 0;

        var message = database.textMessages[idx];


        if (messageText != null)
            messageText.text = message.message;

        if (timestampText != null)
            timestampText.text = $"Date: {message.timestamp.ToString("g")}";
    }

    private void ClearUI()
    {
        if (platformText != null) platformText.text = "";
        if (senderReceiverText != null) senderReceiverText.text = "";
        if (messageText != null) messageText.text = "";
        if (timestampText != null) timestampText.text = "";
    }
}
