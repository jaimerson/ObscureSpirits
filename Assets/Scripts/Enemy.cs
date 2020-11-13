using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    public GameObject prefab;
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
            Die();
        }
    }

    private void Die()
    {
        animator.SetTrigger("die");
        alive = false;
        Vector3 newPosition = new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f));
        Instantiate(prefab, newPosition, Quaternion.identity);
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
