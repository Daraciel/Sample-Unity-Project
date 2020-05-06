using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool IsFull;
    public static Inventory Instance;

    private Slot[] slots;
    private List<Item> items;
    private int firstEmptySlot;

    public void Awake()
    {
        Instance = this;
        items = new List<Item>();
        slots = GetComponentsInChildren<Slot>();
        Debug.Log("There is " + slots.Length + " slots");
    }

    public void GetNextEmptySlot()
    {
        firstEmptySlot = 0;
        while(slots[firstEmptySlot].Item!= null)
        {
            firstEmptySlot++;
        }

        if(firstEmptySlot >= slots.Length)
        {
            IsFull = true;
        }
    }

    public bool AddItem(Item item, int amount)
    {
        bool result = false;
        int destinySlot = 0;
        Slot newSlot = null;
        GetNextEmptySlot();
        destinySlot = firstEmptySlot;
        Debug.Log("Destiny slot is " + destinySlot);
        if (!IsFull)
        {
            if(item.Stackable && items.Contains(item))
            {
                Debug.Log("Stack It");
                for (int i = 0; i < slots.Length; i++)
                {
                    if(item == slots[i].Item)
                    {
                        slots[i].Amount += amount;
                        result = true;
                        break;
                    }
                }
            }
            else
            {
                Debug.Log("New item in inventory");
                newSlot = slots[destinySlot];
                items.Add(item);
                newSlot.AddItem(item, amount);
                result = true;
            }
        }
        else
        {
            Debug.Log("Inventory is full");
        }
        
        return result;
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }
}
