using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
   public void LevelOneComplete()
   {
        PlayerPrefs.SetInt("Level2", 1);
    }

    public void LevelTwoComplete()
    {
        PlayerPrefs.SetInt("Level3", 1);
    }
}
