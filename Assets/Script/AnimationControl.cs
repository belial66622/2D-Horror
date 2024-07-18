using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationControl : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    [SerializeField]
    SpriteRenderer image; 


    public void SetSpeed(int speed)
    {
        animator.SetInteger("Speed", speed);
    }

    public void SetHealth(int health)
    {
        animator.SetInteger("Health", health);
    }

    public void flip(bool condition)
    { 
        image.flipX = condition;
        Debug.Log(condition);
    }
}
