using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Warp, IInteractable
{
    const string AIPass = "ByPassLock";

    public void CancelInteraction()
    {

    }

    public void interaction(object obj = null)
    {
        Transform character = (Transform)obj;

        if (status == WarpStatus.Locked)
        {
            if (keyitem == KeyItem(character))
            {
                status = WarpStatus.Open;

                EventContainer.Instance.DialogueEvent("Kunci dipakai sudah dibuka");
            }

            else if (keyitem == AIPass)
            {

                if (character.TryGetComponent<IWarpTo>(out IWarpTo warpto))
                {
                    WarpingTO(warpto);
                }
            }
            else
            {
                EventContainer.Instance.DialogueEvent("Tidak Bisa Dibuka");
            }
        }

        else if (GetOtherPoint() == WarpStatus.Barricade)
        {

            if (keyitem == AIPass)
            {

                if (character.TryGetComponent<IWarpTo>(out IWarpTo warpto))
                {
                    WarpingTO(warpto);
                }
            }

            else
            {
                EventContainer.Instance.DialogueEvent("Sepertinya ada yang mengganjal di sisi lain");
            }
        }

        else if (status == WarpStatus.Barricade)
        {
            if (keyitem == AIPass)
            {

                if (character.TryGetComponent<IWarpTo>(out IWarpTo warpto))
                {
                    WarpingTO(warpto);
                }
            }

            else
            {
                status = WarpStatus.Open;
                EventContainer.Instance.DialogueEvent("Penghalang Sudah dibuka");
            }
        }

        else
        {
            if (character.TryGetComponent<IWarpTo>(out IWarpTo warpto))
            {
                WarpingTO(warpto);
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

        return AIPass;
    }
}
