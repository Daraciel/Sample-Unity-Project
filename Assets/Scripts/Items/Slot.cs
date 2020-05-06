using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerDownHandler
{
    public int Amount;
    public Item Item;
    public Image Sprite;

    private void Awake()
    {
        Sprite = GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        UseObject();
    }

    public void AddItem(Item item, int amount)
    {
        Item = item;
        Sprite.enabled = true;
        Sprite.sprite = item.Artwork;
        Amount = amount;
    }

    public void RemoveItem()
    {
        Inventory.Instance.RemoveItem(Item);
        removeInnerItem();
    }

    protected void removeInnerItem()
    {
        Item = null;
        Sprite.enabled = false;
        Sprite.sprite = null;
        Amount = 0;
    }

    protected virtual void UseObject()
    {
        if(Item != null)
        {
            if(Item.Use())
            {
                Amount--;
            }

            if (Amount <= 0)
            {
                RemoveItem();
            }
        }
        else
        {
            Debug.Log("Object is null");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Item == null)
        {
            Sprite.enabled = false;
        }
        else
        {
            Sprite.enabled = true;
        }
    }
}
