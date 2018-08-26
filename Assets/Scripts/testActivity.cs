using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Newtonsoft.Json;

public class testActivity : MonoBehaviour {

    public Text holidayDescription;

    public GameObject dialogueBox;

    public HolidayWish locationWish;
    public HolidayWish attributeWish1;
    public HolidayWish attributeWish2;


    public int holidayStat01;
    public int holidayStat02;
    public int holidayStat03;

    public GameObject resourcesObject;

    public GameObject holidaySetter;

    public GameObject postcardView;
    public Text postcardViewText;
    public GameObject stampRack;
    public GameObject miniPostcardRack;

    //Marketplace UI
    public GameObject stampMarketCanvas;

    //JSON
    public static List<HolidayWish> wishDatabase;



    void Start () {

        BuildHolildayDatabase();
        Debug.Log("The First holiday wish in the database is of type " + wishDatabase[0].stampName + "and has has a fun requirement of " + wishDatabase[0].funRequirement);
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void BuildHolildayDatabase()
    {
        wishDatabase = JsonConvert.DeserializeObject<List<HolidayWish>>(Resources.Load<TextAsset>("JSON/holidayDatabase").ToString());
    }

    public void updateHoliday()
    {

        //implementing JSON - randomise the first wish among the locations, then randomise the other two from holiday attributes
        locationWish = wishDatabase[Random.Range(0, 6)];
        attributeWish1 = wishDatabase[Random.Range(7, wishDatabase.Count)];
        attributeWish2 = wishDatabase[Random.Range(7, wishDatabase.Count)];

        //Check the two attributes aren't the same
        while (attributeWish1.wishID == attributeWish2.wishID)
        {
            attributeWish2 = wishDatabase[Random.Range(7, wishDatabase.Count)];
        }

        //HOLIDAY CHECKS - checking some clashing locations haven't been chosen together
        //Check warm weather isn't with cool
        while (attributeWish1.wishID == "13" && attributeWish2.wishID == "14" || attributeWish2.wishID == "13" && attributeWish1.wishID == "14")
        {
            attributeWish2 = wishDatabase[Random.Range(7, wishDatabase.Count)];
        }
        //Check cool weather isn't with beach
        //Check extravagant isn't with cheap


        holidayStat01 = Random.Range(1, 6);
        holidayStat02 = Random.Range(1, 6);

        dialogueBox.SetActive(true);

        while (holidayStat02 == holidayStat01)
        {
            holidayStat02 = Random.Range(1, 6);
        }

        holidayStat03 = Random.Range(1, 6);

        while (holidayStat03 == holidayStat02 || holidayStat03 == holidayStat01)
        {
            holidayStat03 = Random.Range(1, 6);
        }

        holidayDescription.text = " " + resourcesObject.GetComponent<holidayWishes>().holidayRequestPt1[Random.Range(1, resourcesObject.GetComponent<holidayWishes>().holidayRequestPt1.Length)] + " I want to go to the " + locationWish.stampName + ", and I want it to be " + attributeWish1.stampName + " and " + attributeWish2.stampName + "!";
    }

    public void closeBox()
    {
        dialogueBox.SetActive(false);
    }

    public void onHolidayAccept()
    {
        holidaySetter.GetComponent<setHoliday>().setupHoliday(locationWish, attributeWish1, attributeWish2);
        dialogueBox.SetActive(false);
    }

    public void onMiniPostcardClick()
    {

        //showing and hiding the correct UI elements
        dialogueBox.SetActive(false);
        miniPostcardRack.SetActive(false);
        stampRack.SetActive(true);
        postcardView.SetActive(true);

        //filling out the postcard UI element with the info of the clicked holiday
        postcardViewText.text = "Location: " + EventSystem.current.currentSelectedGameObject.GetComponent<postcardScript>().locationWish.stampName + " Wishes: " + EventSystem.current.currentSelectedGameObject.GetComponent<postcardScript>().attributeWish1.stampName + " and " +  EventSystem.current.currentSelectedGameObject.GetComponent<postcardScript>().attributeWish2.stampName;


    }

    public void onStampClick()
    {
        /*
        Text stampText = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>();
        stampText.text = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<objectStampScript>().description;
        */
    }

    public void onPostcardClose()
    {
        dialogueBox.SetActive(false);
        miniPostcardRack.SetActive(true);
        stampRack.SetActive(false);
        postcardView.SetActive(false);
    }

    public void onMarketButtonClick()
    {
        stampMarketCanvas.SetActive(true);
    }

    public void onMarketCloseButtonClicked()
    {
        stampMarketCanvas.SetActive(false);
    }



}
