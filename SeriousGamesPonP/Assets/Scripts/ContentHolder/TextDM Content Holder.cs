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

    public string Platform;
    public string Sender;
    public string Receiver;
    public string Message;
    public DateTime Timestamp;

    void Update()
    {
        if (database == null || database.textMessages == null || database.textMessages.Count == 0)
        {
            ClearUI();
            return;
        }

        if (platformText != null)
            platformText.text = $"Platform: {Platform}";

        if (senderReceiverText != null)
            senderReceiverText.text = $"From: {Sender}\nTo: {Receiver}";

        if (messageText != null)
            messageText.text = Message;

        if (timestampText != null)
            timestampText.text = $"Date: {Timestamp}";
    }

    private void ClearUI()
    {
        if (platformText != null) platformText.text = "";
        if (senderReceiverText != null) senderReceiverText.text = "";
        if (messageText != null) messageText.text = "";
        if (timestampText != null) timestampText.text = "";
    }
}
