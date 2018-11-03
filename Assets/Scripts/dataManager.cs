using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class dataManager : MonoBehaviour {

    DateTime currentDate;
    DateTime oldDate;

    GameObject inventoryObject;

	// Use this for initialization
	void Start () {

        inventoryObject = GameObject.Find("stampManager");

        //Log current time
        currentDate = System.DateTime.Now;

        //Grab old time from playerprefs as a long
        long temp = Convert.ToInt64(PlayerPrefs.GetString("sysString"));

        //Convert old time from binary to a DataTime variable
        DateTime oldDate = DateTime.FromBinary(temp);
        Debug.Log("oldDate: " + oldDate);

        //Use Subtract method and store the result as a timespan variable
        TimeSpan difference = currentDate.Subtract(oldDate);
        Debug.Log("Difference: " + difference);

        // Minus the current time from the time that the app was closed/paused
        // Minus this amount from the counters of all active holidays
        // Check the syspref arrays for the stamp inventory, and foreach stamp in the list, addstamptoinventory with that stamp slug
        // Holidays are going to be trickier, restock the holiday postcards
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnApplicationQuit()
    {
        //Log current Time
        PlayerPrefs.SetString("sysString", System.DateTime.Now.ToBinary().ToString());
        Debug.Log("Saving this date to prefs: " + System.DateTime.Now);

        //Save all stampslugs in inventory into a sysprefs array of strings!
        string[] inventoryLog;

        //Save all active holidays and their current times, as well as holidays-in-progress and their requirements

    }

    private void OnApplicationPause(bool pause)
    {
        //Same as ApplicationQuit
    }
}
