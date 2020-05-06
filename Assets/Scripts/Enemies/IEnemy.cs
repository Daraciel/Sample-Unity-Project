using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEnemy : MonoBehaviour
{
    public Stats Stats;
    public string Name;
    public int ExperienceGiven;
    public GameObject PuffObject;

    public void SayName()
    {
        Debug.Log("Hi, I'm an enemy called " + Name);
    }

    public void GiveExperience()
    {
        GameManager.Instance.Player.GetComponent<ExperienceLevel>().AddExperience(ExperienceGiven);
    }
}
