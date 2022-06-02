using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public HealthBar healthBar;
    
    public int healthMax = 5;
    public int healthCurrent;

    public int playerStaminaMax = 20;
    public int playerStaminaCurrent;

    public bool playerDead = false;

    public Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        healthCurrent = healthMax;
        healthBar.SetMaxHealth(healthMax);

        healthText.text = healthMax.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = healthCurrent.ToString();
        healthBar.SetHealth(healthCurrent);

        if(healthCurrent <= 0)
        {
            healthCurrent = 0;
            playerDead = true;
        }
    }    
}
