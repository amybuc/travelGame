using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class dataManager : MonoBehaviour {

    DateTime currentDate;
    DateTime oldDate;

    public GameObject postcardRack;
    public GameObject stampPrefab;

    GameObject inventoryObject;

    //public List<GameObject> savedHoliday;

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
        Debug.Log("Difference in seconds: " + difference.TotalSeconds);

        // Minus the current time from the time that the app was closed/paused
        // Minus this amount from the counters of all active holidays
        // Check the syspref arrays for the stamp inventory, and foreach stamp in the list, addstamptoinventory with that stamp slug


        if (ES3.KeyExists("myInteger"))
        {
            int myInteger = ES3.Load<int>("myInteger");
            Debug.Log("My saved integer = " + myInteger);
        }
        else if (!ES3.KeyExists("myInteger"))
        {
            Debug.Log("No Inty found :c");
        }

        //Deleting existing postcard save file - comment out as needed
       //if (ES2.Exists("myFile.txt?tag=savedHolidayData"))
           //ES2.Delete("myFile.txt?tag=savedHolidayData");


        // If there's a List to load, load it.
        if (ES2.Exists("myFile.txt?tag=savedHolidayData"))
        {
            Debug.Log("LoadFile found!");
            List<postcardScript> myLoadedHolidays;
            myLoadedHolidays = ES2.LoadList<postcardScript>("myFile.txt?tag=savedHolidayData");

            Debug.Log("LOADED holiday wish #1: " + myLoadedHolidays[0].locationWish.stampName);


            foreach(postcardScript loadedPostcard in myLoadedHolidays)
            {
                Debug.Log("Loaded holiday requires " + loadedPostcard.locationWish);
                GameObject loadedStamp = Instantiate(stampPrefab);
                stampPrefab.transform.SetParent(postcardRack.transform, false);

                if (loadedPostcard.onHoliday == false)
                {
                    loadedStamp.GetComponent<postcardScript>().locationWish = loadedPostcard.locationWish;
                    loadedStamp.GetComponent<postcardScript>().attributeWish1 = loadedPostcard.attributeWish1;
                    loadedStamp.GetComponent<postcardScript>().attributeWish2 = loadedPostcard.attributeWish2;

                }
                else if (loadedPostcard.onHoliday == false)
                {
                    loadedStamp.GetComponent<postcardScript>().counterTimeLeft = loadedPostcard.counterTimeLeft;
                    loadedStamp.GetComponent<postcardScript>().holidayScoreTotal = loadedPostcard.holidayScoreTotal;
                    //ALSO LOAD FEEDBACK MESSAGES

                }


            }


        }
        else if (!ES2.Exists("myFile.txt?tag=savedHolidayData"))
        {
            Debug.Log("No saved holidays found :c");
        }
            

        // Holidays are going to be trickier, restock the holiday postcards
        if (ES2.Exists("savedHolidays"))
        {
            /*
            savedHoliday = ES2.LoadList<GameObject>("savedHoliday");

            Debug.Log("SavedHoliday found with " + savedHoliday[0].name);

            foreach (GameObject loadedHoliday in savedHoliday)
            {
                Debug.Log("Holiday one wishes: " + loadedHoliday.GetComponent<postcardScript>().attributeWish1 + loadedHoliday.GetComponent<postcardScript>().attributeWish2 + loadedHoliday.GetComponent<postcardScript>().locationWish);
            }
            */
        }
        else if (!ES2.Exists("savedHolidays"))
        {
            Debug.Log("savedHolidays list does not exist! :c");
        }
		
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

        //Save all active holidays and their current times, as well as holidays-in-progress and their requirements

        List<GameObject> savedHoliday = new List<GameObject>();
        savedHoliday.AddRange(GameObject.FindGameObjectsWithTag("ScrollViewPostCardButton"));
        Debug.Log("name of holiday to be saved #1: " + savedHoliday[0].name);
        List<postcardScript> savedHolidayData = new List<postcardScript>();
        foreach (GameObject savedHolidayIndividual in savedHoliday)
        {
            savedHolidayData.Add(savedHolidayIndividual.GetComponent<postcardScript>());
            Debug.Log("Saved Holiday Requires: " + savedHolidayIndividual.GetComponent<postcardScript>().locationWish.stampName);
        }

        ES2.Save(savedHolidayData, "myFile.txt?tag=savedHolidayData");


        ES3.Save<int>("myInteger", 123);




    }

    private void OnApplicationPause(bool pause)
    {
        //Same as ApplicationQuit
    }
}
