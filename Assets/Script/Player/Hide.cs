using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour, IHide
{
    public bool IsHiding {get; private set;}

    private Player player;

    public void Unhide()
    {
        IsHiding= false;
        player.StartMovement();
    }

    void IHide.Hide()
    {
        IsHiding= true;
        player.StopMovement();
    }

    private void Start()
    {
        player= GetComponent<Player>();
    }

    private void Update()
    {
        
    }
}
