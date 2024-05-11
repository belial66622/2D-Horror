using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemDes
{
    ItemIdentification item { get; }

    public ItemIdentification GiveItem();
}
