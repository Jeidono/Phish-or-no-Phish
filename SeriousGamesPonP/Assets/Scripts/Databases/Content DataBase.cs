using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Content Database", menuName = "Databases/Content Database")]
public class ContentDatabase : ScriptableObject
{
    [Serializable]
    public class AudioContent
    {
        public string id;          
        public AudioClip clip;       
        public string description;
        public float duration;     
    }

    [Serializable]
    public class EmailContent
    {
        public string id;
        public string from;        
        public string to;            
        public string subject;
        public string body;
        public DateTime timestamp;
    }

    [Serializable]
    public class TextDMContent
    {
        public string platform;
        public string id;
        public string sender;
        public string receiver; 
        public string message;        
        public DateTime timestamp;
    }

    // Lists for each type of content
    public List<AudioContent> audioItems = new List<AudioContent>();
    public List<EmailContent> emails = new List<EmailContent>();
    public List<TextDMContent> textMessages = new List<TextDMContent>();


}
