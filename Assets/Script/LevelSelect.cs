using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    [SerializeField]Button level1;
    [SerializeField]Button level2;
    [SerializeField] Button level3;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Level2"))
        {
            level2.interactable = true;
        }
        if (PlayerPrefs.HasKey("Level3"))
        {
            level3.interactable = true;
        }
    }
}
