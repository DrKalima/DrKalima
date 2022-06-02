using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC3Stats : TacticsMove
{
    private int StartingNPC3Strength = 2;
    private int StartingNPC3Dexterity = 2;
    private int StartingNPC3Accuracy = 2;
    private int StartingNPC3Defense = 2;
    private int StartingNPC3Luck = 0;
    private int StartingNPC3TurnSpeed = 2;

    public int CurrentNPC3Strength;
    public int CurrentNPC3Dexterity;
    public int CurrentNPC3Accuracy;
    public int CurrentNPC3Defense;
    public int CurrentNPC3Luck;
    public int CurrentNPC3TurnSpeed;

    public bool npc3StatsSet = false;

    // Start is called before the first frame update
    void Start()
    {
        CurrentNPC3Strength = StartingNPC3Strength;
        CurrentNPC3Dexterity = StartingNPC3Dexterity;
        CurrentNPC3Accuracy = StartingNPC3Accuracy;
        CurrentNPC3Defense = StartingNPC3Defense;
        CurrentNPC3Luck = StartingNPC3Luck;
        CurrentNPC3TurnSpeed = StartingNPC3TurnSpeed;

        npc3StatsSet = true;

        if (npc3StatsSet)
        {
            CheckTurnOrder();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
