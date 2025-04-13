using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySelectTarget : MonoBehaviour
{
    public GameObject parentEnemy;

    public void SetTarget(GameObject target)
    {
        target.SetActive(true);
        //RoundCounter.GetComponent<RoundCounter>().targetedEnemy = parentEnemy;
    }

    public void DeactivateTarget(GameObject othertarget)
    {
        othertarget.SetActive(false);
    }

    public void resetTargetManager(GameObject manager)
    {
        manager.GetComponent<RoundCounter>().SetNewTarget(parentEnemy);
    }

}
