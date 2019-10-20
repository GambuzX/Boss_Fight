using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    private int health = 4;
    private RectTransform healthBar;

    // Start is called before the first frame update
    void Start()
    {
        health = 4;    
        healthBar = GameObject.Find("Health_Bar").GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loseHealth() {
        if (health <= 0) return;
        health--;
        updateHealthBar();
    }

    private void updateHealthBar() {
        healthBar.localScale = new Vector3(health * 0.25f, healthBar.localScale.y, 1);
    }
}
