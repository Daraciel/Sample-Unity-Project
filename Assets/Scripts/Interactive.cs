using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactive : MonoBehaviour
{
    public UnityEvent OnInteraction;

    private Collider2D _collider;



    private void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision!!!");
        if(OnInteraction != null)
        {
            OnInteraction.Invoke();
        }
    }
}
