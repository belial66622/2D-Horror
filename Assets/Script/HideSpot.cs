using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSpot : MonoBehaviour , IInteractable , ISearchObejctAI
{
    [SerializeField]
    Transform _player;

    public Transform position => transform;

    private void Start()
    {
        _player = GameManager.Instance.getPlayer();
    }

    public void CancelInteraction()
    {
    }

    public void interaction(object obj = null)
    {
        _player.GetComponent<SpriteRenderer>().sortingLayerName = "Hide";
        _player.transform.position= new Vector3 (transform.position.x, _player.transform.position.y);
        if (_player.TryGetComponent<IHide>(out IHide hide))
        {
            if (!hide.IsHiding)
            {
                hide.Hide();
            }
            else
            { 
                hide.Unhide();

                _player.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
            }
        }
    }

}
