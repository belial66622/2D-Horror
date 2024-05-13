using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    public float CurrentHealth { get; private set; }

    public float MaxHealth { get; private set; } = 100;

    public virtual void ChangeHealth(float amount)
    {
       CurrentHealth= amount;
    }

    public int GetHealth()
    {
        return (int)CurrentHealth;
    }

    protected virtual void Start()
    {
        CurrentHealth = MaxHealth;
    }
}
