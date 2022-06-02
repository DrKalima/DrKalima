using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPC4Move : TacticsMove
{
    GameObject target;

    public bool npcAttackTurn = false;
    public bool npcEnqueueFinished = false;
    public bool npc4Turn = false;

    //patrolTile info
    Stack<GameObject> patrolStack = new Stack<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
        patrolStack.Push(GameObject.FindGameObjectWithTag("PatrolTile8"));
        patrolStack.Push(GameObject.FindGameObjectWithTag("PatrolTile7"));

    }

    public void InitNPC4()
    {
        Debug.Log(" InitNPC4()");
        Init();
    }

    // Update is called once per frame
    public void Update()
    {

        Debug.DrawRay(transform.position, transform.forward);
        if (!turn)
        {
            return;
        }


        if (!charFound && !moving)
        {
            npc4Turn = true;
            FindNextPartolTile();
            CalculatePathPatrol();
            FindSelectableTiles();
            if (patrolStack.Count <= 1)
            {
                
                patrolStack.Push(GameObject.FindGameObjectWithTag("PatrolTile8"));
                patrolStack.Push(GameObject.FindGameObjectWithTag("PatrolTile7"));
            }
            actualTargetTile.target = true;
        }
        else if (!charFound && moving)
        {
            MovePatrol();
            
        }
        else if (charFound && !moving || charFoundLeft && !moving || charFoundRight && !moving)
        {           
            move = 6;
            FindNearestTarget();
            CalculatePath();
            FindSelectableTiles();
            actualTargetTile.target = true;
        }
        else if (charFound && moving || charFoundLeft && moving || charFoundRight && moving)
        {
            MoveEnemy();
        }

    }

    protected void FindNextPartolTile()
    {


        if (turn)
        {
            Debug.Log(patrolStack.Peek());
            target = patrolStack.Pop();

            Debug.Log("The count is" + " " + patrolStack.Count);

        }
        else
        {
            return;
        }
    }

    public void SearchForChar() //needs to search for "player"
    {
        Debug.Log("Searching for Player NPC4");
        RaycastHit hit;
        // Does the ray intersect the player, does the enemy see player
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2.0f) && hit.transform.tag == "Player")
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit front");
            charFound = true;
            if (charFound)
            {
                Debug.Log("Search Forward charFound is True");
            }
        }
        else if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2.0f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.white);
            Debug.Log("Did not Hit front");

            //charFound = false;
        }
    }

    public void SearchForCharSides()
    {
        Debug.Log("Searching for Player NPC4");
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 1.0f) && hit.transform.tag == "Player")
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.red);
            Debug.Log("Did Hit side");

            charFoundRight = true;
        }
        else if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 1.0f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.white);
            Debug.Log("Did not Hit side");

            //charFoundRight = false;
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.right), out hit, 1.0f) && hit.transform.tag == "Player")
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.right) * hit.distance, Color.red);
            Debug.Log("Did Hit side");

            charFoundLeft = true;
        }
        else if (!Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.right), out hit, 1.0f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.right) * hit.distance, Color.white);
            Debug.Log("Did not Hit side");

            //charFoundLeft = false;
        }
    }

    private void CalculatePath()
    {
        TileScript targetTile = GetTargetTile(target);
        //FindPath() performs A* and is inherited from TacticsMove
        FindPath(targetTile);
    }

    private void CalculatePathPatrol()
    {
        TileScript targetTile = GetTargetTile(target);
        //FindPathPatrol() performs A* and is inherited from TacticsMove
        FindPathPatrol(targetTile);
    }

    private void FindNearestTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");

        GameObject nearest = null;
        float distance = Mathf.Infinity;

        foreach (GameObject obj in targets)
        {
            float d = Vector3.Distance(transform.position, obj.transform.position);

            if (d < distance)
            {
                distance = d;
                nearest = obj;
            }
        }

        target = nearest;
    }

}
