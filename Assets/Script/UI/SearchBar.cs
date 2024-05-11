using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchBar : MonoBehaviour
{
    [SerializeField]
    Image fillBar;

    [SerializeField]
    GameObject SearchUI;


    private void Start()
    {
        EventContainer.Instance.SearchBarListener += FillBar;
    }

    private void OnDisable()
    {
        EventContainer.Instance.SearchBarListener -= FillBar;
    }

    private void FillBar(float amount)
    {
        Debug.Log(amount);
        if (amount == 1)
        {
            SearchUI.SetActive(false);
        }
        else if (amount == 0)
        {
            SearchUI.SetActive(false);
        }
        else
        {
            SearchUI.SetActive(true);
            fillBar.fillAmount = amount;
        }
    }


}
