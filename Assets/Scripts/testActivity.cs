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

    public int random1;
    public int random2;
    public int random3;

    public GameObject resourcesObject;
    public GameObject stampManager;

    public GameObject holidaySetter;

    public GameObject postcardView;
    public Text postcardViewText;
    public Text postcardViewText01;
    public Text postcardViewText02;
    public Text postcardViewText03;
    public Image postcardWishIcon01;
    public Image postcardWishIcon02;
    public Image postcardWishIcon03;
    public GameObject stampRack;
    public GameObject miniPostcardRack;
    public GameObject currentSelectedHoliday;

    //Marketplace UI
    public GameObject stampMarketCanvas;
    public GameObject rotateMapButton;

    public Text coinCounter;
    public int playerCoins;

    //JSON
    public static List<HolidayWish> wishDatabase;



    void Start () {

        //Setting playercoins - TESTING ONLY - will be managed on start by playerprefs
        playerCoins = 50;

        BuildHolildayDatabase();
        //Debug.Log("The First holiday wish in the database is of type " + wishDatabase[0].stampName + "and has has a fun requirement of " + wishDatabase[0].funRequirement);
        stampManager = GameObject.Find("stampManager");

        stampManager.GetComponent<StampDatabase>().addStamptoShop("romanticDinner", "activity");

        //LOAD POSTCARDS

        // If there's a List to load, load it.
        if (ES2.Exists("myFile.txt?tag=savedHolidayWishes"))
        {
            Debug.Log("LoadFile found!");
            List<string> myLoadedHolidays;
            myLoadedHolidays = ES2.LoadList<string>("myFile.txt?tag=savedHolidayWishes");


            foreach (string wishesString in myLoadedHolidays)
            {
                Debug.Log("Loaded holiday: " + wishesString);

                string[] splitString = wishesString.Split('/');

                Debug.Log("array number 1: " + splitString[0]);
                Debug.Log("array number 2:" + splitString[1]);
                Debug.Log("array number 3:" + splitString[2]);

                updateSpecificHoliday(int.Parse(splitString[0]), (int.Parse(splitString[1])), int.Parse(splitString[2]));
                onHolidayAccept();

                    //Instantiating from scratch
                    /*
                    GameObject loadedPostCard = Instantiate(stampPrefab);
                    loadedPostCard.transform.SetParent(postcardRack.transform, false);

                    loadedPostCard.GetComponent<postcardScript>().locWish = (int)Char.GetNumericValue(wishesString[0]);
                    loadedPostCard.GetComponent<postcardScript>().actWish1 = (int)Char.GetNumericValue(wishesString[1]);
                    loadedPostCard.GetComponent<postcardScript>().actWish2 = (int)Char.GetNumericValue(wishesString[2]);

                    //WHERE IM UP TO: The numbers are loading into the loaded postcard, just need to get them turned into holidayWishes as well!
                    loadedPostCard.GetComponent<postcardScript>().locationWish = testActivity.wishDatabase[wishesString[0]];
                    loadedPostCard.GetComponent<postcardScript>().attributeWish1 = testActivity.wishDatabase[wishesString[1]];
                    loadedPostCard.GetComponent<postcardScript>().attributeWish2 = testActivity.wishDatabase[wishesString[2]];
                    */

                    //loadedPostCard.GetComponent<postcardScript>().locationWish = 

                    //addedHoliday.GetComponent<postcardScript>().locWish = WishInt1;
                    //addedHoliday.GetComponent<postcardScript>().actWish1 = WishInt2;

                    //gameplayObject.GetComponent<testActivity>().updateHoliday();
                    //gameplayObject.GetComponent<testActivity>().updateSpecificHoliday((int)Char.GetNumericValue(wishesString[0]), (int)Char.GetNumericValue(wishesString[1]), (int)Char.GetNumericValue(wishesString[3]));
                    //gameplayObject.GetComponent<testActivity>().onHolidayAccept();


            }


        }
        else if (!ES2.Exists("myFile.txt?tag=savedHolidayData"))
        {
            Debug.Log("No saved holidays found :c");
        }



    }
	
	// Update is called once per frame
	void Update () {

        //Keep the coincount updating
        coinCounter.text = "" + playerCoins;

    }

    public void BuildHolildayDatabase()
    {
        wishDatabase = JsonConvert.DeserializeObject<List<HolidayWish>>(Resources.Load<TextAsset>("JSON/holidayDatabase").ToString());
    }

    public void updateHoliday()
    {

        //implementing JSON - randomise the first wish among the locations, then randomise the other two from holiday attributes

        random1 = Random.Range(0, 6);
        random2 = Random.Range(7, wishDatabase.Count);
        random3 = Random.Range(7, wishDatabase.Count);
        Debug.Log("" + random1);
        Debug.Log("" + random2);
        Debug.Log("" + random3);

        locationWish = wishDatabase[random1];
        attributeWish1 = wishDatabase[random2];
        attributeWish2 = wishDatabase[random3];

        /*
        locationWish = wishDatabase[Random.Range(0, 6)];
        attributeWish1 = wishDatabase[Random.Range(7, wishDatabase.Count)];
        attributeWish2 = wishDatabase[Random.Range(7, wishDatabase.Count)];
        */

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

    public void updateSpecificHoliday(int locwish, int actwish2, int actwish3)
    {

        holidayStat01 = locwish;
        holidayStat02 = actwish2;
        holidayStat03 = actwish3;

        locationWish = wishDatabase[locwish];
        attributeWish1 = wishDatabase[actwish2];
        attributeWish2 = wishDatabase[actwish3];
    }

    public void closeBox()
    {
        dialogueBox.SetActive(false);
    }

    public void onHolidayAccept()
    {
        holidaySetter.GetComponent<setHoliday>().setupHoliday(locationWish, attributeWish1, attributeWish2, random1, random2, random3);
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
        //postcardViewText.text = "Location: " + EventSystem.current.currentSelectedGameObject.GetComponent<postcardScript>().locationWish.stampName + " Wishes: " + EventSystem.current.currentSelectedGameObject.GetComponent<postcardScript>().attributeWish1.stampName + " and " +  EventSystem.current.currentSelectedGameObject.GetComponent<postcardScript>().attributeWish2.stampName;
        currentSelectedHoliday = EventSystem.current.currentSelectedGameObject;
        Debug.Log("current selected holiday is " + currentSelectedHoliday);

        //Fill out each Text View and image with the correct values
        postcardViewText01.text = "In the " + EventSystem.current.currentSelectedGameObject.gameObject.GetComponent<postcardScript>().locationWish.stampName;
        postcardViewText02.text = "" + EventSystem.current.currentSelectedGameObject.gameObject.GetComponent<postcardScript>().attributeWish1.stampName;
        postcardViewText03.text = "" + EventSystem.current.currentSelectedGameObject.gameObject.GetComponent<postcardScript>().attributeWish2.stampName;
        matchWishToIcon(EventSystem.current.currentSelectedGameObject.gameObject.GetComponent<postcardScript>().locationWish, postcardWishIcon01);
        matchWishToIcon(EventSystem.current.currentSelectedGameObject.gameObject.GetComponent<postcardScript>().attributeWish1, postcardWishIcon02);
        matchWishToIcon(EventSystem.current.currentSelectedGameObject.gameObject.GetComponent<postcardScript>().attributeWish2, postcardWishIcon03);
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
        //Deleting all of the stamps that are currently on the postcard. Then, restocking them onto the stamp rack
        List<GameObject> activeStamps = new List<GameObject>();
        activeStamps.AddRange(GameObject.FindGameObjectsWithTag("activeStamp"));

        foreach (GameObject activeStamp in activeStamps)
        {
            Destroy(activeStamp);
        }

        stampManager.GetComponent<StampDatabase>().populateStampRack();


        dialogueBox.SetActive(false);
        miniPostcardRack.SetActive(true);
        stampRack.SetActive(false);
        postcardView.SetActive(false);
    }

    public void onMarketButtonClick()
    {
        stampMarketCanvas.SetActive(true);
        rotateMapButton.SetActive(false);
    }

    public void onMarketCloseButtonClicked()
    {
        stampMarketCanvas.SetActive(false);
        rotateMapButton.SetActive(true);
    }

    public void matchWishToIcon(HolidayWish inputWish, Image iconToChange)
    {
        if (inputWish.beachRequirement > 0)
        {
            iconToChange.GetComponent<Image>().sprite = Resources.Load<Sprite>("wishIconImages/wishMarker_Beach");
        }
        if (inputWish.wildernessRequirement > 0)
        {
            iconToChange.GetComponent<Image>().sprite = Resources.Load<Sprite>("wishIconImages/wishMarker_Wilderness");
        }
        if (inputWish.cityRequirement > 0)
        {
            iconToChange.GetComponent<Image>().sprite = Resources.Load<Sprite>("wishIconImages/wishMarker_City");
        }
        if (inputWish.snowRequirement > 0)
        {
            iconToChange.GetComponent<Image>().sprite = Resources.Load<Sprite>("wishIconImages/wishMarker_Snow");
        }
        if (inputWish.woodlandRequirement > 0)
        {
            iconToChange.GetComponent<Image>().sprite = Resources.Load<Sprite>("wishIconImages/wishMarker_Woodland");
        }
        if (inputWish.cruiseRequirement > 0)
        {
            iconToChange.GetComponent<Image>().sprite = Resources.Load<Sprite>("wishIconImages/wishMarker_Cruise");
        }
        if (inputWish.funRequirement > 0)
        {
            iconToChange.GetComponent<Image>().sprite = Resources.Load<Sprite>("wishIconImages/wishMarker_Fun");
        }
        if (inputWish.excitementRequirement > 0)
        {
            iconToChange.GetComponent<Image>().sprite = Resources.Load<Sprite>("wishIconImages/wishMarker_Exciting");
        }
        if (inputWish.romanceRequirement > 0)
        {
            iconToChange.GetComponent<Image>().sprite = Resources.Load<Sprite>("wishIconImages/wishMarker_Romance");
        }
        if (inputWish.historicalRequirement > 0)
        {
            iconToChange.GetComponent<Image>().sprite = Resources.Load<Sprite>("wishIconImages/wishMarker_Historical");
        }
        if (inputWish.relaxingRequirement > 0)
        {
            iconToChange.GetComponent<Image>().sprite = Resources.Load<Sprite>("wishIconImages/wishMarker_Relaxing");
        }
        if (inputWish.cheapRequirement > 0)
        {
            iconToChange.GetComponent<Image>().sprite = Resources.Load<Sprite>("wishIconImages/wishMarker_Cheap");
        }
        if (inputWish.extravagantRequirement > 0)
        {
            iconToChange.GetComponent<Image>().sprite = Resources.Load<Sprite>("wishIconImages/wishMarker_Extravagent");
        }
        if (inputWish.warmRequirement > 0)
        {
            iconToChange.GetComponent<Image>().sprite = Resources.Load<Sprite>("wishIconImages/wishMarker_Warm");
        }
        if (inputWish.chillyRequirement > 0)
        {
            iconToChange.GetComponent<Image>().sprite = Resources.Load<Sprite>("wishIconImages/wishMarker_Chilly");
        }
    }



}
