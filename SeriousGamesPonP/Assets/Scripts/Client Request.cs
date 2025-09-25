using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
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
    [SerializeField] public GameObject ContentHolder;

    private RectTransform ContCanv;
    private BoxCollider2D BC;
    private RectTransform myCanv;

    private Vector3 mouseOffset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Content)
        {
            ContCanv = Content.GetComponentInChildren<Canvas>().GetComponent<RectTransform>();
        }
        

        myCanv = gameObject.GetComponentInChildren<Canvas>().GetComponent<RectTransform>();
        BC = gameObject.AddComponent<BoxCollider2D>();
        BC.size = myCanv.rect.size;
    }

    private void OnMouseDown()
    {
        mouseOffset = transform.position -
                      Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + mouseOffset;
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
            Location.text = "Location:\n" + location.HouseNum + " " + location.StreetName + ",\n" +location.PostCode+", "+ location.Country;
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
        BC.size = myCanv.rect.size;
    }
}
