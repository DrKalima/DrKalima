using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int StartingStrength = 1;
    private int StartingDexterity = 1;
    private int StartingAccuracy = 1;
    private int StartingDefense = 1;
    private int StartingLuck = 0;
    private int StartingTurnSpeed = 4;

    public int CurrentStrength;
    public int CurrentDexterity;
    public int CurrentAccuracy;
    public int CurrentDefense;
    public int CurrentLuck;
    public int CurrentTurnSpeed;

    public bool playerStatsSet = false;

    // Start is called before the first frame update
    void Start()
    {
        CurrentStrength = StartingStrength;
        CurrentDexterity = StartingDexterity;
        CurrentAccuracy = StartingAccuracy;
        CurrentDefense = StartingDefense;
        CurrentLuck = StartingLuck;
        CurrentTurnSpeed = StartingTurnSpeed;

        playerStatsSet = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
