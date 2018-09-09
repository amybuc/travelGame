using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class postcardScript : MonoBehaviour {

    public int holidayWish01, holidayWish02, holidayWish03;

    public HolidayWish locationWish;
    public HolidayWish attributeWish1;
    public HolidayWish attributeWish2;

    //Send on Holiday Button Variables
    public Button sendOnHolidayButton;

    #region //HolidayRequirement Bools
    public bool beachRequired;
    public bool wildernessRequired;
    public bool cityRequired;
    public bool snowRequired;
    public bool woodlandRequired;
    public bool cruiseRequired;

    public bool funRequired;
    public bool excitementRequired;
    public bool romanceRequired;
    public bool historicalRequired;
    public bool relaxingRequired;
    public bool cheapRequired;
    public bool extravagantRequired;
    public bool warmRequired;
    public bool chillyRequired;
    #endregion

    #region //Total Holiday Values
    public int finalBeachValue;
    public int finalWildernessValue;
    public int finalCityValue;
    public int finalSnowValue;
    public int finalWoodlandValue;
    public int finalCruiseValue;

    public int finalFunValue;
    public int finalExcitementValue;
    public int finalRomanceValue;
    public int finalHistoricalValue;
    public int finalRelaxingValue;
    public int finalCheapValue;
    public int finalExtravagantValue;
    public int finalWarmValue;
    public int finalChillyValue;
    #endregion

    //a total score out of 300
    public int holidayScoreTotal;
    //Holiday Feedback String
    public string holidayFeedbackPositive;
    public string holidayFeedbackNegative;

    public Text postCardText;

    //public Button thisButton;
    GameObject gameplayObject;

    //Plane image for onHoliday
    public GameObject onHolidayImage;




    // Use this for initialization
    void Start () {

        //thisButton.onClick = gameplayObject.GetComponent<testActivity>().onMiniPostcardClick() as UnityEngine.UI.Button.ButtonClickedEvent;

        gameplayObject = GameObject.FindWithTag("gameplayObject");

        postCardText.text = (" " + locationWish.stampName + attributeWish1.stampName + attributeWish2.stampName);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void miniPostcardOnClick()
    {

        if (onHolidayImage.activeSelf == false)
        {
            gameplayObject.GetComponent<testActivity>().onMiniPostcardClick();
            sendOnHolidayButton = GameObject.Find("sendOnHolidayButton").GetComponent<Button>();
            sendOnHolidayButton.onClick.AddListener(sendOnHoliday);
        }

    }

    public void sendOnHoliday()
    {

        //Check what stamps are actively placed on postcard - add all tagged activeStamp to a list.
        List<GameObject> activeStamps = new List<GameObject>();
        activeStamps.AddRange(GameObject.FindGameObjectsWithTag("activeStamp"));

        #region //adding up all the active stamp's attribute modifiers
        foreach (GameObject activeStamp in activeStamps)
        {

            finalBeachValue = finalBeachValue + activeStamp.GetComponent<objectStampScript>().beachStat;
            finalWildernessValue = finalWildernessValue + activeStamp.GetComponent<objectStampScript>().wildernessStat;
            finalCityValue = finalCityValue + activeStamp.GetComponent<objectStampScript>().cityStat;
            finalSnowValue = finalSnowValue + activeStamp.GetComponent<objectStampScript>().snowStat;
            finalWoodlandValue = finalWoodlandValue + activeStamp.GetComponent<objectStampScript>().woodlandStat;
            finalCruiseValue = finalCruiseValue + activeStamp.GetComponent<objectStampScript>().cruiseStat;

            finalFunValue = finalFunValue + activeStamp.GetComponent<objectStampScript>().funStat;
            finalExcitementValue = finalExcitementValue + activeStamp.GetComponent<objectStampScript>().excitementStat;
            finalRomanceValue = finalRomanceValue + activeStamp.GetComponent<objectStampScript>().romanceStat;
            finalHistoricalValue = finalHistoricalValue + activeStamp.GetComponent<objectStampScript>().historicalStat;
            finalRelaxingValue = finalRelaxingValue + activeStamp.GetComponent<objectStampScript>().relaxingStat;
            finalCheapValue = finalCheapValue + activeStamp.GetComponent<objectStampScript>().cheapStat;
            finalExtravagantValue = finalExtravagantValue + activeStamp.GetComponent<objectStampScript>().extravagantStat;
            finalWarmValue = finalWarmValue + activeStamp.GetComponent<objectStampScript>().warmStat;
            finalChillyValue = finalChillyValue + activeStamp.GetComponent<objectStampScript>().chillyStat;

        }
        #endregion

        //Debug.Log("The first active stamp is " + activeStamps[0].GetComponent<objectStampScript>().stampName);
        //Debug.Log("The second active stamp is " + activeStamps[1].GetComponent<objectStampScript>().stampName);
        Debug.Log("The total snow score of the holiday is" + finalSnowValue);
        Debug.Log("The total Woodland score of the holiday is " + finalWoodlandValue);

        //Check the requirements of the holiday, and grab the attributes needed
        #region //Check LocationWish
        if (locationWish.beachRequirement > 0)
        {
            beachRequired = true;
        }
        else
        {
            beachRequired = false;
        }

        if (locationWish.wildernessRequirement > 0)
        {
            wildernessRequired = true;
        }
        else
        {
            wildernessRequired = false;
        }

        if (locationWish.cityRequirement > 0)
        {
            cityRequired = true;
        }
        else
        {
            cityRequired = false;
        }

        if (locationWish.snowRequirement > 0)
        {
            snowRequired = true;
        }
        else
        {
            snowRequired = false;
        }

        if (locationWish.woodlandRequirement > 0)
        {
            woodlandRequired = true;
        }
        else
        {
            woodlandRequired = false;
        }

        if (locationWish.cruiseRequirement > 0)
        {
            cruiseRequired = true;
        }
        else
        {
            cruiseRequired = false;
        }
        #endregion

        #region //Check AttributeWish1
        if (attributeWish1.funRequirement > 0)
        {
            funRequired = true;
        }
        else
        {
            funRequired = false;
        }

        if (attributeWish1.excitementRequirement > 0)
        {
            excitementRequired = true;
        }
        else
        {
            excitementRequired = false;
        }

        if (attributeWish1.romanceRequirement > 0)
        {
            romanceRequired = true;
        }
        else
        {
            romanceRequired = false;
        }

        if (attributeWish1.historicalRequirement > 0)
        {
            historicalRequired = true;
        }
        else
        {
            historicalRequired = false;
        }

        if (attributeWish1.relaxingRequirement > 0)
        {
            relaxingRequired = true;
        }
        else
        {
            relaxingRequired = false;
        }

        if (attributeWish1.cheapRequirement > 0)
        {
            cheapRequired = true;
        }
        else
        {
            cheapRequired = false;
        }

        if (attributeWish1.extravagantRequirement > 0)
        {
            extravagantRequired = true;
        }
        else
        {
            extravagantRequired = false;
        }

        if (attributeWish1.warmRequirement > 0)
        {
            warmRequired = true;
        }
        else
        {
            warmRequired = false;
        }

        if (attributeWish1.chillyRequirement > 0)
        {
            chillyRequired = true;
        }
        else
        {
            chillyRequired = false;
        }
        #endregion

        #region //Check AttributeWish2
        if (attributeWish2.funRequirement > 0)
        {
            funRequired = true;
        }
        else if (attributeWish2.funRequirement <= 0 && funRequired != true)
        {
            funRequired = false;
        }

        if (attributeWish2.excitementRequirement > 0)
        {
            excitementRequired = true;
        }
        else if (attributeWish2.excitementRequirement <= 0 && excitementRequired != true)
        {
            excitementRequired = false;
        }

        if (attributeWish2.romanceRequirement > 0)
        {
            romanceRequired = true;
        }
        else if (attributeWish2.romanceRequirement <= 0 && romanceRequired != true)
        {
            romanceRequired = false;
        }

        if (attributeWish2.historicalRequirement > 0)
        {
            historicalRequired = true;
        }
        else if (attributeWish2.historicalRequirement <= 0 && historicalRequired != true)
        {
            historicalRequired = false;
        }

        if (attributeWish2.relaxingRequirement > 0)
        {
            relaxingRequired = true;
        }
        else if (attributeWish2.relaxingRequirement <= 0 && relaxingRequired != true)
        {
            relaxingRequired = false;
        }

        if (attributeWish2.cheapRequirement > 0)
        {
            cheapRequired = true;
        }
        else if (attributeWish2.cheapRequirement <= 0 && cheapRequired != true)
        {
            cheapRequired = false;
        }

        if (attributeWish2.extravagantRequirement > 0)
        {
            extravagantRequired = true;
        }
        else if (attributeWish2.extravagantRequirement <= 0 && extravagantRequired != true)
        {
            extravagantRequired = false;
        }

        if (attributeWish2.warmRequirement > 0)
        {
            warmRequired = true;
        }
        else if (attributeWish2.warmRequirement <= 0 && warmRequired != true)
        {
            warmRequired = false;
        }

        if (attributeWish2.chillyRequirement > 0)
        {
            chillyRequired = true;
        }
        else if (attributeWish2.chillyRequirement <= 0 && chillyRequired != true)
        {
            chillyRequired = false;
        }
        #endregion

        #region //Verify which Attributes to check, then check em!

        if (beachRequired == true)
        {
            //
        }

        if (snowRequired == true)
        {
            if (finalSnowValue <= 50)
            {
                Debug.Log("The snow requirement of this stamp has been met!!");
            }
        }

        #endregion

        //Compare them?? Idk
        #region//Checkin all the bools

        if (beachRequired == true)
        {
            Debug.Log("Beach is required");

            //Check score
            if (finalBeachValue >= 0 && finalBeachValue <= 20)
            {
                holidayScoreTotal = holidayScoreTotal + 20;
            }
            if (finalBeachValue >= 21 && finalBeachValue <= 40)
            {
                holidayScoreTotal = holidayScoreTotal + 40;
            }
            if (finalBeachValue >= 41 && finalBeachValue <= 60)
            {
                holidayScoreTotal = holidayScoreTotal + 60;
            }
            if (finalBeachValue >= 61 && finalBeachValue <= 80)
            {
                holidayScoreTotal = holidayScoreTotal + 80;
            }
            if (finalBeachValue >= 81 && finalBeachValue <= 100)
            {
                holidayScoreTotal = holidayScoreTotal + 100;
            }

            //Check that no other locations are active
            if (finalWildernessValue >= 100 || finalCityValue >= 100 || finalSnowValue >= 100 || finalWoodlandValue >= 100 || finalCruiseValue >= 100)
            {
                holidayFeedbackNegative = "I didn't want to holiday here!";
            }

        }

        if (wildernessRequired == true)
        {
            Debug.Log("Wilderness is required");

            //Check score
            if (finalWildernessValue >= 0 && finalWildernessValue <= 20)
            {
                holidayScoreTotal = holidayScoreTotal + 20;
            }
            if (finalWildernessValue >= 21 && finalWildernessValue <= 40)
            {
                holidayScoreTotal = holidayScoreTotal + 40;
            }
            if (finalWildernessValue >= 41 && finalWildernessValue <= 60)
            {
                holidayScoreTotal = holidayScoreTotal + 60;
            }
            if (finalWildernessValue >= 61 && finalWildernessValue <= 80)
            {
                holidayScoreTotal = holidayScoreTotal + 80;
            }
            if (finalWildernessValue >= 81 && finalWildernessValue <= 100)
            {
                holidayScoreTotal = holidayScoreTotal + 100;
            }

            //Check that no other locations are active
            if (finalBeachValue >= 100 || finalCityValue >= 100 || finalSnowValue >= 100 || finalWoodlandValue >= 100 || finalCruiseValue >= 100)
            {
                holidayFeedbackNegative = "I didn't want to holiday here!";
            }
        }

        if (cityRequired == true)
        {
            Debug.Log("City is required");

            //Check score
            if (finalCityValue >= 0 && finalCityValue <= 20)
            {
                holidayScoreTotal = holidayScoreTotal + 20;
            }
            if (finalCityValue >= 21 && finalCityValue <= 40)
            {
                holidayScoreTotal = holidayScoreTotal + 40;
            }
            if (finalCityValue >= 41 && finalCityValue <= 60)
            {
                holidayScoreTotal = holidayScoreTotal + 60;
            }
            if (finalCityValue >= 61 && finalCityValue <= 80)
            {
                holidayScoreTotal = holidayScoreTotal + 80;
            }
            if (finalCityValue >= 81 && finalCityValue <= 100)
            {
                holidayScoreTotal = holidayScoreTotal + 100;
            }

            //Check that no other locations are active
            if (finalBeachValue >= 100 || finalWildernessValue >= 100 || finalSnowValue >= 100 || finalWoodlandValue >= 100 || finalCruiseValue >= 100)
            {
                holidayFeedbackNegative = "I didn't want to holiday here!";
            }
        }

        if (snowRequired == true)
        {
            Debug.Log("Snow is required");

            //Check score
            if (finalSnowValue >= 0 && finalSnowValue <= 20)
            {
                holidayScoreTotal = holidayScoreTotal + 20;
            }
            if (finalSnowValue >= 21 && finalSnowValue <= 40)
            {
                holidayScoreTotal = holidayScoreTotal + 40;
            }
            if (finalSnowValue >= 41 && finalSnowValue <= 60)
            {
                holidayScoreTotal = holidayScoreTotal + 60;
            }
            if (finalSnowValue >= 61 && finalSnowValue <= 80)
            {
                holidayScoreTotal = holidayScoreTotal + 80;
            }
            if (finalSnowValue >= 81 && finalSnowValue <= 100)
            {
                holidayScoreTotal = holidayScoreTotal + 100;
            }

            //Check that no other locations are active
            if (finalBeachValue >= 100 || finalWildernessValue >= 100 || finalCityValue >= 100 || finalWoodlandValue >= 100 || finalCruiseValue >= 100)
            {
                holidayFeedbackNegative = "I didn't want to holiday here!";
            }
        }

        if (woodlandRequired == true)
        {
            Debug.Log("Woodland is required");

            //Check score
            if (finalWoodlandValue >= 0 && finalWoodlandValue <= 20)
            {
                holidayScoreTotal = holidayScoreTotal + 20;
            }
            if (finalWoodlandValue >= 21 && finalWoodlandValue <= 40)
            {
                holidayScoreTotal = holidayScoreTotal + 40;
            }
            if (finalWoodlandValue >= 41 && finalWoodlandValue <= 60)
            {
                holidayScoreTotal = holidayScoreTotal + 60;
            }
            if (finalWoodlandValue >= 61 && finalWoodlandValue <= 80)
            {
                holidayScoreTotal = holidayScoreTotal + 80;
            }
            if (finalWoodlandValue >= 81 && finalWoodlandValue <= 100)
            {
                holidayScoreTotal = holidayScoreTotal + 100;
            }

            //Check that no other locations are active
            if (finalBeachValue >= 100 || finalWildernessValue >= 100 || finalCityValue >= 100 || finalSnowValue >= 100 || finalCruiseValue >= 100)
            {
                holidayFeedbackNegative = "I didn't want to holiday here!";
            }
        }

        if (cruiseRequired == true)
        {
            Debug.Log("Cruise is required");

            //Check score
            if (finalCruiseValue >= 0 && finalCruiseValue <= 20)
            {
                holidayScoreTotal = holidayScoreTotal + 20;
            }
            if (finalCruiseValue >= 21 && finalCruiseValue <= 40)
            {
                holidayScoreTotal = holidayScoreTotal + 40;
            }
            if (finalCruiseValue >= 41 && finalCruiseValue <= 60)
            {
                holidayScoreTotal = holidayScoreTotal + 60;
            }
            if (finalCruiseValue >= 61 && finalCruiseValue <= 80)
            {
                holidayScoreTotal = holidayScoreTotal + 80;
            }
            if (finalCruiseValue >= 81 && finalCruiseValue <= 100)
            {
                holidayScoreTotal = holidayScoreTotal + 100;
            }

            //Check that no other locations are active
            if (finalBeachValue >= 100 || finalWildernessValue >= 100 || finalCityValue >= 100 || finalSnowValue >= 100 || finalCruiseValue >= 100)
            {
                holidayFeedbackNegative = "I didn't want to holiday here!";
            }
        }

        if (funRequired == true)
        {
            //CHECKSCORES
        }

        if (excitementRequired == true)
        {
            //CHECKSCORES
        }

        if (romanceRequired == true)
        {
            //CHECKSCORES
        }

        if (historicalRequired == true)
        {
            //CHECKSCORES
        }

        if (relaxingRequired == true)
        {
            //CHECKSCORES
        }

        if (cheapRequired == true)
        {
            //CHECKSCORES
        }

        if (extravagantRequired == true)
        {
            //CHECKSCORES
        }

        if (warmRequired == true)
        {
            //CHECKSCORES
        }

        if (chillyRequired == true)
        {
            //CHECKSCORES
        }

        //Derive a score
        Debug.Log("The final total score is " + holidayScoreTotal);

        #endregion




        //Destroy those stamps, REMOVE THEM FROM INVENTORY

        //Add the HolidayInProgress graphic to the card that was clicked.
        sentOnHoliday(200, "hello");

        Debug.Log("sendOnHolidayButton hooked up with holiday!");

    }

    public void sentOnHoliday(int finalScore, string feedbackMessage)
    {
        onHolidayImage.SetActive(true);
        gameplayObject.GetComponent<testActivity>().onPostcardClose();

        //COUNTER OPERATIONS, TEXT ADJUSTMENT ETC WILL HAPPEN HERE
        // a void will be made like 'make holiday finished dialogue' in testActivity, which will be called here and will input the final score.
    }
   
}

