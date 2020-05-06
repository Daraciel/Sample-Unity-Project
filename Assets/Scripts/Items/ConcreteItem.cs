using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public class ConcreteItem : Interactive
{
    public Item Item;

    public int Amount = 1;

    private SpriteRenderer _spriteRenderer;

    private BoxCollider2D _boxCollider;

    private void OnValidate()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if(Item != null)
        {
            gameObject.name = Item.Name;
            _spriteRenderer.sprite = Item.Artwork;
        }
    }

    protected override void initializeComponents()
    {
        base.initializeComponents();
        _boxCollider = GetComponent<BoxCollider2D>();
        _spriteRenderer.sortingLayerName = "Drop";
        _collider.isTrigger = true;
        _collider.size = new Vector2(1, 1);
        gameObject.layer = 8;
    }

    // Start is called before the first frame update
    void Start()
    {
        initializeComponents();
    }

    public override void Interact()
    {
        Debug.Log("Interacting with " + Item.Name + "(item)");
        if(Inventory.Instance.AddItem(Item, Amount))
        {
            Debug.Log("Added to inventory");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Not Added to inventory");
        }
    }
}
