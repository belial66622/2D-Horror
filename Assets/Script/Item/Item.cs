using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour, IItemDes , ISearchItem
{
    #region Variable

    private Coroutine _searcing = null;

    public UnityEvent AfterItemGet;

    #endregion

    #region ISearchItem

    [field: SerializeField]
    public float SearchTime { get; private set; }

    public bool HasItem { get; set; } = true;

    public float RemainingTime { get; private set; }

    public bool Searching { get; private set; }

    private ISearchItem search;

    public void CancelInteraction()
    {
        if (!HasItem) return;
        StopAllCoroutines();
        _searcing = null;
        Searching = false;
        // 0 digunakan untuk menghilangkan search pada bar. digunakan untuk mengatur waktu menjadi 0
        EventContainer.Instance.SearchBarEvent(0);
        EventContainer.Instance.DialogueEvent("");

    }

    public void interaction(object obj = null)
    {
        if (!HasItem)
        {
            EventContainer.Instance.DialogueEvent("Sudah Dicari, Tidak Perlu mencari lagi");
            return;
        }

        Transform player = (Transform)obj;
        
        RemainingTime = SearchTime;

        if (_searcing == null)
        {
            EventContainer.Instance.DialogueEvent("Searching...");
            _searcing = StartCoroutine(SearchingItem());
        }
    }



    #endregion

    #region IItemDes

    [field: SerializeField]
    public ItemIdentification item { get; private set; }

    public ItemIdentification GiveItem()
    {
        return item;
    }

    #endregion


    IEnumerator SearchingItem()
    {
        Searching = true;
        while (Searching)
        {
            RemainingTime -= Time.deltaTime;
            yield return null;

            Debug.Log("interaksiItem");
            EventContainer.Instance.SearchBarEvent(RemainingTime/SearchTime);
            if (RemainingTime <= 0)
            {
                EventContainer.Instance.ItemTakeEvent(GiveItem());
                EventContainer.Instance.DialogueEvent("");
                Searching = false;
                // 0 digunakan untuk menghilangkan search pada bar. digunakan untuk mengatur waktu menjadi 0
                EventContainer.Instance.SearchBarEvent(0);
                HasItem= false;
                AfterItemGet?.Invoke();
            }
        }
    }

}
