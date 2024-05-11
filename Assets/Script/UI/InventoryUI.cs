using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private Image image;

    [SerializeField]
    private TextMeshProUGUI Itemname;


    private void Start()
    {
        EventContainer.Instance.ChoosenItemListener += ShowItem;
    }

    private void ShowItem(ItemIdentification item)
    {
        image.sprite = item.image;
        Itemname.SetText($"{item.Id}");
    }


}
