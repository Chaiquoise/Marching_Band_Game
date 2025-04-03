using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpen : MonoBehaviour

//gives us an options panel on the same screen after clicking a button
{

    public GameObject Panel;



    public void OpenPanel()
    {
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;  //need to add this line to make the toggling work

            Panel.SetActive(!isActive);  //this makes it so the panel stays open
                                         //change "true" to "!isActive" to make the toggling work
        }
    }

    public void ClosePanel()
    {
        Panel.SetActive(false);
    }
}