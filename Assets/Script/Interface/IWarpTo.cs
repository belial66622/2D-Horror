using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWarpTo
{
    public void WarpTo(Warp warpToPosition);

    bool IsPlayer { get; }
}
