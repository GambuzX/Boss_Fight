using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobController : MonoBehaviour
{

    public float attackCooldown = 2f;

    public GameObject claw;

    private bool attackLock;

    private Animator animator;

    private PlayerHealth playerHealth;
    private BlobHealth blobHealth;

    private GameObject projectilesParent;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        playerHealth = GameObject.FindObjectOfType<PlayerHealth>();
        blobHealth = GetComponent<BlobHealth>();
        projectilesParent = GameObject.Find("ProjectilesParent");
        attackLock = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!attackLock) {

            int choice = Random.Range(1, 18);
            if (choice <= 4)
                triggerAttack("swipe");
            else if (choice >= 6 && choice <= 12) {
                triggerAttack("punch");
                Invoke("instantiateClaw", 0.5f);
            }
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

    void instantiateClaw() {
        GameObject new_claw = Instantiate(claw, new Vector3(21.47f, -2.37f, 0), claw.transform.rotation, projectilesParent.transform);
        new_claw.GetComponent<Rigidbody2D>().velocity = new Vector3(-5f, 0f, 0f);
    }

    void OnCollisionStay2D(Collision2D collider) {
        if (collider.gameObject.CompareTag("Player"))
            playerHealth.loseHealth();
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("PlayerAttack")) {
            blobHealth.loseHealth();
        }
    }
}
