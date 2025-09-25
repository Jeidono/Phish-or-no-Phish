using System;
using UnityEngine;
[Serializable]
public struct Location
{
    public Location(int Num,string Name,int postcode, string country)
    {
        HouseNum = Num;
        StreetName = Name;
        PostCode = postcode;
        Country = country;
    }

    public int HouseNum;
    public string StreetName;
    public int PostCode;
    public string Country;
}
[Serializable]
public struct Email
{
    public Email(string Username, string DomainName)
    {
        username = Username;
        domainName = DomainName;
    }

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