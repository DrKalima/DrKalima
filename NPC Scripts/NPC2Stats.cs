using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC2Stats : TacticsMove
{
    private int StartingNPC2Strength = 2;
    private int StartingNPC2Dexterity = 2;
    private int StartingNPC2Accuracy = 2;
    private int StartingNPC2Defense = 2;
    private int StartingNPC2Luck = 0;
    private int StartingNPC2TurnSpeed = 1;

    public int CurrentNPC2Strength;
    public int CurrentNPC2Dexterity;
    public int CurrentNPC2Accuracy;
    public int CurrentNPC2Defense;
    public int CurrentNPC2Luck;
    public int CurrentNPC2TurnSpeed;

    public bool npc2StatsSet = false;

    // Start is called before the first frame update
    void Start()
    {
        CurrentNPC2Strength = StartingNPC2Strength;
        CurrentNPC2Dexterity = StartingNPC2Dexterity;
        CurrentNPC2Accuracy = StartingNPC2Accuracy;
        CurrentNPC2Defense = StartingNPC2Defense;
        CurrentNPC2Luck = StartingNPC2Luck;
        CurrentNPC2TurnSpeed = StartingNPC2TurnSpeed;

        npc2StatsSet = true;

        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
