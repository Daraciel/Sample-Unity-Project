using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEnemy : MonoBehaviour
{
    public Stats Stats;
    public string Name;
    public int ExperienceGiven;

    public void SayName()
    {
        Debug.Log("Hi, I'm an enemy called " + Name);
    }
}
