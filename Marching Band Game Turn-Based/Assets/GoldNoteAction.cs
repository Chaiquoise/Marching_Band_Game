using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldNoteAction : MonoBehaviour
{
    public GameObject letterManager;
    public List<GameObject> buttonList;

    public void roundEndAction()
    {
        foreach (GameObject button in buttonList)
        {
            Debug.Log(button.ToString());
        }

    }
}
