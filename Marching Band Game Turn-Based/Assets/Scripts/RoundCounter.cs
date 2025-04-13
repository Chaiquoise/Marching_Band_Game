using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundCounter : MonoBehaviour
{
    private List<GameObject> TurnOrder = new List<GameObject>(); //creating a list of the players to control turn order

    public GameObject player1; //assign values for players to then add to list
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public GameObject turnHolder; //the person's turn that it currently is
    public GameObject targetedEnemy; //currently targeted enemy
    public string selectedButton; //button that was just pressed

    public GameObject enemy;

    private int TurnOrderIndex = 0;

    public bool firstTurn = true;

    // Start is called before the first frame update
    void Start()
    {
        CreateTurnOrderList(); //create our initial list of players
        MoveForwardTurn();
    }

    public void MoveForwardTurn()
    {
        foreach (GameObject player in TurnOrder)
        {
            player.GetComponent<BandMember>().deactivateTurn();
        }

        if (TurnOrderIndex != 0)
        {
            (TurnOrder[TurnOrderIndex - 1]).GetComponent<BandMember>().deactivateTurn();
        }
        
        if (TurnOrderIndex >= 3)
        {
            //(TurnOrder[TurnOrderIndex - 1]).GetComponent<BandMember>().IsMyTurn = false;
            (TurnOrder[TurnOrderIndex]).GetComponent<BandMember>().activateTurn();
            (TurnOrder[TurnOrderIndex]).GetComponent<BandMember>().attack(selectedButton, targetedEnemy);
            TurnOrderIndex = 0;
            firstTurn = true;
            

        }
        else
        {
            (TurnOrder[TurnOrderIndex]).GetComponent<BandMember>().activateTurn();
            TurnOrderIndex += 1; //increase the amount of turns we've passed by 1
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

    }
    public void MakeAttack(int turns, GameObject Letter)
    {
        //GameObject currentPlayer = TurnOrder[turns - 1];
        //Debug.Log(currentPlayer);
        //currentPlayer.GetComponent<BandMember>().attack(Letter, enemy);
    }
    public void SetNewTarget(GameObject newTarget)
    {
        targetedEnemy = newTarget;
    }
}
