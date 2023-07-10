using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Damage : MonoBehaviour
{
    [SerializeField] public float lives;
    [SerializeField] public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        lives = 4;
    }
    public void TakeDamage(float damage)
    {
        lives--;

        if (lives <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        Debug.Log("NPC died");

        //animator.SetBool("isDead", true);

        //this.enabled = false;

        SetNPCInactive();
    }

    void SetNPCInactive()
    {
        //animator.SetBool("isDead", false);
        gameObject.SetActive(false);
    }

}
