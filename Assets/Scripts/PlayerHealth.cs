using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    private int health = 4;
    private RectTransform healthBar;

    private bool healthLock;
    private knight_movement knightMovement;

    // Start is called before the first frame update
    void Start()
    {
        health = 4;    
        healthLock = false;
        healthBar = GameObject.Find("Health_Bar").GetComponent<RectTransform>();
        knightMovement = GetComponent<knight_movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loseHealth() {
        if (healthLock || health <= 0) return;
        health--;
        updateHealthBar();
        healthLock = true;
        Invoke("unlockHealth", 1f);
    }

    private void updateHealthBar() {
        healthBar.localScale = new Vector3(health * 0.25f, healthBar.localScale.y, 1);
    }

    private void unlockHealth() {
        healthLock = false;
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.CompareTag("EnemyAttack")) {
            if (knightMovement.getFlying()) return;
            
            if (knightMovement.getDefending()) {
                knightMovement.knockBack();
            }
            else {
                loseHealth();
            }
        }
    }
}
