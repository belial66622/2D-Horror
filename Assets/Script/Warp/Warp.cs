using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public abstract
    class Warp : MonoBehaviour, IWarpable, ISearchObejctAI
{
    [SerializeField]
    private Warp warp;

    [field: SerializeField]
    public WarpStatus status { get; protected set; }

    [field: SerializeField]
    public string keyitem { get; protected set; }

    public Room _room { get; protected set; }

    [field: SerializeField]
    public Transform Location { get; protected set; }

    public Transform position => transform;

    [SerializeField] protected bool enable = false;
    protected virtual void Awake()
    {
        if (!gameObject.activeInHierarchy) return;
        Location = transform;
        _room = transform.parent.GetComponent<Room>();
        GetComponentInParent<Room>().AddWarpLocation(this);
    }

    protected virtual void WarpingTO(IWarpTo warpto)
    {
        warpto.WarpTo(warp);
        if (warpto.IsPlayer)
            if (!enable)
            {         
                _room.ChangeRoom(warp.transform.parent);
            } 
    }

    protected WarpStatus GetOtherPoint()
    {
        WarpStatus OtherPointStatus;

        OtherPointStatus = warp.GetComponent<IWarpable>().status;

        return OtherPointStatus;
    }

    public virtual void OpenStatus()
    {
        status = WarpStatus.Open;
    }
}
