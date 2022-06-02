using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC2Health : MonoBehaviour
{
    public HealthBar healthBar;
    public TacticsActions tacticsActions;
    public TacticsMove tacticsMove;

    public int npc2healthMax = 5;
    public int npc2healthCurrent;

    public bool selectableEnemySkills = false;
    public bool selectableEnemy = false;
    public bool enemy2Dead = false;


    // Start is called before the first frame update
    void Start()
    {
        npc2healthCurrent = npc2healthMax;
        healthBar.SetMaxHealth(npc2healthMax);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(npc2healthCurrent);

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

        if (npc2healthCurrent <= 0)
        {
            npc2healthCurrent = 0;
            enemy2Dead = true;
        }
    }


}
