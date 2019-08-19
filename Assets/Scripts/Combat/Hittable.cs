using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hittable : MonoBehaviour
{
    private string gameObjectName;
    private Health _myHealth;
    private Rigidbody2D _myRigidBody;
    private TextHitGenerator _myTextHitGenerator;

    public GameObject hitEffect;

    private void Start()
    {
        gameObjectName = gameObject.name;
        _myHealth = GetComponent<Health>();
        _myRigidBody = GetComponent<Rigidbody2D>();
        _myTextHitGenerator = GetComponent<TextHitGenerator>();
    }

    public void ReceiveAttack(int damage)
    {
        Debug.Log("Soy " + gameObjectName + " y estoy siendo atacado con " + damage + " de daño");
        _myHealth.ReceiveDamage(damage);
        createDamageText(damage);
        showHitFlash();
        if (_myHealth.CurrentHealth <= 0)
        {
            Debug.Log("Me mataste");
        }
    }

    private void createDamageText(int damage)
    {
        if(_myTextHitGenerator != null)
        {
            _myTextHitGenerator.CreateTextHit(-damage, transform, 0.5f, Color.white, _myTextHitGenerator.defaultOffsetX, 
                _myTextHitGenerator.defaultOffsetY, _myTextHitGenerator.defaultLifeTime);
        }
    }

    public void ReceiveAttack(int damage, Vector2 attackDirection)
    {
        ReceiveAttack(damage);
        //_myRigidBody.AddForce(attackDirection * 1 * 60);
    }

    private void showHitFlash()
    {
        if (hitEffect != null)
        {
            Debug.Log("show hitflash!");
            Instantiate(hitEffect, this.transform);
        }
        else
        {
            Debug.Log("NO hitflash defined");
        }
    }
}
