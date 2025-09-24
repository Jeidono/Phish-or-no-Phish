using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class RequestSpawner : MonoBehaviour
{
    [SerializeField] private PersonDatabase PB;
    [SerializeField] private LocationDatabase LB;
    [SerializeField] private PlatformDatabase PLB;
    [SerializeField] private GameObject requestTemplate;
    [SerializeField] private Vector3 spawnLoc;
    [SerializeField] private bool spawn=false;
    [SerializeField] private int Requests = 5;

    public void Update()
    {
        if (spawn)
        {
            spawn = false;
            StartCoroutine(RequestMaker(Requests));
        }
    }

    public IEnumerator RequestMaker(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject RQthingy = Instantiate(requestTemplate, Vector3.zero, Quaternion.identity);
            ClientRequest CRthingy = RQthingy.GetComponent<ClientRequest>();
            int cfName = Random.Range(0, PB.FNames.Count);
            int clName = Random.Range(0, PB.LNames.Count);
            CRthingy.clientName = PB.FNames[cfName] + " " + PB.LNames[clName];
            CRthingy.age = Random.Range(PB.ageRange[0], PB.ageRange[1]);
            CRthingy.email = new Email(PB.FNames[cfName], PLB.DomainName[Random.Range(0, PLB.DomainName.Count)]);
            //CRthingy.profilePic = PB.ProfPic[Random.Range(0, PB.ProfPic.Count)];
            int countryLoc = Random.Range(0, LB.Countries.Count);
            CRthingy.location = new Location(Random.Range(1, LB.maxStreetNumbers[Random.Range(0, LB.maxStreetNumbers.Count)]),
                LB.StreetNames[Random.Range(0, LB.StreetNames.Count)] + " " + LB.StreetTypes[Random.Range(0, LB.StreetTypes.Count)],
                countryLoc * LB.postCodeGap + Random.Range(0, LB.postCodeGap), LB.Countries[countryLoc]);
            StartCoroutine(positionMoving(RQthingy));
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator positionMoving(GameObject Requests)
    {
        Vector3 startLoc=spawnLoc;
        float aspect = (float)Screen.width / Screen.height;
        float worldHeight = FindAnyObjectByType<Camera>().orthographicSize * 2;
        float worldWidth = worldHeight * aspect;
        Vector3 endLoc=new Vector3(Random.Range(-worldWidth/2,worldWidth/2)/2,Random.Range(-worldHeight/2,worldHeight/2)/2);
        for (float i = 0; i < 1; i += Time.deltaTime*4)
        {
            Requests.transform.position = Vector3.Lerp(startLoc,endLoc,i);
            yield return null;
        }
    }
}
