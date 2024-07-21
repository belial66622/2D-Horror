using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.ShaderData;

public class CoupleItem : MonoBehaviour, IInteractable
{

    [SerializeField] CoupleItem Other;

    public bool HaveItem = false;

    public UnityEvent OnOtherHaveItem;

    [SerializeField] private string keyItem;
    public void CancelInteraction()
    {
    }

    public void interaction(object obj = null)
    {
        if (HaveItem)
        {
            EventContainer.Instance.DialogueEvent($"Item Sudah diberikan");
        }

        else
        {
            Transform character = (Transform)obj;
            if (KeyItem(character) == keyItem)
            {
                EventContainer.Instance.DialogueEvent($"Artifak Ditaruh Disini");
                HaveItem = true;
                if (Other.HaveItem)
                {
                    OnOtherHaveItem?.Invoke();
                    EventContainer.Instance.DialogueEvent($"Pintu Sudah Terbuka");
                }
            }
            else
            {
                EventContainer.Instance.DialogueEvent($"Seharusnya disini tempat artifak");
            }
        }
    }

    private string KeyItem(Transform player)
    {
        string item;
        if (player.TryGetComponent<Inventory>(out Inventory inventory))
        {
            item = inventory.Choosenitem();

            return item;
        }

        return "";
    }
}
