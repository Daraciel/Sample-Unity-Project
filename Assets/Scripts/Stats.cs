using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Stats")]
public class Stats : ScriptableObject
{
    public int Speed
    {
        get
        {
            return baseSpeed + speedModifier;
        }
    }

    public int Attack
    {
        get
        {
            return baseAttack + attackModifier;
        }
    }

    

    [Tooltip("Velocidad de movimiento")]
    [SerializeField]
    private int baseSpeed;
    private int speedModifier;

    [SerializeField]
    private int baseAttack;
    private int attackModifier;


    public void ModifyBaseSpeed(int amount)
    {
        baseSpeed += amount;
    }

    public void ModifyBaseAttack(int amount)
    {
        baseAttack += amount;
    }

    public void UpdateEquipmentModifiers(List<IEquipable> equipment)
    {
        speedModifier = 0;
        attackModifier = 0;
        GameManager.Instance.Player.GetComponent<Health>().HealthModifier = 0;
        foreach (IEquipable item in equipment)
        {
            speedModifier += item.SpeedBonus;
            attackModifier += item.AttackBonus;
            GameManager.Instance.Player.GetComponent<Health>().HealthModifier += item.HealthBonus;
        }

        AttributePanel.Instance.UpdateLabels(this,
            GameManager.Instance.Player.GetComponent<Health>(),
            GameManager.Instance.Player.GetComponent<ExperienceLevel>());
            GameManager.Instance.Player.GetComponent<Health>().UpdateHealthBar();
    }
}
