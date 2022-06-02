using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCHealth : MonoBehaviour
{
    public HealthBar healthBar;
    public TacticsActions tacticsActions;
    public TacticsMove tacticsMove;

    public int npchealthMax = 5;
    public int npchealthCurrent;

    public bool selectableEnemySkills = false;
    public bool selectableEnemy = false;
    public bool enemyDead = false;

    
    // Start is called before the first frame update
    void Start()
    {
        npchealthCurrent = npchealthMax;
        healthBar.SetMaxHealth(npchealthMax);        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(npchealthCurrent);

        if (selectableEnemy)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        else if (selectableEnemySkills)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.red;
        }

        if(npchealthCurrent <= 0)
        {
            npchealthCurrent = 0;
            enemyDead = true;
        }
    }

    
}
