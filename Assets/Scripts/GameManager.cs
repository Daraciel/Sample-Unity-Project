using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform PlayerSpawnPoint;
    public GameObject Player;


    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        getPlayerObject();
    }

    #region PRIVATE METHODS

    private void getPlayerObject()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if(Player != null)
        {
            Player.transform.position = PlayerSpawnPoint.position;
            Debug.Log("Player found");
        }
        else
        {
            Debug.Log("Player not found");
        }
    }

    #endregion
}
