using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventContainer : MonoBehaviour
{
    public static EventContainer Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
    }


    public Action<float> SearchBarListener;

    public Action<ItemIdentification> ItemTakeListener;

    public Action<ItemIdentification> ChoosenItemListener;

    public Action<string> DialogueListener;

    public Action<float> StaminaBarListener;

    public void ChoosenItemEvent(ItemIdentification item)
    { 
        ChoosenItemListener?.Invoke(item);
    }

    public void SearchBarEvent(float amount)
    {
        SearchBarListener?.Invoke(amount);
    }

    public void ItemTakeEvent(ItemIdentification item)
    {
        ItemTakeListener?.Invoke(item);
    }

    public void DialogueEvent(string text)
    {
        DialogueListener?.Invoke(text);
    }

    public void StaminaBarEvent(float amount)
    {
        StaminaBarListener?.Invoke(amount);
    }
}
