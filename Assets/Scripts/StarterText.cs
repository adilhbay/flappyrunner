using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterText : MonoBehaviour {
    public bool gameNotStarted = true;
    public GameObject startText;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameNotStarted == false)
        {
            startText.SetActive(false);
            
           
        }
        if (Input.GetMouseButtonDown(0))
        {
            gameNotStarted = false;
        }

    }
}

