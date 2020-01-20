using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tube : MonoBehaviour {

    public bool dead = false;





    void OnCollisionEnter2D(Collision2D collision)
    {

        dead = true;

    }


}