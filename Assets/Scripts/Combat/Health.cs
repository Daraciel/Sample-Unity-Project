using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int BaseHealth;
    public int HealthModifier;
    public int MaxHealth
    {
        get
        {
            return BaseHealth + HealthModifier;
        }
    }
    public UnityEvent OnHealthIsZero;
    
    public Image HealthBar;

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
                gameObject.layer = 12;
                if(OnHealthIsZero != null)
                {
                    OnHealthIsZero.Invoke();
                }
                //Destroy(gameObject);
            }
            else if(value > MaxHealth)
            {
                currentHealth = MaxHealth;
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
        UpdateHealthBar();
    }

    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    public void UpdateHealthBar()
    {
        if(HealthBar != null)
        {
            HealthBar.fillAmount = (float)CurrentHealth / MaxHealth;
        }
    }

    public void ModifyBaseHealth(int amount)
    {
        BaseHealth += amount;
        if(amount > 0 && CurrentHealth < MaxHealth)
        {
            //CurrentHealth++;
        }
        UpdateHealthBar();
    }
}
