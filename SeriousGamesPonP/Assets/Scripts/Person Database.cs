using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Person Database", menuName = "Databases/Person Database")]
public class PersonDatabase : ScriptableObject
{
    public List<string> FNames;
    public List<string> MNames;
    public List<string> LNames;
    public int[] ageRange = {15,80};
    public List<Sprite> ProfPic;
    
}
