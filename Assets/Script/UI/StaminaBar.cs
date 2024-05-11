using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    [SerializeField]
    private Image _staminaBar;

    [SerializeField]
    private GameObject _staminaUi;

    private void Start()
    {
        EventContainer.Instance.StaminaBarListener += UpdateStamina;
    }


    private void UpdateStamina(float stamina)
    {
        if (stamina >= 1)
        {
            _staminaUi.SetActive(false);
        }
        else
        {
            _staminaUi.SetActive(true);
        }

        _staminaBar.fillAmount= stamina;
    }


}
