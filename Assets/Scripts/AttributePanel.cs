using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttributePanel : MonoBehaviour
{
    public static AttributePanel Instance;

    public TextMeshProUGUI lblLevel;
    public TextMeshProUGUI lblExperience;
    public TextMeshProUGUI lblHealth;
    public TextMeshProUGUI lblMana;
    public TextMeshProUGUI lblAttack;
    public TextMeshProUGUI lblSpeed;
    public TextMeshProUGUI lblAttributePoints;

    public void UpdateLabels(Stats stats, Health health, ExperienceLevel expLevel)
    {
        lblLevel.text = expLevel.CurrentLevel.ToString();
        lblExperience.text = string.Format("{0}/{1}", expLevel.CurrentExp.ToString(), expLevel.NextLevelExperience.ToString());
        lblHealth.text = health.MaxHealth.ToString();
        lblMana.text = "-";
        lblAttack.text = stats.Attack.ToString();
        lblSpeed.text = stats.Speed.ToString();
        lblAttributePoints.text = expLevel.AttributePoints.ToString();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
