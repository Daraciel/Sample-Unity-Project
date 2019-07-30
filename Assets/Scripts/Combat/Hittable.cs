using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hittable : MonoBehaviour
{
    private string gameObjectName;

    private void Start()
    {
        gameObjectName = "X";
    }

    public void ReceiveAttack()
    {
        Debug.Log("Soy " + gameObjectName + " y estoy siendo atacado");
    }
}
