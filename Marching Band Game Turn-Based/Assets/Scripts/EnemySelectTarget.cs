using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySelectTarget : MonoBehaviour
{
    

    public void SetTarget(GameObject target)
    {
        target.SetActive(true);
    }

    public void DeactivateTarget(GameObject othertarget)
    {
        othertarget.SetActive(false);
    }


}
