using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject thePlatform;
    public Transform GeneraitonPoint;
    public float distanceBetween;
    public bool candoublejump;
    private float platformWidth;


   
    void Start () {
        platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
        
	}
   
    // Update is called once per frame
    void Update () {

        if (transform.position.x < GeneraitonPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween , transform.position.y, 4);
           
            Instantiate(thePlatform, transform.position, transform.rotation);
        }
		
	}
   
}
