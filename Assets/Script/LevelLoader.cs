using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] Button level1;
    [SerializeField] Button level2;
    [SerializeField] Button level3;
    int level;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            level = PlayerPrefs.GetInt("Level");
        }

        else { level = 1; }

        if (level1 is null)
        {
            return;
        }
        else if (level == 1)
        {
            level1.interactable = true;
            level2.interactable = false;
            level3.interactable = false;
        }
        else if (level == 2)
        {
            level1.interactable = true;
            level2.interactable = true;
            level3.interactable = false;
        }
        else
        {
            level1.interactable = true;
            level2.interactable = true;
            level3.interactable = true;
        }
    }

    public void ChangeScene(int number)
    {
        SceneManager.LoadScene(number);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
