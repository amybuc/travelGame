using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YChecker : MonoBehaviour {

    public GameObject Stampers;
    public Text thisText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        thisText.text = (" " + Stampers.transform.position.y);
		
	}
}
