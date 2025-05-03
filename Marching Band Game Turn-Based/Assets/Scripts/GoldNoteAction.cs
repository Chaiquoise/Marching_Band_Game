using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldNoteAction : MonoBehaviour
{
    public GameObject letterManager;
    public GameObject roundCounter;

    public List<GameObject> buttonList;
    public List<GameObject> enemiesInScene;

    public List<string> convertedLetters;

    public void roundEndAction()
    {
        letterManager.GetComponent<LetterButton>().resetBoard();
        foreach (GameObject button in buttonList) //converting gameobjects with comparable names depending on letter types (still in order)
        {
            Debug.Log(button.ToString());


            if (button.ToString() == "A1 (UnityEngine.GameObject)" || button.ToString() == "A2 (UnityEngine.GameObject)" || button.ToString() == "A3 (UnityEngine.GameObject)" || button.ToString() == "A4 (UnityEngine.GameObject)")
            {
                Debug.Log("button being changed to A");
                convertedLetters.Add("A");
            }
            else if (button.ToString() == "E1 (UnityEngine.GameObject)" || button.ToString() == "E2 (UnityEngine.GameObject)" || button.ToString() == "E3 (UnityEngine.GameObject)" || button.ToString() == "E4 (UnityEngine.GameObject)")
            {
                Debug.Log("button being changed to E");
                convertedLetters.Add("E");
            }
            else if (button.ToString() == "G1 (UnityEngine.GameObject)" || button.ToString() == "G2 (UnityEngine.GameObject)" || button.ToString() == "G3 (UnityEngine.GameObject)" || button.ToString() == "G4 (UnityEngine.GameObject)")
            {
                Debug.Log("button being changed to G");
                convertedLetters.Add("G");
            }
            else
            {
                Debug.Log("button being changed from " + button.ToString() + " to C");
                convertedLetters.Add("C");
            }
        }

        //now we need to determine if there are any specific patterns that would create a chord
        //check first if all notes are the same
        if ((convertedLetters[0] == convertedLetters[3]) && (convertedLetters[2] == convertedLetters[1]) && (convertedLetters[1] == convertedLetters[3]))
        {
            
            roundCounter.GetComponent<RoundCounter>().ChordAll();
        }
        else if ((convertedLetters[0] == convertedLetters[1]) && (convertedLetters[2] == convertedLetters[3]))
        {
            
            roundCounter.GetComponent<RoundCounter>().ChordDoubleDouble();
        }
        else if ((convertedLetters[0] == "A") && (convertedLetters[1] == "C") && (convertedLetters[2] == "E") && (convertedLetters[3] == "G"))
        {
            
            roundCounter.GetComponent<RoundCounter>().ChordAlpha();
        }

        roundCounter.GetComponent<RoundCounter>().DamageAllEnemies();
        //roundCounter.GetComponent<RoundCounter>().RemoveGoldenShield();
        letterManager.GetComponent<LetterButton>().endGoldenNote();




    }
}