using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float maxHealth = 100 %
    private float CurrentHealth;

    private float hitTimer = 0.15f;
    private bool isHit = false;

    private Animator animator;
    private Rigidbody2D myRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        CurrentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }


    private void Die()
    {
        animator.SetTrigger("die");
        StartCoroutine(Dying());
    }

    IEnumerator Dying() 
    {
        isHit = true;
        myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
        yield return new WaitForSeconds(5f);
    }
    
    IEnumerator KnockBack() 
    {
        isHit = true;
        myRigidbody.velocity = new Vector2(GetComponent<Movement>().facing * -2.5f, 2.5f);
        animator.SetTrigger("takeDamage");
        yield return new WaitForSeconds(hitTimer);
        isHit = false;
    }
}