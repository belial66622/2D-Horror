using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    public float CurrentHealth {get;}
    public float MaxHealth { get; }

    public int GetHealth();

    public void ChangeHealth(float amount);
}
