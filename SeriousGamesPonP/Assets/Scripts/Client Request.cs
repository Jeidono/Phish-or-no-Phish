using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClientRequest : MonoBehaviour
{
    public Sprite profilePic;
    public string clientName;
    public int age;
    public Email email;
    public Location location;
    public GameObject Content;

    [SerializeField] private Image Pic;
    [SerializeField] private TextMeshPro Name;
    [SerializeField] private TextMeshPro Age;
    [SerializeField] private TextMeshPro Location;
    [SerializeField] private GameObject ContentHolder;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
