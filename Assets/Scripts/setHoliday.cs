using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setHoliday : MonoBehaviour {

    public GameObject postcardTemplate;

    public GameObject content;

    [Tooltip("Holiday Counter Button")]
    public Text activeHolidayCountText;
    public GameObject activeHolidayCountButton;

    

	// Use this for initialization
	void Start () {

        //Checking if the amount of active holidays the player has is equal to 0 - if so, hiding the button display!
        if (GameObject.FindGameObjectsWithTag("ScrollViewPostCardButton").Length == 0)
        {
            activeHolidayCountButton.SetActive(false);
        }
        else
        {
            activeHolidayCountButton.SetActive(true);
        }

    }
	

    public void setupHoliday (HolidayWish locationWish, HolidayWish attributeWish1, HolidayWish attributeWish2, int WishInt1, int WishInt2, int WishInt3)
    {
        GameObject addedHoliday = Instantiate(postcardTemplate);
        //Add holiday with attributes to some kind of list??
        addedHoliday.transform.SetParent(content.transform, false);
        addedHoliday.GetComponent<postcardScript>().locationWish = locationWish;
        addedHoliday.GetComponent<postcardScript>().attributeWish1 = attributeWish1;
        addedHoliday.GetComponent<postcardScript>().attributeWish2 = attributeWish2;

        addedHoliday.GetComponent<postcardScript>().locWish = WishInt1;
        addedHoliday.GetComponent<postcardScript>().actWish1 = WishInt2;
        addedHoliday.GetComponent<postcardScript>().actWish2 = WishInt3;

        //Updating the display that shows the amount of active holidays the player has!
        activeHolidayCountText.text =  GameObject.FindGameObjectsWithTag("ScrollViewPostCardButton").Length.ToString();

        //Checking if the amount of active holidays the player has is equal to 0 - if so, hiding the button display!
        if (GameObject.FindGameObjectsWithTag("ScrollViewPostCardButton").Length == 0)
        {
            activeHolidayCountButton.SetActive(false);
        }
        else
        {
            activeHolidayCountButton.SetActive(true);
        }


    }

    //To be done - in setupHoliday(), instead of instantiating a postcard, add it to an array, then refresh the postcard rack with the array every time a new one is added or one is removed etc.
    //THEN - you can set timers up within the postcard script when theyre on holiday. There'll be a function specifically for making a dialogue box with a reward, with input for a message and such.
}
