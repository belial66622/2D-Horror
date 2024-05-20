using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWarpable
{
    WarpStatus status { get; }

    string keyitem { get; }
}
