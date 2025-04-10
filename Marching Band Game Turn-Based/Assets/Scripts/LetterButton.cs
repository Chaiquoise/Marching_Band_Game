using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterButton : MonoBehaviour
{
    public static int turnsPassed = 0; // tracks amount of turns that have been taken so far
    public float offsetAmt = 20f;  // Amount by which to offset each new object
    public float yPos;
    public float xPos;

    public GameObject A_button; //initialize gameobjects w/ relevant names
    public GameObject E_button;
    public GameObject G_button;
    public GameObject C_button;


    public GameObject A2_button; //second set of 2nd space objects
    public GameObject E2_button;
    public GameObject G2_button;
    public GameObject C2_button;

    public GameObject A3_button; //third set
    public GameObject E3_button;
    public GameObject G3_button;
    public GameObject C3_button;


    public GameObject A4_button; //fourth set
    public GameObject E4_button;
    public GameObject G4_button;
    public GameObject C4_button;

    public GameObject enemy;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;


    public bool secondSelect = false;

    private int A_pressed = 0; //ints to check if the letter chosen has already been pressed
    private int E_pressed = 0;
    private int G_pressed = 0;
    private int C_pressed = 0;

    public GameObject lastClicked = null;

    public int maxTurnsPassed = 3; // how many turns we can take before all characters have taken an action

    private List<GameObject> buttonList = new List<GameObject>(); //creating a list of the letters we'll be spawning to access later

    public GameObject gameManager;

    void Start()
    {
  //actually adding those gameobjects to our empty gameobject list
        buttonList.Add(E_button);
        buttonList.Add(G_button);
        buttonList.Add(C_button);

        GameObject gameManager = GameObject.Find("GameManage");
    }

    // This function will be called when the button is pressed
    public void ActivateLetter(GameObject ChosenLetter)
    {

            IncrementRound(); //move us forward one round once a button is pressed
            //calling the RoundCounter to make sure we know what round it is + update our turn arrow

                
            gameManager.GetComponent<RoundCounter>().MoveForwardTurn();
            gameManager.GetComponent<RoundCounter>().MakeAttack(turnsPassed, ChosenLetter);



        if (ChosenLetter == A_button) //if we selected the A button
            {
                A_pressed++;
                if (A_pressed == 1)
                {
                    buttonList.Add(A_button);
                }
                else if (A_pressed == 2)
                {
                    buttonList.Add(A2_button);
                    ChosenLetter = A2_button;
                }
                else if (A_pressed == 3)
                {
                    buttonList.Add(A3_button);
                    ChosenLetter = A3_button;
                }
                else if (A_pressed == 4)
                {
                    buttonList.Add(A4_button);
                    ChosenLetter = A4_button;
                }

            }
            else if (ChosenLetter == E_button) //if we selected the E button
            {
                E_pressed++;
                if (E_pressed == 1)
                {
                    buttonList.Add(E_button);
                }
                else if (E_pressed == 2)
                {
                    buttonList.Add(E2_button);
                    ChosenLetter = E2_button;
                }
                else if (E_pressed == 3)
                {
                    buttonList.Add(E3_button);
                    ChosenLetter = E3_button;
                }
                else if (E_pressed == 4)
                {
                    buttonList.Add(E4_button);
                    ChosenLetter = E4_button;
                }
            }
            else if (ChosenLetter == G_button) //if we selected the G button
            {
                G_pressed++;
                if (G_pressed == 1)
                {
                    buttonList.Add(G_button);
                }
                else if (G_pressed == 2)
                {
                    buttonList.Add(G2_button);
                    ChosenLetter = G2_button;
                }
                else if (G_pressed == 3)
                {
                    buttonList.Add(G3_button);
                    ChosenLetter = G3_button;
                }
                else if (G_pressed == 4)
                {
                    buttonList.Add(G4_button);
                    ChosenLetter = G4_button;
                }
            }
            else //if we selected the C button
            {
                C_pressed++;
                if (C_pressed == 1)
                {
                    buttonList.Add(C_button);
                }
                else if (C_pressed == 2)
                {
                    buttonList.Add(C2_button);
                    ChosenLetter = C2_button;
                }
                else if (C_pressed == 3)
                {
                    buttonList.Add(C3_button);
                    ChosenLetter = C3_button;
                }
                else if (C_pressed == 4)
                {
                    buttonList.Add(C4_button);
                    ChosenLetter = C4_button;
                }
            }



            if (turnsPassed <= maxTurnsPassed) //if not all characters have taken actions
            {

                // Set the letter to be active
                ChosenLetter.SetActive(true);

                // Calculate the new position based on the number of button presses
                Vector3 newPosition = new Vector3(turnsPassed * offsetAmt + xPos, yPos, 0); // Adjusting the x-position

                // Apply the new position to the ChosenLetter
                ChosenLetter.transform.position = newPosition;
            }
            else //if all band members have taken actions
            {
                endOfRoundAction(); //cue the special end of round effect
                resetBoard(); //reset our board to the way it was at first
            }
    }

    public void IncrementRound() //move us forward one round
    {
        turnsPassed++; //increment our turns passed by one
    }
    /*
    public void UndoAction() //undo the choice we just made
    {

        if (turnsPassed > 0) // Ensure there are actions to undo
        {
            // Log the current state (just for debugging)
            Debug.Log("Turns passed: " + turnsPassed + ", last action: " + buttonList[turnsPassed - 1]);

            // Remove the last action from buttonList
            GameObject lastButton = buttonList[turnsPassed - 1]; // Get the last button

            decrementLastButton(lastButton);
            lastButton.SetActive(false); // Deactivate it (undo its effect)

            // Decrement turnsPassed
            turnsPassed--; // undo the turn
        }
        else
        {
            Debug.Log("No actions to undo.");
        }
    }
    */

    public void endOfRoundAction()
    {
        //here's where the special end-of-round effect would happen
    }
    public void resetBoard()
    {
        //reset the whole board back to where it started
        turnsPassed = 0;

        foreach (GameObject button in buttonList)
        {
            button.SetActive(false);
        }

        gameManager.GetComponent<RoundCounter>().EndRound();

        A_pressed = 0; //reset all pressed amts to 0
        E_pressed = 0;
        G_pressed = 0;
        C_pressed = 0;

        //Debug.Log(buttonList.ToString());
        buttonList = new List<GameObject>(); //reset list to contain no objects since we're resetting the scene
        
    }
    public void decrementLastButton(GameObject button)
    {
        if (button == A_button || button == A2_button || button == A3_button || button == A4_button)
        {
            A_pressed--;
        }
        else if (button == E_button || button == E2_button || button == E3_button || button == E4_button)
        {
            E_pressed--;
        }
        else if (button == G_button || button == G2_button || button == G3_button || button == G4_button)
        {
            G_pressed--;
        }
        else
        {
            C_pressed--;
        }

        buttonList.RemoveAt(turnsPassed - 1); // Remove the last button from the list
    }

}

