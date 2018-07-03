using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class postcardScript : MonoBehaviour {

    public int holidayWish01, holidayWish02, holidayWish03;

    public Text postCardText;
    

	// Use this for initialization
	void Start () {

        postCardText.text = (" " + holidayWish01 + holidayWish02 + holidayWish03);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
