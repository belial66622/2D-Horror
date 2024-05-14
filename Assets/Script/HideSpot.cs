using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSpot : MonoBehaviour , IInteractable
{

    Transform _player;

    public void CancelInteraction()
    {
    }

    public void interaction(object obj = null)
    {
        _player = (Transform)obj;
        _player.SetParent(transform);
        if (_player.TryGetComponent<IHide>(out IHide hide))
        {
            if (!hide.IsHiding)
            {
                hide.Hide();
            }
            else
            { 
                hide.Unhide();
            }
        }
    }

}
