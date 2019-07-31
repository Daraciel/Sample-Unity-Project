using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hittable : MonoBehaviour
{
    private string gameObjectName;
    private Health _myHealth;
    private Rigidbody2D _myRigidBody;

    private void Start()
    {
        gameObjectName = gameObject.name;
        _myHealth = GetComponent<Health>();
        _myRigidBody = GetComponent<Rigidbody2D>();
    }

    public void ReceiveAttack(int damage)
    {
        Debug.Log("Soy " + gameObjectName + " y estoy siendo atacado");
        _myHealth.ReceiveDamage(damage);
        if(_myHealth.CurrentHealth == 0)
        {
            Debug.Log("Me mataste");
        }
    }

    public void ReceiveAttack(int damage, Vector2 attackDirection)
    {
        Debug.Log("Soy " + gameObjectName + " y estoy siendo atacado");
        _myHealth.ReceiveDamage(damage);
        _myRigidBody.AddForce(attackDirection * damage * 60);
    }
}
