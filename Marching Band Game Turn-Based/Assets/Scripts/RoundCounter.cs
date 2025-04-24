using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundCounter : MonoBehaviour
{
    private List<GameObject> TurnOrder = new List<GameObject>(); //creating a list of the players to control turn order

    public List<GameObject> EnemyList = new List<GameObject>();

    public GameObject player1; //assign values for players to then add to list
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public GameObject initialTarget; //initial enemy target goes here

    public GameObject turnHolder; //the person's turn that it currently is
    public GameObject targetedEnemy; //currently targeted enemy
    public string selectedButton; //button that was just pressed
    public int TurnOrderIndex = 0;

    public bool firstTurn = true;

    private List<Transform> targetList = new List<Transform>(); //remember any targets we've seen before

    public GameObject letterButton;

    // Start is called before the first frame update
    void Start()
    {
        CreateTurnOrderList(); //create our initial list of players
        MoveForwardTurn();

        SetNewTarget(initialTarget);
    }

    public void MoveForwardTurn()
    {
        foreach (GameObject player in TurnOrder)
        {
            player.GetComponent<BandMember>().deactivateTurn();
        }

        if (firstTurn)
        {
            Debug.Log("first turn");
        }
        else
        { 

            Debug.Log("selected Button in roundcounter is " + (selectedButton.ToString()));
            TurnOrder[TurnOrderIndex].GetComponent<BandMember>().attack(selectedButton.ToString(), targetedEnemy);
        }

        if (TurnOrderIndex != 0)
        {
            (TurnOrder[TurnOrderIndex - 1]).GetComponent<BandMember>().deactivateTurn();
        }
        
        if (TurnOrderIndex >= 3)
        {
            //(TurnOrder[TurnOrderIndex - 1]).GetComponent<BandMember>().IsMyTurn = false;
            (TurnOrder[TurnOrderIndex]).GetComponent<BandMember>().activateTurn();
            
            TurnOrderIndex = 0;
            //firstTurn = true;
            

        }
        else
        {
            (TurnOrder[TurnOrderIndex]).GetComponent<BandMember>().activateTurn();
            TurnOrderIndex += 1; //increase the amount of turns we've passed by 1


            firstTurn = false;
        }
    }

    public void CreateTurnOrderList()
    {
        //this would be based on speed values in the final game
        TurnOrder.Add(player1);
        TurnOrder.Add(player2);
        TurnOrder.Add(player3);
        TurnOrder.Add(player4);
    }

    public void EndRound()
    {
        Debug.Log("round ending");

        foreach (GameObject player in TurnOrder)
        {
            player.GetComponent<BandMember>().deactivateTurn();
        }

        TurnOrderIndex = 0;

        //firstTurn = true;


    }
    public void MakeAttack(int turns, GameObject Letter)
    {
        //GameObject currentPlayer = TurnOrder[turns - 1];
        //Debug.Log(currentPlayer);
        //currentPlayer.GetComponent<BandMember>().attack(Letter, enemy);
    }
    public void SetNewTarget(GameObject newTarget)
    {
        Transform targetTransform = newTarget.transform.Find("Target");
        targetedEnemy = newTarget;
        targetTransform.gameObject.SetActive(true);

        bool containCheck = (targetList.Contains(targetTransform));
        if (containCheck == false)
        {
            targetList.Add(targetTransform);
        }

        foreach (Transform target in targetList)
        {
            if (target != targetTransform)
            {
                target.gameObject.SetActive(false);
            }
        }
    }
    //end of round actions:
    public void ChordAll()
    {
        Debug.Log("all the same!");
        RemoveGoldenShield();

    }
    public void ChordDoubleDouble()
    {
        Debug.Log("first two and last two!");
        RemoveGoldenShield();

    }
    public void ChordAlpha()
    {
        Debug.Log("Alphabetical!");
        RemoveGoldenShield();

    }
    public void DamageAllEnemies()
    {
        foreach (GameObject enemy in EnemyList)
        {
            enemy.GetComponent<EnemyBehavior>().TakeDmg(20);
        }
    }
    public void RemoveGoldenShield()
    {
        foreach (GameObject enemy in EnemyList)
        {
            enemy.GetComponent<EnemyBehavior>().LoseSomeShield("#");
        }
    }
}
