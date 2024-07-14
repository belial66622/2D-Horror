using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour, IInteractable
{
    [SerializeField] Door door;
    [SerializeField] string password;
    [SerializeField] Puzzle puzzle;

    public void CancelInteraction()
    {
    }

    public void interaction(object obj = null)
    {
        puzzle.SetPad(password, door);
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
