using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Items/BaseItem")]
public class Item : ScriptableObject
{
    public Sprite Artwork;
    public string Name;
    public bool Stackable;

    [TextArea(1, 3)]
    public string Description;

    public virtual bool Use()
    {
        bool result = true;
        Debug.Log("Trying to use " + Name);
        return result;
    }
}
