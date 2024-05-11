using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemIdentification
{
    [SerializeField]
    public string Id;

    [SerializeField]
    public Sprite image;

    [SerializeField]
    public bool oneTimeUse;
}
