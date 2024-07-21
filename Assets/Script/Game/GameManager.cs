using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private Transform player;

    public static GameManager Instance { get; private set; }

    [SerializeField]
    Animator animator;

    [SerializeField]
    GameObject chased;

    [SerializeField]
    GameObject Pause;

    public int State { get; private set; } = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
        UnpauseGame();
    }

    public Transform getPlayer()
    {
        return player;
    }

    public void Chased(int state)
    {
        if (State == 0 && state >0)
        {
            animator.Play("Go");
        }

        State = state;

        if (State == 2)
        {
            chased.SetActive(true);
        }

        else
        {
            chased.SetActive(false);
        }
    }

    public void PauseGame(bool cond = true)
    {
        Time.timeScale = 0;
        Pause.SetActive(cond);
    }



    public void UnpauseGame()
    {
        Time.timeScale = 1;
        Pause.SetActive(false);
    }
}
