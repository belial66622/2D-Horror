using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField]
    Image healthBar;
    private void Start()
    {
        EventContainer.Instance.HealthUIListener = Health;
    }

    public void Health(float health)
    { 
        healthBar.fillAmount = health;
    }
}
