using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    GameObject gameover;

    private void Start()
    {
        EventContainer.Instance.GameOverListener = GameOverUI;
    }

    void GameOverUI()
    {
        gameover.SetActive(true);
    }

    public void Ulang()
    {
        GameManager.Instance.UnpauseGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
