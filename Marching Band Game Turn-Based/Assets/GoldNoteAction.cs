using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldNoteAction : MonoBehaviour
{
    public GameObject letterManager;
    public GameObject referenceToSelf;

    public List<GameObject> buttonList;

    public void roundEndAction()
    {
        letterManager.GetComponent<LetterButton>().resetBoard();
        foreach (GameObject button in buttonList)
        {
            Debug.Log(button.ToString());
        }

    }
}
