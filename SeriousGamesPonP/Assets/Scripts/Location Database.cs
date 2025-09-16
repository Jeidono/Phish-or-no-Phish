using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Location Database", menuName = "Databases/Location Database")]
public class LocationDatabase : ScriptableObject
{
    public List<string> Countries;
    public int postCodeGap;
    public List<string> StreetNames;
    public List<int> maxStreetNumbers;
    public List<streetType> StreetTypes;

    public enum streetType
    {
        Street,
        Avenue,
        Lane,
        Boulevard,
        Crescent,
        Road,
        Grove
    }
}
