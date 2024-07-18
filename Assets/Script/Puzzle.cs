using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    string pass;

    string current;

    [SerializeField]TextMeshProUGUI Password;

    Door Lockeddoor;

    [SerializeField]
    string passwordWrong;

    [SerializeField]
    string doorUnlocked;

    Pad pad;

    public void add(string number)
    {
        current += number;
        Password.SetText(current);
    }

    public void SetPad(string password, Door door,Pad pad)
    {
        pass = password;
        Lockeddoor = door;
        this.pad = pad;
        this.gameObject.SetActive(true);
    }

    public void remove() 
    {
        if(current.Length > 0)
        current = current.Remove(current.Length-1,1) ;
        Password.SetText(current);
        Debug.Log(current);
    }

    public void Check()
    {
        if (pass == current)
        {
            Lockeddoor.OpenStatus() ;

            EventContainer.Instance.DialogueEvent(doorUnlocked);
        }

        else
        {
            EventContainer.Instance.DialogueEvent(passwordWrong);
            this.pad.AfterPuzzleClear?.Invoke();
        }

        current = "";
        this.gameObject.SetActive(false);   
    }
}
