using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobHealth : MonoBehaviour
{

    public int health = 8;

    private Transform healthBar;

    private bool healthLock;

    // Start is called before the first frame update
    void Start()
    {
        healthLock = false;
        healthBar = transform.Find("Health");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loseHealth() {
        if(healthLock || health <= 0) return;

        health--;
        updateHealthBar();
        healthLock = true;
        Invoke("unlockHealth", 0.5f);
    }

    private void updateHealthBar() {
        healthBar.localScale = new Vector3(health * 1.0f/15, healthBar.localScale.y, 1);
    }

    private void unlockHealth() {
        healthLock = false;
    }
}
