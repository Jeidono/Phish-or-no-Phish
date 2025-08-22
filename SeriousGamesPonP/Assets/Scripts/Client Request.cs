using TMPro;
using UnityEngine;
using UnityEngine.UI;
[ExecuteAlways]
public class ClientRequest : MonoBehaviour
{
    public Sprite profilePic;
    public string clientName;
    public int age;
    public Email email;
    public Location location;
    public GameObject Content;

    [SerializeField] private Image Pic;
    [SerializeField] private TMP_Text Name;
    [SerializeField] private TMP_Text Age;
    [SerializeField] private TMP_Text Location;
    [SerializeField] private GameObject ContentHolder;

    private RectTransform ContCanv;

    private RectTransform myCanv;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Content)
        {
            ContCanv = Content.GetComponentInChildren<Canvas>().GetComponent<RectTransform>();
        }

        myCanv = gameObject.GetComponentInChildren<Canvas>().GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Pic&&profilePic)
        {
            Pic.sprite = profilePic;
        }

        if (Name)
        {
            Name.text = clientName;
        }

        if (Age)
        {
            Age.text = "Age: " + age;
        }

        if (Location)
        {
            Location.text = "Location:\n" + location.HouseNum + " " + location.StreetName + ",\n" + location.Suburb +
                            ",\n" + location.Country;
        }

        if (ContentHolder && Content)
        {
            if (ContCanv.sizeDelta.x > 48)
            {
                myCanv.sizeDelta = new Vector2(ContCanv.sizeDelta.x + 2,ContCanv.sizeDelta.y+10);
            }
            else
            {
                myCanv.sizeDelta = new Vector2(50,ContCanv.sizeDelta.y+10);
            }
        }
    }
}
