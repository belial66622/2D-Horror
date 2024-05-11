using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable 
{
    public void interaction(object obj = null);

    public void CancelInteraction();
}
