using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyBehavior : MonoBehaviour
{
    public int hp = 30; //making it public so we can access this elsewhere/change it
    public int ap = 2; //ap = attack power, use this to dmg player
    public bool shieldUp = true;

    public int reduceByShield = 3;
    public int lenShieldList = 4;

    public GameObject refToParent;

    public GameObject roundCounter;

    List<string> shieldNoteValues; 
    List<string> possibleNotes = new List<string> { "A", "A", "E", "E", "G", "G", "C", "C", "#" };

    public TextMeshProUGUI shieldDisplay;
    public Slider HpBar;

    //should access health bar variable here and name it

    void Start() 
    {
        HpBar.value = hp;
        CreateShield(lenShieldList);

        roundCounter.GetComponent<RoundCounter>().EnemyList.Add(refToParent);
    }

    public void Die() 
    {
        //write code for when enemy dies here
        //probably access an animator and trigger a death animation
    }

    public void Attack(GameObject playerName) 
    {
        //write code for when we attack a player here
    }

    public void TakeDmg(int amt) 
    {
        //enemy takes dmg from attack of amt passed in
        if (!shieldUp)
        {
            hp -= amt;
            HpBar.value = hp;
        }
        else
        {
            hp -= (amt / reduceByShield);
            HpBar.value = hp;
        }

        //access our health bar child and update it with new value (but if it's less than 0 just set it to 0)
        if (hp <= 0) //if enemy hp ever falls under 0 then they should die (call die function on self)
        {
            Die();
        }
    }

    public void LoseSomeShield(string note)
    {

        Debug.Log($"index 0 is {shieldNoteValues[0]}");
        Debug.Log($"value coming in from string is {note}");
        if (shieldNoteValues[0] == note)
        {
            shieldNoteValues.RemoveAt(0);
            shieldDisplay.text = string.Join("", shieldNoteValues);
        }

        //remove one of the shield vals
        //both from UI and from actual list in code
    }

    private void CreateShield(int lengthList) 
    {
        shieldNoteValues = new List<string>(); 

        for (int i = 0; i < lengthList; i++)
        {
            int idx = UnityEngine.Random.Range(0, 9); // Unity's Random.Range, end point IS included
            shieldNoteValues.Add(possibleNotes[idx]);
        }

        //Debug.Log(string.Join(", ", shieldNoteValues));
        shieldDisplay.text = string.Join("", shieldNoteValues);
        //generate a random list of notes for the shield values
        //display them with UI
    }
}
