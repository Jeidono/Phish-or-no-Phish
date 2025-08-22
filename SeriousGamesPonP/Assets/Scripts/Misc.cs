using System;
using UnityEngine;
[Serializable]
public struct Location
{
    public int HouseNum;
    public string StreetName;
    public string Suburb;
    public string Country;
}
[Serializable]
public struct Email
{
    public string username;
    public string domainName;
}