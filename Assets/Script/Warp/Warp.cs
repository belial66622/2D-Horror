using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract
    class Warp : MonoBehaviour, IWarpable
{
    [SerializeField]
    private Warp warp;

    [field: SerializeField]
    public WarpStatus status { get; protected set; }

    [field: SerializeField]
    public string keyitem { get; protected set; }

    public Room _room{get; protected set;}

    [field:SerializeField]
    public Transform Location { get; protected set;}

    protected virtual void Awake()
    {
        Location= transform;
        _room = transform.parent.GetComponent<Room>();
        GetComponentInParent<Room>().AddWarpLocation(this);
    }

    protected virtual void WarpingTO(IWarpTo warpto)
    {
        warpto.WarpTo(warp);
        if(warpto.IsPlayer)
        _room.ChangeRoom(warp.transform.parent);
    }

    protected WarpStatus GetOtherPoint()
    {
        WarpStatus OtherPointStatus;

        OtherPointStatus = warp.GetComponent<IWarpable>().status;

        return OtherPointStatus;
    }
}
