using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC4Health : MonoBehaviour
{
    public HealthBar healthBar;
    public TacticsActions tacticsActions;
    public TacticsMove tacticsMove;

    public int npc4healthMax = 5;
    public int npc4healthCurrent;

    public bool selectableEnemySkills = false;
    public bool selectableEnemy = false;
    public bool enemy4Dead = false;


    // Start is called before the first frame update
    void Start()
    {
        npc4healthCurrent = npc4healthMax;
        healthBar.SetMaxHealth(npc4healthMax);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(npc4healthCurrent);

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

        if (npc4healthCurrent <= 0)
        {
            npc4healthCurrent = 0;
            enemy4Dead = true;
        }
    }


}
