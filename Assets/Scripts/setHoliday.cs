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
	

    public void setupHoliday (HolidayWish locationWish, HolidayWish attributeWish1, HolidayWish attributeWish2)
    {
        GameObject addedHoliday = Instantiate(postcardTemplate);
        addedHoliday.transform.SetParent(content.transform, false);
        addedHoliday.GetComponent<postcardScript>().locationWish = locationWish;
        addedHoliday.GetComponent<postcardScript>().attributeWish1 = attributeWish1;
        addedHoliday.GetComponent<postcardScript>().attributeWish2 = attributeWish2;

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
}
