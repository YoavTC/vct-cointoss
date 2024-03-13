using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Team Instance")]
public class Team : ScriptableObject
{
    public string teamName;
    public Sprite teamLogo;
    public Sprite coinLogo;
    public Color backgroundColor;
}
