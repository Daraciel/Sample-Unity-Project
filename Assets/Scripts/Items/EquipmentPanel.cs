using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentPanel : MonoBehaviour
{
    public static EquipmentPanel Instance;
    public Stats PlayerStats;
    public EquipmentSlot[] EquipmentSlots;
    public List<IEquipable> Equipments = new List<IEquipable>();

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        EquipmentSlots = GetComponentsInChildren<EquipmentSlot>();

    }

    public IEquipable EquipItem(IEquipable item)
    {
        IEquipable result = null;

        foreach(EquipmentSlot slot in EquipmentSlots)
        {
            if(slot.EquipmentType == item.EquipmentType)
            {
                if(slot.Item == null)
                {
                    Debug.Log("Slot is empty");
                }
                else
                {
                    Debug.Log("Slot is NOT empty");
                    result = removeItem(slot);
                }
                equipItem(item, slot);
                PlayerStats.UpdateEquipmentModifiers(Equipments);
                break;
            }
        }

        return result;
    }

    public void UnequipItem(IEquipable item)
    {
        foreach(EquipmentSlot slot in EquipmentSlots)
        {
            if (slot.EquipmentType == item.EquipmentType)
            {
                if (slot.Item == item)
                {
                    removeItem(slot);
                    PlayerStats.UpdateEquipmentModifiers(Equipments);
                    break;
                }
            }
        }
    }

    private IEquipable removeItem(EquipmentSlot slot)
    {
        IEquipable result = null;

        result = (IEquipable)slot.Item;
        Equipments.Remove(result);

        return result;
    }

    private void equipItem(IEquipable item, EquipmentSlot slot)
    {
        slot.AddItem(item, 1);
        Equipments.Add(item);
        //Equip item in stats
    }
}
