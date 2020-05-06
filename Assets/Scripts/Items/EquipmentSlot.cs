using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSlot : Slot
{
    public EquipmentTypes EquipmentType;


    protected override void UseObject()
    {
        UnequipObject();
    }

    private void UnequipObject()
    {
        if(!Inventory.Instance.IsFull)
        {
            Inventory.Instance.AddItem(Item, Amount);
            RemoveObject();
        }
    }

    private void RemoveObject()
    {
        EquipmentPanel.Instance.UnequipItem((IEquipable)Item);
        removeInnerItem();
    }
}
