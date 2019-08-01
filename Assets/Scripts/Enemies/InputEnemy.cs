using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEnemy : MonoBehaviour
{
    public float Vertical { get { return PlayerDirection.y; } }
    public float Horizontal { get { return PlayerDirection.x; } }
    public float Distance { get { return PlayerDirection.magnitude; } }
    public Vector2 PlayerDirection { get; private set; }

    private Transform _playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        _playerPosition = GameManager.Instance.Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDirection = _playerPosition.position - this.transform.position;
    }
}
