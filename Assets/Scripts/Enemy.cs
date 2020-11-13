using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    public float maxHealth = 100;
    public float currentHealth;
    private bool alive = true;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0 && alive)
        {
            animator.SetTrigger("die");
            alive = false;
        }
    }

    public void TakeHit(float damage)
    {
        if (!alive) { return; }

        currentHealth -= damage;
        if (currentHealth > 0)
        {
            animator.SetTrigger("hit");
        }
    }
}
