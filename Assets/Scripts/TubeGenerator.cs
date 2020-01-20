using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeGenerator : MonoBehaviour {

    public GameObject Object;
    float x = 1.1f;

   void Update()
    {
        float y = Random.Range(-2.122f, -1.018f);
        
        if (x < 1000)
        {
           
            Instantiate(Object, new Vector3(x * 2.5f, y, 0), Quaternion.identity);
            x++;
           

        }
       


       

    }
}
