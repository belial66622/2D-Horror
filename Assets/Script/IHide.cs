using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHide 
{
    bool IsHiding { get; }
    void Hide();

    void Unhide();
}
