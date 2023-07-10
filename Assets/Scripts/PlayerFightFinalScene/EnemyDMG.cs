using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDMG : MonoBehaviour
{
    public Animator animator;
    [SerializeField] public float maxHealth = 100f;
    [SerializeField] public float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        Debug.Log("I died");

        animator.SetBool("IsDead", true);

        this.enabled = false;
    }



    void DisableGameObject()
    {
        gameObject.SetActive(false);
    }

    public float CurrentHealth()
    {
        return currentHealth;
    }

}
