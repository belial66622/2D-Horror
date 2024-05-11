using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract
    class Warp : MonoBehaviour, IWarpable
{
    [SerializeField]
    protected Transform _warpTo;

    [field: SerializeField]
    public WarpStatus status { get; protected set; }

    [field: SerializeField]
    public string keyitem { get; protected set; }

    protected virtual void WarpingTO(IWarpTo warpto)
    {
        warpto.WarpTo(_warpTo);
    }

    protected WarpStatus GetOtherPoint()
    {
        WarpStatus OtherPointStatus;

        OtherPointStatus = _warpTo.GetComponent<IWarpable>().status;

        return OtherPointStatus;
    }
}
