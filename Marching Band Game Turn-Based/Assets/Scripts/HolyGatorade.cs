using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyGatorade : MonoBehaviour
{
    public bool onCooldown = false;
    public GameObject izzy;

    public void SummonIzzy()
    {
        if (!onCooldown)
        {
            izzy.SetActive(true);
            onCooldown = true;
        }
    }

    public void ResetIzzyCooldown()
    {
        onCooldown = false;
    }
    
}
