using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairway : MonoBehaviour
{
    public LevelHandler LevelHandler;

    private Collider2D _collider;


    private void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision!!!");
        LevelHandler.LoadNextLevel();
    }
}
