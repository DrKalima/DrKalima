using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC3Health : MonoBehaviour
{
    public HealthBar healthBar;
    public TacticsActions tacticsActions;
    public TacticsMove tacticsMove;

    public int npc3healthMax = 5;
    public int npc3healthCurrent;

    public bool selectableEnemySkills = false;
    public bool selectableEnemy = false;
    public bool enemy3Dead = false;


    // Start is called before the first frame update
    void Start()
    {
        npc3healthCurrent = npc3healthMax;
        healthBar.SetMaxHealth(npc3healthMax);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(npc3healthCurrent);

        if (selectableEnemy)
        {
            Debug.Log("slectableEnemy true");
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

        if (npc3healthCurrent <= 0)
        {
            npc3healthCurrent = 0;
            enemy3Dead = true;
        }
    }


}
