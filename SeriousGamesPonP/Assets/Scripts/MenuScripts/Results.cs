using System;
using TMPro;
using UnityEngine;

public class Results : MonoBehaviour
{
    public TMP_Text Phish;
    public TMP_Text NoPhish;
    public TMP_Text Winning;
    public static int PhishNums;
    public static int NoPhishNums;
    public static int PhishResl;
    public static int NoPhishResl;

    private void Start()
    {
        Phish.text = PhishResl + "/" + PhishNums;
        NoPhish.text = NoPhishResl + "/" + NoPhishNums;
    }
}
