using System;
using UnityEngine;
[Serializable]
public struct Location
{
    public int HouseNum;
    public string StreetName;
    public string Country;
}
[Serializable]
public struct Email
{
    public string username;
    public string domainName;
}

public class Person
{
    public string FName { get; private set;}
    public string MName { get; private set;}
    public string LName { get; private set;}
    public int Age { get; private set;}
    
}