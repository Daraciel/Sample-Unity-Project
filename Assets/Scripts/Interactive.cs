using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Interactive : MonoBehaviour, IPointerDownHandler
{
    public UnityEvent OnInteraction;

    protected PlayerController _player;

    protected BoxCollider2D _collider;



    private void Start()
    {
        initializeComponents();
    }

    protected virtual void initializeComponents()
    {
        _collider = GetComponent<BoxCollider2D>();
        _player = GameManager.Instance.Player.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision!!!");
        if(OnInteraction != null)
        {
            OnInteraction.Invoke();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Done click!");
        TryInteract();
    }

    protected void TryInteract()
    {
        RaycastHit2D[] collisions;
        if(_player != null)
        {
            collisions = _player.Interact();
            if (collisions != null)
            {
                Debug.Log("detected " + collisions.Length + " collisions");
                foreach (RaycastHit2D collision in collisions)
                {
                    if (collision.collider.gameObject == this.gameObject)
                    {
                        Interact();
                        break;
                    }
                }
            }
            else
            {
                Debug.Log("No collisions");
            }
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interacted with " + this.gameObject.name);
    }
}
