using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC4Stats : TacticsMove
{
    private int StartingNPC4Strength = 2;
    private int StartingNPC4Dexterity = 2;
    private int StartingNPC4Accuracy = 2;
    private int StartingNPC4Defense = 2;
    private int StartingNPC4Luck = 0;
    private int StartingNPC4TurnSpeed = 3;

    public int CurrentNPC4Strength;
    public int CurrentNPC4Dexterity;
    public int CurrentNPC4Accuracy;
    public int CurrentNPC4Defense;
    public int CurrentNPC4Luck;
    public int CurrentNPC4TurnSpeed;

    public bool npc4StatsSet = false;

    // Start is called before the first frame update
    void Start()
    {
        CurrentNPC4Strength = StartingNPC4Strength;
        CurrentNPC4Dexterity = StartingNPC4Dexterity;
        CurrentNPC4Accuracy = StartingNPC4Accuracy;
        CurrentNPC4Defense = StartingNPC4Defense;
        CurrentNPC4Luck = StartingNPC4Luck;
        CurrentNPC4TurnSpeed = StartingNPC4TurnSpeed;

        npc4StatsSet = true;

        if (npc4StatsSet)
        {
            CheckTurnOrder();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
