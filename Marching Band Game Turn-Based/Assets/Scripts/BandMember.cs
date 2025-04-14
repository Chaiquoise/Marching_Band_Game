using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //we have to do this so we can access UI things like a health bar

public class BandMember : MonoBehaviour
{
    public int hp = 10; //making it public so we can access this elsewhere/change it
    public int ap = 5; //ap = attack power, use this to dmg enemies

    public Slider HpBar; //player hp bar UI
    public GameObject MyTurn;

    public bool IsMyTurn = false;

    //should access health bar variable here and name it
    void Start()
    {
        HpBar.value = hp;
    }
    void Update()
    {
        if (IsMyTurn == true)
        {
            activateTurn();
        }
    }

    public void die()
    {
        //write code for when char dies here
        //probably access an animator and trigger a death animation
    }
    public void attack(string button, GameObject enemyName)
    {
        //write code for when we attack an enemy here
        enemyName.GetComponent<EnemyBehavior>().TakeDmg(5);
        enemyName.GetComponent<EnemyBehavior>().LoseSomeShield(button);
        Debug.Log(button);
        Debug.Log("ATTACK!!!");
    }
    public void heal(int amt)
    {
        //heal our char's hp by the amt we pass into this function
        hp += amt;
        //access our health bar child and update it with new value
    }
    public void takeDmg(int amt)
    {
        //character takes dmg from attack of amt passed in
        hp -= amt;
        //access our health bar child and update it with new value (but if it's less than 0 just set it to 0)
        if (hp <= 0) //if char hp ever falls under 0 then they should die (call die function on self)
        {
            die();
        }
    }
    public void activateTurn() //call this to display turn arrow
    {
        MyTurn.SetActive(true);
        IsMyTurn = false;
    }
    public void deactivateTurn() //call this to deactivate turn arrow
    {
        MyTurn.SetActive(false);
    }
}
