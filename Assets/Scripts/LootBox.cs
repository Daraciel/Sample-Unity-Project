using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootBox : MonoBehaviour
{
    public Sprite OpenLootSprite;
    public Sprite ClosedLootSprite;

    private Image myImage;

    public bool IsClosed;
    // Start is called before the first frame update
    void Start()
    {
        myImage = GetComponent<Image>();
        setCorrectSprite();
    }

    public void OpenClose()
    {
        IsClosed = !IsClosed;
        setCorrectSprite();
    }

    private void setCorrectSprite()
    {
        if(myImage != null)
        {
            if (IsClosed)
            {
                myImage.sprite = ClosedLootSprite;
            }
            else
            {
                myImage.sprite = OpenLootSprite;
            }
        }
    }
}
