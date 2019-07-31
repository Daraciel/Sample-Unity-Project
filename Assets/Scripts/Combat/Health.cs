using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int BaseHealth;
    public UnityEvent OnHealthIsZero;

    private int currentHealth;

    public int CurrentHealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            if(value <= 0)
            {
                currentHealth = 0;
                Destroy(gameObject);
            }
            else
            {
                currentHealth = value;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = BaseHealth;
    }

    public void ReceiveDamage(int damage)
    {
        CurrentHealth -= damage;
    }

}
