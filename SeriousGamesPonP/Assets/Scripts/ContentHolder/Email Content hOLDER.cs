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
    [SerializeField] private TMP_Text fromToText;
    [SerializeField] private TMP_Text bodyText;
    [SerializeField] private TMP_Text timestampText;

    void Update()
    {
        if (database == null || database.emails == null || database.emails.Count == 0)
        {
            ClearUI();
            return;
        }

        int idx = useRandom
            ? UnityEngine.Random.Range(0, database.emails.Count)
            : 0;

        var email = database.emails[idx];

        if (subjectText != null)
            subjectText.text = $"Subject: {email.subject}";

        if (fromToText != null)
            fromToText.text = $"From: {email.from}\nTo: {email.to}";

        if (bodyText != null)
            bodyText.text = email.body;

        if (timestampText != null)
            timestampText.text = $"Date: {email.timestamp.ToString("g")}";
    }

    private void ClearUI()
    {
        if (subjectText != null) subjectText.text = "";
        if (fromToText != null) fromToText.text = "";
        if (bodyText != null) bodyText.text = "";
        if (timestampText != null) timestampText.text = "";
    }
}
