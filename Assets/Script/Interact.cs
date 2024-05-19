using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact
{
    Collider2D _collider;
    Transform _self;
    IInteractable interaction;
    MonoBehaviour _mono;
    Coroutine coroutine;

    public Interact (Collider2D collider ,MonoBehaviour mono, Transform self)
    {
        _collider = collider;
        _mono= mono;
        _self = self;
    }

    public void CheckCollider()
    {
        ContactFilter2D filter = new ContactFilter2D().NoFilter();
        List<Collider2D> results = new List<Collider2D>();
        if (_collider.OverlapCollider(filter, results) > 0)
        {
            foreach (Collider2D col in results)
            {
                if (col.TryGetComponent<IInteractable>(out IInteractable interact))
                {
                    interaction = interact;
                    interact.interaction(_self);
                    coroutine = _mono.StartCoroutine(CheckColliderEverytick());
                    break;
                }
            }
        }
    }


    IEnumerator CheckColliderEverytick()
    {
        ContactFilter2D filter = new ContactFilter2D().NoFilter();
        List<Collider2D> results = new List<Collider2D>();
        bool onReachItem = true;

        while (onReachItem)
        {
            yield return new WaitForSeconds(0.1f);
            if (_collider.OverlapCollider(filter, results) > 0)
            {
                bool stillOnReach = false;
                foreach (Collider2D col in results)
                {
                    if (col.TryGetComponent<IInteractable>(out IInteractable interact))
                    {
                        if (interaction == interact)
                        {
                            stillOnReach = true;
                            break;
                        }

                    }

                }
                if (!stillOnReach)
                {
                    onReachItem = false;
                }
            }
        }

        interaction.CancelInteraction();
        interaction = null;
        yield break;
    }

    public void CancelInteraction()
    {
        ContactFilter2D filter = new ContactFilter2D().NoFilter();
        List<Collider2D> results = new List<Collider2D>();
        if (_collider.OverlapCollider(filter, results) > 0)
        {
            foreach (Collider2D col in results)
            {
                if (col.TryGetComponent<IInteractable>(out IInteractable interact))
                {
                    interact.CancelInteraction();
                    _mono.StopCoroutine(coroutine);
                    break;
                }
            }
        }
    }
}
