using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour , IInteractable
{
    [SerializeField]
    string keyitem;
    [SerializeField]
    string success;
    [SerializeField]
    string failed;

    [SerializeField]
    int levelcurrent = 2;
    [SerializeField]
    GameObject finished;

    public void FinishedGame()
    { 
        finished.SetActive(true);
    }
    public void CancelInteraction()
    {

    }

    public void interaction(object obj = null)
    {
        Transform character = (Transform)obj;

        if (KeyItem(character) == keyitem)
        {
            EventContainer.Instance.DialogueEvent(success);
            //complete level

            var level = PlayerPrefs.GetInt("level");
            if (level < levelcurrent)
            {
                PlayerPrefs.SetInt("Level",levelcurrent);
            }
            FinishedGame();
        }
        else
        {
            EventContainer.Instance.DialogueEvent(failed);
        }
    }

    private string KeyItem(Transform player)
    {
        string item;
        if (player.TryGetComponent<Inventory>(out Inventory inventory))
        {
            item = inventory.Choosenitem();

            return item;
        }

        return "";
    }
}
