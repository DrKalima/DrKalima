using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : TacticsMove
{
    public bool ExitTrigger = false;
    public bool playerAttackTurn = false;
    public bool EnemySkillSearching = true;
    public bool EnemySkillSpearFound = false;
    public bool playerEnqueueFinshed = false;

    public StaminaBar staminaBar;
        
    public TurnManager tuM;
    public TacticsActions tA;

    public Text staminaText;    
    
    // Start is called before the first frame update
    void Start()
    {
        playerHealth.playerStaminaCurrent = playerHealth.playerStaminaMax;
        staminaBar.SetMaxStamina(playerHealth.playerStaminaMax);
        Debug.Log("Starting staminaCurrent is" + " " + playerHealth.playerStaminaCurrent);

        staminaText.text = playerHealth.playerStaminaMax.ToString();
    }

    public void InitPlayer()
    {        
        Init();
    }

    // Update is called once per frame
    public void Update()
    {
        staminaText.text = playerHealth.playerStaminaCurrent.ToString();

        if (!turn)
        {
            Debug.Log("!turn Player");
            return;
        }
        else if (turn)
        {
            Debug.Log("turn Player");
        }

        if (playerHealth.playerStaminaCurrent < 1)
        {
            playerHealth.playerStaminaCurrent = 0;
            StaminaEmpty = true;
            return;
        }
        
        else if (!moving && !attackTurn)
        {
            FindSelectableTiles();
            CheckMouse();
            //if (EnemySkillSearching)
            //{
            //    SearchForSkills();
            //}
        }
        else if (moving)
        {            
            Move();
        }
        else if (!moving && playerAttackTurn)
        {
            SearchForSkills();

            if (EnemySkillSpearFound)
            {                
                if (npcHealth.selectableEnemySkills || npc2Health.selectableEnemySkills
                || npc3Health.selectableEnemySkills || npc4Health.selectableEnemySkills)
                {
                    if (tacticsActions.spearSkillUsed)
                    {
                        npcHealth.selectableEnemySkills = false;
                        npc2Health.selectableEnemySkills = false;
                        npc3Health.selectableEnemySkills = false;
                        npc4Health.selectableEnemySkills = false;
                        Debug.Log("Spear Skill Used");
                        playerMove.playerAttackTurn = false;
                        attackTurn = false;
                        moving = false;
                        tacticsActions.spearSkillUsed = false;
                        EnemySkillSpearFound = false;
                        EnemySkillSearching = true;
                        TurnManager.EndTurn();
                    }
                }                
            }

            AttackSearch();
            
            if (npcHealth.selectableEnemy || npc2Health.selectableEnemy || npc3Health.selectableEnemy || npc4Health.selectableEnemy 
                || npc2Health.selectableEnemy && npc3Health.selectableEnemy || npc2Health.selectableEnemy && npc4Health.selectableEnemy 
                || npc3Health.selectableEnemy && npc4Health.selectableEnemy || npc2Health.selectableEnemy && npc3Health.selectableEnemy && npc4Health.selectableEnemy)
            {
                Debug.Log("npcHealth.selectableEnemy && playerAttackTurn are true");
                CheckMouseOnAttack();
                if (!attackTurn && !playerAttackTurn)
                {
                    npcHealth.selectableEnemySkills = false;
                    npc2Health.selectableEnemySkills = false;
                    npc3Health.selectableEnemySkills = false;
                    npc4Health.selectableEnemySkills = false;
                    playerMove.playerAttackTurn = false;
                    attackTurn = false;
                    moving = false;
                    tacticsActions.spearSkillUsed = false;
                    EnemySkillSpearFound = false;
                    EnemySkillSearching = true;
                    Debug.Log("moving is false & attack turn is false and turn should end");
                    TurnManager.EndTurn();
                }
            }
            else
            {
                npcHealth.selectableEnemySkills = false;
                npc2Health.selectableEnemySkills = false;
                npc3Health.selectableEnemySkills = false;
                npc4Health.selectableEnemySkills = false;
                playerMove.playerAttackTurn = false;
                attackTurn = false;
                moving = false;
                tacticsActions.spearSkillUsed = false;
                EnemySkillSpearFound = false;
                EnemySkillSearching = true;
                TurnManager.EndTurn();
            }
            
            
            Debug.Log("The Current Stamina is " + playerHealth.playerStaminaCurrent);
            Debug.Log("Current npc1 health is " + npcHealth.npchealthCurrent);
            Debug.Log("Current npc2 health is " + npc2Health.npc2healthCurrent);
            Debug.Log("Current npc3 health is " + npc3Health.npc3healthCurrent);
            Debug.Log("Current npc4 health is " + npc4Health.npc4healthCurrent);
        }
        

        if (!ExitTrigger)
        {
            SearchForExitTrigger();
        }
        else if (ExitTrigger)
        {
            
        }

       // if (StaminaEmpty)
      //  {
      //      tuM.GameOver();
      //  }
    }    

    public void SkipMove()
    {
        if (turn && !moving && !attackTurn)
        {
            attackTurn = true;
            playerAttackTurn = true;
        }
    }

    public void SearchForSkills()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 1) || Physics.Raycast(transform.position, Vector3.forward, out hit, 2))
        {
            if (hit.collider.CompareTag("NPC"))
            {
                npcHealth.selectableEnemySkills = true;
                EnemySkillSpearFound = true;
                EnemySkillSearching = false;
            }
            else if (hit.collider.CompareTag("NPC2"))
            {
                npc2Health.selectableEnemySkills = true;
                EnemySkillSpearFound = true;
                EnemySkillSearching = false;
            }
            else if (hit.collider.CompareTag("NPC3"))
            {
                npc3Health.selectableEnemySkills = true;
                EnemySkillSpearFound = true;
                EnemySkillSearching = false;
            }
            else if (hit.collider.CompareTag("NPC4"))
            {
                npc4Health.selectableEnemySkills = true;
                EnemySkillSpearFound = true;
                EnemySkillSearching = false;
            }            
        }
    }

    public void CheckMouseOnAttack()
    {
        Debug.Log("Inside CheckMouseOnAttack()");
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("NPC"))
                {
                    Debug.Log("NPC found");
                    NPCHealth n = hit.collider.GetComponent<NPCHealth>();
                    if (n.selectableEnemy)
                    {
                        tA.AttackNPC1();
                        attackTurn = false;
                        playerAttackTurn = false;
                        Debug.Log("CheckMouseOnAttack has been executed");
                    }
                }
                else if (hit.collider.CompareTag("NPC2"))
                {
                    Debug.Log("NPC2 found");
                    NPC2Health n = hit.collider.GetComponent<NPC2Health>();
                    if (n.selectableEnemy)
                    {
                        tA.AttackNPC2();
                        attackTurn = false;
                        playerAttackTurn = false;
                        Debug.Log("CheckMouseOnAttack has been executed");
                    }
                }
                else if (hit.collider.CompareTag("NPC3"))
                {
                    Debug.Log("NPC3 found");
                    NPC3Health n = hit.collider.GetComponent<NPC3Health>();
                    if (n.selectableEnemy)
                    {
                        tA.AttackNPC3();
                        attackTurn = false;
                        playerAttackTurn = false;
                        Debug.Log("CheckMouseOnAttack has been executed");
                    }
                }
                else if (hit.collider.CompareTag("NPC4"))
                {
                    Debug.Log("NPC found");
                    NPC4Health n = hit.collider.GetComponent<NPC4Health>();
                    if (n.selectableEnemy)
                    {
                        tA.AttackNPC4();
                        attackTurn = false;
                        playerAttackTurn = false;
                        Debug.Log("CheckMouseOnAttack has been executed");
                    }
                }
            }
        }       
    }

    public void AttackSkip()
    {
        if (npcHealth.selectableEnemy || npc2Health.selectableEnemy 
            || npc3Health.selectableEnemy || npc4Health.selectableEnemy)
        {
            playerMove.playerAttackTurn = false;
            attackTurn = false;
            npcHealth.selectableEnemy = false;
            npc2Health.selectableEnemy = false;
            npc3Health.selectableEnemy = false;
            npc4Health.selectableEnemy = false;
            TurnManager.EndTurn();
        }        
        
    }

    public void SearchForExitTrigger()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, 1))
        {
            if(hit.collider.tag == "ExitTrigger1" || hit.collider.tag == "ExitTrigger2")
            {
                ExitTrigger = true;
                Debug.Log("On top of exit tile");
            }
            else
            {
                Debug.Log("Not on top of exit tile");
                return;
            }
        }
    }

    void CheckMouse()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Tile" || hit.collider.tag == "ExitTrigger1" || hit.collider.tag == "ExitTrigger2")
                {
                    TileScript t = hit.collider.GetComponent<TileScript>();

                    if (t.selectable)
                    {
                        MoveToTile(t);
                        pathBuilt = true;
                        StaminaUsage();

                        npcHealth.selectableEnemySkills = false;
                        npc2Health.selectableEnemySkills = false;
                        npc3Health.selectableEnemySkills = false;
                        npc4Health.selectableEnemySkills = false;
                        staminaBar.SetStamina(playerHealth.playerStaminaCurrent);
                    }
                }
            }
        }
    }
    
}
