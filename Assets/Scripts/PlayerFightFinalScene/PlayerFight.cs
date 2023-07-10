using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFight : MonoBehaviour
{
    public GameObject enemy;
    [SerializeField] public Animator animator;
    [SerializeField] private Transform attackPoint;
    private float attackRange = 12f;
    private float attackDamage = 40f;
    [SerializeField] private LayerMask enemyLayer;
    private bool isAttacking = false;
    public AudioSource playerAudio;
    public AudioClip hitSound;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            Attack();
        }

        if( enemy.GetComponent<EnemyDMG>().CurrentHealth() <= 0 )
        {
            Movement movementScript = GetComponent<Movement>();
            if (movementScript != null)
            {
                movementScript.enabled = false;
            }
        }

    }

    private void Attack()
    {
        if (GetComponent<DamageTaking>().CurrentHealth() <= 0)
        {
            return;
        }

        // Play Attack Animation
        if (!isAttacking)
        {
            animator.SetTrigger("Attacking");
            isAttacking = true;
        }
        else
        {
            animator.ResetTrigger("Attacking");
            animator.SetTrigger("Attacking");
        }


        // Detect all the Enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);


        // Damage all the Enemies
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyDMG>().TakeDamage(attackDamage);
        }

        //play sound when attack done
        playerAudio.PlayOneShot(hitSound);
    }

    void OnDrawGizmosSelected()         // Drawing the attacking point so that we can see that in the editor
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }



}
