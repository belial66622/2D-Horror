using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISearchItem : IInteractable
{

    public float RemainingTime { get; }

    public bool Searching { get; }

    public float SearchTime { get; }

    public bool HasItem { get; }

}
