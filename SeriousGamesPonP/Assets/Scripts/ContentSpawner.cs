using System.Collections;
using System.Net;
using UnityEngine;
using Random = UnityEngine.Random;

public class ContentSpawner : MonoBehaviour
{
    [SerializeField] private ContentDatabase CD;
    [SerializeField] private PersonDatabase PB;
    [SerializeField] private LocationDatabase LB;
    [SerializeField] private PlatformDatabase PLB;
    [SerializeField] private ClientRequest CR;
    [SerializeField] private GameObject CHemail;
    [SerializeField] private GameObject CHdm;
    [SerializeField] private GameObject CHaudio;
    
    private string domainName;
    private string username;


    private void Start()
    {
        SpawnContentRoutine();
    }

    public void SpawnContentRoutine()
    {
        if (CR.Content) return;
        AssignPersonAndLocation();

        int type = Random.Range(1, 3);
        type = 2;
        GameObject contentObj = null;

        switch (type)
        {
            case 0: // Audio
                if (CD.audioItems.Count > 0)
                {
                    contentObj = Instantiate(CHaudio, CR.ContentHolder.transform);
                    AudioContentHolder ACH = contentObj.GetComponent<AudioContentHolder>();
                }
                break;
            case 1: // Email
                if (CD.emails.Count > 0)
                {
                    contentObj = Instantiate(CHemail, CR.ContentHolder.transform);
                    EmailContentHolder ECH = contentObj.GetComponent<EmailContentHolder>();
                    ECH.To = CR.email.username + "@" + CR.email.domainName + ".com";
                    ECH.From = username + "@" + domainName + ".com";
                    int emailIdx = Random.Range(0, CD.emails.Count);
                    ECH.Subject = CD.emails[emailIdx].subject;
                    ECH.Body = CD.emails[emailIdx].body;
                    ECH.Timestamp = CD.emails[emailIdx].timestamp; 

                }
                break;
            case 2: // TextDM
                if (CD.textMessages.Count > 0)
                {
                    contentObj = Instantiate(CHdm, CR.ContentHolder.transform);
                    TextDMContentHolder DCH = contentObj.GetComponent<TextDMContentHolder>();
                    int dmIdx = Random.Range(0, CD.textMessages.Count);
                    DCH.Sender = username;
                    DCH.Receiver = CR.email.username;
                    DCH.Message = CD.textMessages[dmIdx].message;
                    DCH.Timestamp = CD.textMessages[dmIdx].timestamp;
                }
                break;
        }

        if (contentObj != null && CR.Content != null)
        {
            contentObj.transform.SetParent(CR.Content.transform, false);
            CR.Content = contentObj;
        }

    }

    private void AssignPersonAndLocation() //bain of all my existence 
    {
        int cfName = Random.Range(0, PB.FNames.Count);
        int clName = Random.Range(0, PB.LNames.Count);
       // CR.clientName = PB.FNames[cfName] + " " + PB.LNames[clName];
        //CR.age = Random.Range(PB.ageRange[0], PB.ageRange[1]);
        username = PB.FNames[cfName];
        domainName = PLB.DomainName[Random.Range(0, PLB.DomainName.Count)];
//CR.email = new Email(username, domainName);
        int countryLoc = Random.Range(0, LB.Countries.Count);
       // CR.location = new Location(
           /* Random.Range(1, LB.maxStreetNumbers[Random.Range(0, LB.maxStreetNumbers.Count)]),
            LB.StreetNames[Random.Range(0, LB.StreetNames.Count)] + " " + LB.StreetTypes[Random.Range(0, LB.StreetTypes.Count)],
            countryLoc * LB.postCodeGap + Random.Range(0, LB.postCodeGap),
            LB.Countries[countryLoc]
        );*/
    }
}