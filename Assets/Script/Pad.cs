using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pad : MonoBehaviour, IInteractable
{
    [SerializeField] Door door;
    [SerializeField] string password;
    [SerializeField] Puzzle puzzle;

    public UnityEvent AfterPuzzleClear;
    public void CancelInteraction()
    {
    }

    public void interaction(object obj = null)
    {
        puzzle.SetPad(password, door,this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
