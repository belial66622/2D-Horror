using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    float time;

    [SerializeField] float MaxTime;

    [SerializeField] Image counting; 
    private void Start()
    {
        time = MaxTime;
        counting.fillAmount = 1;
    }
    private void FixedUpdate()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            counting.fillAmount = time / MaxTime;
        }
    }
}
