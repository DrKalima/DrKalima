using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPuzzle1 : MonoBehaviour
{
    public Button menu;

    public GameObject panel;

    public PlayerHealth playerHealth;
    public PlayerMovement playerMovement;
    
    public NPC2Health npc2Health;
    public NPC3Health npc3Health;
    public NPC4Health npc4Health;

    void Start()
    {
        Button btn = menu.GetComponent<Button>();
        btn.onClick.AddListener(goToMenu);

        Canvas mr = panel.GetComponent<Canvas>();
        mr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.ExitTrigger)
        {
            Canvas mr = panel.GetComponent<Canvas>();
            mr.enabled = true;
        }

        if (playerMovement.StaminaEmpty)
        {
            Canvas mr = panel.GetComponent<Canvas>();
            mr.enabled = true;
        }
        else if (npc2Health.enemy2Dead && npc3Health.enemy3Dead && npc4Health.enemy4Dead)
        {
            Canvas mr = panel.GetComponent<Canvas>();
            mr.enabled = true;
        }
        else if (playerHealth.playerDead)
        {
            Canvas mr = panel.GetComponent<Canvas>();
            mr.enabled = true;
        }
        else if (Input.GetKeyDown("escape"))
        {
            Canvas mr = panel.GetComponent<Canvas>();
            mr.enabled = true;
        }
    }

    private void goToMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }   
}
