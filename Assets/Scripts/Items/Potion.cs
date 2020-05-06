using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Items/Potions/Health")]
public class Potion : Item
{
    public int Amount;

    public override bool Use()
    {
        bool result = false;
        base.Use();
        Health playerHealth = GameManager.Instance.Player.GetComponent<Health>();

        if(playerHealth.MaxHealth > playerHealth.CurrentHealth)
        {
            playerHealth.ReceiveDamage(-Amount);
            result = true;
        }

        return result;
    }
}
