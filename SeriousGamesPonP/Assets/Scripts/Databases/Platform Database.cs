using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlatformDatabase", menuName = "Databases/Platform Database")]
public class PlatformDatabase : ScriptableObject
{
    public List<string> PlatformName;
    public List<Sprite> PlatformIcon;
}
