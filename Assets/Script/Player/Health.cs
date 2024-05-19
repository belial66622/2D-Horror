using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    public float CurrentHealth { get; private set; }

    public float MaxHealth { get; private set; } = 10;

    private bool isdead = false;
    public virtual void ChangeHealth(float amount)
    {
        if (isdead) return;

        if (CurrentHealth <= 0)
        {
            Debug.Log("ded");
            isdead = !isdead;
        }
        CurrentHealth -= amount;
    }

    public virtual int GetHealth()
    {
        return (int)CurrentHealth;
    }

    protected virtual void Start()
    {
        CurrentHealth = MaxHealth;
    }
}
