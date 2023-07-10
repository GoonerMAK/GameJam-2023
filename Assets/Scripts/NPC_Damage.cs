using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Damage : MonoBehaviour
{
    [SerializeField] public float lives;
    [SerializeField] public Animator animator;

    public AudioClip dieSound;
    public AudioSource dieAudio;
    public float waitForDeath = 5.0f;

    //counts how many villager and enemies killed
    public int enemyCount;
    public int villagerCount;

    public Rigidbody2D npcRb;


    // Start is called before the first frame update
    void Start()
    {
        lives = 4;
        dieAudio = Camera.main.GetComponent<AudioSource>();

        enemyCount = 0;
        villagerCount = 0;

        npcRb = GetComponent<Rigidbody2D>();
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

        animator.SetBool("isDead", true);
        dieAudio.PlayOneShot(dieSound);

        if (npcRb.CompareTag("Villager"))
        {
            villagerCount++;
        }
        else if (npcRb.CompareTag("Enemy"))
        {
            enemyCount++;
        }

        StartCoroutine(SetNPCInactive());
    }

    IEnumerator SetNPCInactive()
    {
        yield return new WaitForSeconds(waitForDeath);
        gameObject.SetActive(false);
    }

}
