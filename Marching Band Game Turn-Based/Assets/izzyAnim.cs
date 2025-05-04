using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class izzyAnim : MonoBehaviour
{

    public Animator anim;
    // Start is called before the first frame update
    public void bringGatorade()
    {
        anim = gameObject.GetComponent<Animator>();
        anim.Play("Izzy");
    }
}
