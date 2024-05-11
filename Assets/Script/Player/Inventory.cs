using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    List<ItemIdentification> ItemList = new List<ItemIdentification>();
    int itemAt = 0;

    private Control gameInput;

    private void Awake()
    {
        if (TryGetComponent<Control>(out Control control)) { gameInput = control; }
    }


    private void Start()
    {
        EventContainer.Instance.ItemTakeListener += AddItem;
    }

    private void OnDisable()
    {

        EventContainer.Instance.ItemTakeListener -= AddItem;
    }

    private void Update()
    {
        ItemCycle();
    }

    public void ChooseItem(int count)
    {
        if (ItemList.Count == 0) return;

        else if (ItemList.Count == 1)
        { 
            itemAt = 0;
        }

        else if (itemAt + count > ItemList.Count - 1)
        {
            itemAt = 0;
        }
        else if (itemAt + count < 0)
        {
            itemAt = ItemList.Count - 1;
        }
        else
        {
            itemAt += count;
        }
        ShowItem(ItemList[itemAt]);
    }

    public void AddItem(ItemIdentification item)
    {
        if (ItemList.Count == 0)
        {
            ItemList.Add(item);
            ShowItem(ItemList[itemAt]);
        }
        else
        {
            ItemList.Add(item);
        }
    }


    public void ShowItem(ItemIdentification item)
    {
        if(ItemList.Count == 0) return;

        EventContainer.Instance.ChoosenItemEvent(item);
    }

    public string Choosenitem()
    {
        ItemIdentification item;

        if (ItemList.Count == 0)
        {
            return "NoIteminventory";
        }

        item = ItemList[itemAt];

        return item.Id;
    }

    private void ItemCycle()
    {
        float item = gameInput.Scroll();
        if (item > 0)
        {
            //memilih item yang ada di inventory. 1 berarti item selanjutnya
            ChooseItem(1);
        }
        else if (item < 0)
        {
            //memilih item yang ada di inventory. -1 berarti item sebelunmya
            ChooseItem(-1);
        }
    }
}