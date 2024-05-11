using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textDialogue;

    [SerializeField]
    private float _fadeTime;

    private float _remainingTime;

    private Coroutine _delay;

    private void Start()
    {
        EventContainer.Instance.DialogueListener += ChangeText;
    }

    private void OnDisable()
    {
        EventContainer.Instance.DialogueListener -= ChangeText;
    }

    private void ChangeText(string text)
    {
        if(_delay != null)
        StopCoroutine(_delay);

        _textDialogue.SetText(text);

        _delay = StartCoroutine("DelayDialogue");
    }

    IEnumerator DelayDialogue()
    {
        _remainingTime = _fadeTime;
        while (_remainingTime > 0)
        { 
            yield return null;
            _remainingTime -= Time.deltaTime;
        }
        _textDialogue.SetText("");
    }
}
