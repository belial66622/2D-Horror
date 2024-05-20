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
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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

        if (State == 1)
        {
            //tampilkan UI putih;
        }

        else
        { 
            //tampilkan ui dikejar
        }
    }

}
