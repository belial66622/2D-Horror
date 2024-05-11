using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BetweenRoom : Warp
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<IWarpTo>(out IWarpTo warpto))
        {
            WarpingTO(warpto);
        }
        Debug.Log("ditabrak");
    }

    protected override void WarpingTO(IWarpTo warpto)
    {
        warpto.WarpTo(_warpTo.GetChild(0));
        _room.ChangeRoom(_warpTo.parent);
    }
}
