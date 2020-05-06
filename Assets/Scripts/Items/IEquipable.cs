using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Items/EquipmentBase")]
public class IEquipable : Item
{
    public EquipmentTypes EquipmentType;
    public int HealthBonus;
    public int AttackBonus;
    public int SpeedBonus;

    public override bool Use()
    {
        bool result = false;
        IEquipable equipedItem = null;

        equipedItem = EquipmentPanel.Instance.EquipItem(this);
        Inventory.Instance.RemoveItem(this);
        if (equipedItem != null)
        {
            Inventory.Instance.AddItem(equipedItem, 1);
        }
        result = true;
        //Equip or Unequip
        //return base.Use();

        return result;
    }

}
