using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobController : MonoBehaviour
{

    public float attackCooldown = 2f;

    private bool attackLock;

    private Animator animator;

    private PlayerHealth playerHealth;

    private 

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        playerHealth = GameObject.FindObjectOfType<PlayerHealth>();
        attackLock = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!attackLock) {

            int choice = Random.Range(1, 20);
            if (choice <= 4)
                triggerAttack("swipe");
            else if (choice >= 6 && choice <= 12)
                triggerAttack("punch");
            else if (choice >= 15 && choice <= 16)
                triggerAttack("balls");
            else {
                triggerAttack("none");
            }
        }

    }

    void triggerAttack(string attack) {
        float cooldown = attackCooldown;
        if (attack == "none") {
            cooldown = Random.Range(0.1f, 0.2f);
        }
        else 
            animator.SetTrigger(attack);
        attackLock = true;
        Invoke("unlockAttack", attackCooldown);
    }

    void unlockAttack() {
        attackLock = false;
    }

    void OnCollisionStay2D(Collision2D collider) {
        Debug.Log("collided");
        if (collider.gameObject.CompareTag("Player"))
            playerHealth.loseHealth();
    }
}
