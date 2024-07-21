using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    public override void ChangeHealth(float amount)
    {
        base.ChangeHealth(amount);
        EventContainer.Instance.HealthUIEvent(CurrentHealth / MaxHealth);

        if (CurrentHealth <= 0)
        {
            GameManager.Instance.PauseGame(false);
            EventContainer.Instance.GameOverEvent();
        }
    }
}
