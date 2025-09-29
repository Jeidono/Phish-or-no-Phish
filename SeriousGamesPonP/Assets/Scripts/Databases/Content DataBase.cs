using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Content Database", menuName = "Databases/Content Database")]
public class ContentDatabase : ScriptableObject
{
    [Serializable]
    public class AudioContent
    {
        public AudioClip clip;
        public string description;
        public float duration; 
        public bool isPhishing;  
    }

    [Serializable]
    public class EmailContent
    {
        public string subject;
        public string body;
        public DateTime timestamp;
        public bool isPhishing;  
    }

    [Serializable]
    public class TextDMContent
    {
        public string message;
        public DateTime timestamp;
        public bool isPhishing;  
    }

    // Lists for each type of content
    public List<AudioContent> audioItems = new List<AudioContent>();
    public List<EmailContent> emails = new List<EmailContent>();
    public List<TextDMContent> textMessages = new List<TextDMContent>();


}
