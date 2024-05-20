using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField]
    float _dmg;

    bool damagestart = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IHealth>(out IHealth health))
        {
            if (collision.TryGetComponent<IHide>(out IHide hide))
            {
                if (!hide.IsHiding)
                {
                    damagestart = true;
                    Debug.Log("damage");
                    StartCoroutine(TakeHealth(health));

                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IHealth>(out IHealth health))
        {
            GiveDamage(health, _dmg, out IHealth hp);
            if (hp == health)
            {
                damagestart = false;
                StopAllCoroutines();
            }

        }
    }


    void GiveDamage(IHealth health, float dmg, out IHealth hp)
    {
        health.ChangeHealth(dmg);

        hp = health;
    }


    IEnumerator TakeHealth(IHealth health)
    {
        while (damagestart)
        {
            yield return null;
            health.ChangeHealth(_dmg * Time.deltaTime);
        }
    }
}
