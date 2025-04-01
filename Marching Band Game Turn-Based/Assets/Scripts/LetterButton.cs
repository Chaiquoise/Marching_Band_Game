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


    private int A_pressed = 0; //ints to check if the letter chosen has already been pressed
    private int E_pressed = 0;
    private int G_pressed = 0;
    private int C_pressed = 0;

    public int maxTurnsPassed = 4; // how many turns we can take before all characters have taken an action

    private List<GameObject> buttonList = new List<GameObject>(); //creating a list of the letters we'll be spawning to access later

    void Start()
    {
  //actually adding those gameobjects to our empty gameobject list
        buttonList.Add(E_button);
        buttonList.Add(G_button);
        buttonList.Add(C_button);
    }

    // This function will be called when the button is pressed
    public void ActivateLetter(GameObject ChosenLetter)
    {
        IncrementRound(); //move us forward one round once a button is pressed

        
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

        
        A_pressed = 0; //reset all pressed amts to 0
        E_pressed = 0;
        G_pressed = 0;
        C_pressed = 0;
        
    }

}

