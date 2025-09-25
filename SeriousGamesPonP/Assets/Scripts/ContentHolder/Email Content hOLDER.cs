using System;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class EmailContentHolder : MonoBehaviour
{
    [Header("Database")]
    public ContentDatabase database;

    [Header("Randomization Settings")]
    public bool useRandom = true;

    [Header("UI Elements")]
    [SerializeField] private TMP_Text subjectText;
    [SerializeField] private TMP_Text fromText;
    [SerializeField] private TMP_Text toText;
    [SerializeField] private TMP_Text bodyText;
    [SerializeField] private TMP_Text timestampText;

    public string Subject;
    public string From;
    public string To;
    public string Body;
    public DateTime Timestamp;

    void Update()
    {
        if (database == null || database.emails == null || database.emails.Count == 0)
        {
            ClearUI();
            return;
        }

        if (subjectText != null)
            subjectText.text = $"Subject: {Subject}";

        if (fromText != null)
            fromText.text = $"From: {From}";

        if (toText != null)
            toText.text = $"To: {To}";

        if (bodyText != null)
            bodyText.text = Body;

        if (timestampText != null)
            timestampText.text = $"Date: {Timestamp}";
    }

    private void ClearUI()
    {
        if (subjectText != null) subjectText.text = "";
    
        if (bodyText != null) bodyText.text = "";
        if (timestampText != null) timestampText.text = "";
    }
}
