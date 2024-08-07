using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BetweenRoom : Warp
{

    protected override void Awake()
    {
        if (!gameObject.activeInHierarchy) return;
        _room = transform.parent.GetComponent<Room>();
        GetComponentInParent<Room>().AddWarpLocation(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<IWarpTo>(out IWarpTo warpto))
        {
            WarpingTO(warpto);
        }
    }

}
