using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class postcardScript : MonoBehaviour {


    public int holidayWish01, holidayWish02, holidayWish03;

    public HolidayWish locationWish;
    public HolidayWish attributeWish1;
    public HolidayWish attributeWish2;

    public int locWish;
    public int actWish1;
    public int actWish2;

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

    //Stamp Manager GameObject to affect Inventory
    GameObject stampManager;

    //Countdown for Holiday
    public float counterTimeLeft;
    public bool counterOn;
    public Text counterText;

    public bool onHoliday = false;


    // Use this for initialization
    void Start () {

        //thisButton.onClick = gameplayObject.GetComponent<testActivity>().onMiniPostcardClick() as UnityEngine.UI.Button.ButtonClickedEvent;

        gameplayObject = GameObject.FindWithTag("gameplayObject");

        if (postCardText != null)
        {
            postCardText.text = (" " + locationWish.stampName + attributeWish1.stampName + attributeWish2.stampName);

        }

        stampManager = GameObject.Find("stampManager");
		
	}
	
	// Update is called once per frame
	void Update () {

        if (counterOn)
        {
            counterTimeLeft -= Time.deltaTime;
            //Debug.Log("Time left is " + Mathf.Round(counterTimeLeft));

            if (counterTimeLeft <= 60)
            {
                counterText.text = "" + Mathf.Round(counterTimeLeft);
            }
            else if (counterTimeLeft > 60)
            {
                counterText.text = "" + Mathf.Round(counterTimeLeft/60) + " minutes";
            }
            else if ((counterTimeLeft/60) <= 60)
            {
                counterText.text = "" + Mathf.Round((counterTimeLeft / 60) / 60) + " hours"; 
            }


            if (counterTimeLeft < 0)
            {
                counterOn = false;
                //SET A COMPLETE HOLIDAY BUTTON TO ACTIVE!!
            }
        }
		
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

            if (activeStamp.GetComponent<objectStampScript>().beachStat > 0)
            {
                finalBeachValue = finalBeachValue + activeStamp.GetComponent<objectStampScript>().beachStat;
            }
            if (activeStamp.GetComponent<objectStampScript>().wildernessStat > 0)
            {
                finalWildernessValue = finalWildernessValue + activeStamp.GetComponent<objectStampScript>().wildernessStat;                
            }
            if (activeStamp.GetComponent<objectStampScript>().cityStat > 0)
            {
                finalCityValue = finalCityValue + activeStamp.GetComponent<objectStampScript>().cityStat;
            }
            if (activeStamp.GetComponent<objectStampScript>().snowStat > 0)
            {
                finalSnowValue = finalSnowValue + activeStamp.GetComponent<objectStampScript>().snowStat;
            }
            if (activeStamp.GetComponent<objectStampScript>().woodlandStat > 0)
            {
                finalWoodlandValue = finalWoodlandValue + activeStamp.GetComponent<objectStampScript>().woodlandStat;
            }
            if (activeStamp.GetComponent<objectStampScript>().cruiseStat > 0)
            {
                finalCruiseValue = finalCruiseValue + activeStamp.GetComponent<objectStampScript>().cruiseStat;
            }


            if (activeStamp.GetComponent<objectStampScript>().funStat > 0)
            {
                finalFunValue = finalFunValue + activeStamp.GetComponent<objectStampScript>().funStat;
            }
            if (activeStamp.GetComponent<objectStampScript>().excitementStat > 0)
            {
                finalExcitementValue = finalExcitementValue + activeStamp.GetComponent<objectStampScript>().excitementStat;
            }
            if (activeStamp.GetComponent<objectStampScript>().romanceStat > 0)
            {
                finalRomanceValue = finalRomanceValue + activeStamp.GetComponent<objectStampScript>().romanceStat;
            }
            if (activeStamp.GetComponent<objectStampScript>().historicalStat > 0)
            {
                finalHistoricalValue = finalHistoricalValue + activeStamp.GetComponent<objectStampScript>().historicalStat;
            }
            if (activeStamp.GetComponent<objectStampScript>().relaxingStat > 0)
            {
                finalRelaxingValue = finalRelaxingValue + activeStamp.GetComponent<objectStampScript>().relaxingStat;
            }
            if (activeStamp.GetComponent<objectStampScript>().cheapStat > 0)
            {
                finalCheapValue = finalCheapValue + activeStamp.GetComponent<objectStampScript>().cheapStat;
            }
            if (activeStamp.GetComponent<objectStampScript>().extravagantStat > 0)
            {
                finalExtravagantValue = finalExtravagantValue + activeStamp.GetComponent<objectStampScript>().extravagantStat;
            }
            if (activeStamp.GetComponent<objectStampScript>().warmStat > 0)
            {
                finalWarmValue = finalWarmValue + activeStamp.GetComponent<objectStampScript>().warmStat;
            }
            if (activeStamp.GetComponent<objectStampScript>().chillyStat > 0)
            {
                finalChillyValue = finalChillyValue + activeStamp.GetComponent<objectStampScript>().chillyStat;
            }

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
            //Check score
            if (finalFunValue >= 0 && finalFunValue <= 20)
            {
                holidayScoreTotal = holidayScoreTotal + 20;
            }
            if (finalFunValue >= 21 && finalFunValue <= 40)
            {
                holidayScoreTotal = holidayScoreTotal + 40;
            }
            if (finalFunValue >= 41 && finalFunValue <= 60)
            {
                holidayScoreTotal = holidayScoreTotal + 60;
            }
            if (finalFunValue >= 61 && finalFunValue <= 80)
            {
                holidayScoreTotal = holidayScoreTotal + 80;
            }
            if (finalFunValue >= 81 && finalFunValue <= 100)
            {
                holidayScoreTotal = holidayScoreTotal + 100;
            }

            //Check no conflicting values
        }

        if (excitementRequired == true)
        {
            //Check score
            if (finalExcitementValue >= 0 && finalExcitementValue <= 20)
            {
                holidayScoreTotal = holidayScoreTotal + 20;
            }
            if (finalExcitementValue >= 21 && finalExcitementValue <= 40)
            {
                holidayScoreTotal = holidayScoreTotal + 40;
            }
            if (finalExcitementValue >= 41 && finalExcitementValue <= 60)
            {
                holidayScoreTotal = holidayScoreTotal + 60;
            }
            if (finalExcitementValue >= 61 && finalExcitementValue <= 80)
            {
                holidayScoreTotal = holidayScoreTotal + 80;
            }
            if (finalExcitementValue >= 81 && finalExcitementValue <= 100)
            {
                holidayScoreTotal = holidayScoreTotal + 100;
            }

            //Check for conflicting values
        }

        if (romanceRequired == true)
        {
            //Check score
            if (finalRomanceValue >= 0 && finalRomanceValue <= 20)
            {
                holidayScoreTotal = holidayScoreTotal + 20;
            }
            if (finalRomanceValue >= 21 && finalRomanceValue <= 40)
            {
                holidayScoreTotal = holidayScoreTotal + 40;
            }
            if (finalRomanceValue >= 41 && finalRomanceValue <= 60)
            {
                holidayScoreTotal = holidayScoreTotal + 60;
            }
            if (finalRomanceValue >= 61 && finalRomanceValue <= 80)
            {
                holidayScoreTotal = holidayScoreTotal + 80;
            }
            if (finalRomanceValue >= 81 && finalRomanceValue <= 100)
            {
                holidayScoreTotal = holidayScoreTotal + 100;
            }

            //Check for conflicting scores
        }

        if (historicalRequired == true)
        {
            //Check score
            if (finalHistoricalValue >= 0 && finalHistoricalValue <= 20)
            {
                holidayScoreTotal = holidayScoreTotal + 20;
            }
            if (finalHistoricalValue >= 21 && finalHistoricalValue <= 40)
            {
                holidayScoreTotal = holidayScoreTotal + 40;
            }
            if (finalHistoricalValue >= 41 && finalHistoricalValue <= 60)
            {
                holidayScoreTotal = holidayScoreTotal + 60;
            }
            if (finalHistoricalValue >= 61 && finalHistoricalValue <= 80)
            {
                holidayScoreTotal = holidayScoreTotal + 80;
            }
            if (finalHistoricalValue >= 81 && finalHistoricalValue <= 100)
            {
                holidayScoreTotal = holidayScoreTotal + 100;
            }

            //check for no conflicting scores
        }

        if (relaxingRequired == true)
        {
            //Check score
            if (finalRelaxingValue >= 0 && finalRelaxingValue <= 20)
            {
                holidayScoreTotal = holidayScoreTotal + 20;
            }
            if (finalRelaxingValue >= 21 && finalRelaxingValue <= 40)
            {
                holidayScoreTotal = holidayScoreTotal + 40;
            }
            if (finalRelaxingValue >= 41 && finalRelaxingValue <= 60)
            {
                holidayScoreTotal = holidayScoreTotal + 60;
            }
            if (finalRelaxingValue >= 61 && finalRelaxingValue <= 80)
            {
                holidayScoreTotal = holidayScoreTotal + 80;
            }
            if (finalRelaxingValue >= 81 && finalRelaxingValue <= 100)
            {
                holidayScoreTotal = holidayScoreTotal + 100;
            }

            //CHECKSCORES
        }

        if (cheapRequired == true)
        {
            //Check score
            if (finalCheapValue >= 0 && finalCheapValue <= 20)
            {
                holidayScoreTotal = holidayScoreTotal + 20;
            }
            if (finalCheapValue >= 21 && finalCheapValue <= 40)
            {
                holidayScoreTotal = holidayScoreTotal + 40;
            }
            if (finalCheapValue >= 41 && finalCheapValue <= 60)
            {
                holidayScoreTotal = holidayScoreTotal + 60;
            }
            if (finalCheapValue >= 61 && finalCheapValue <= 80)
            {
                holidayScoreTotal = holidayScoreTotal + 80;
            }
            if (finalCheapValue >= 81 && finalCheapValue <= 100)
            {
                holidayScoreTotal = holidayScoreTotal + 100;
            }

            //CHECKSCORES
        }

        if (extravagantRequired == true)
        {
            //Check score
            if (finalExtravagantValue >= 0 && finalExtravagantValue <= 20)
            {
                holidayScoreTotal = holidayScoreTotal + 20;
            }
            if (finalExtravagantValue >= 21 && finalExtravagantValue <= 40)
            {
                holidayScoreTotal = holidayScoreTotal + 40;
            }
            if (finalExtravagantValue >= 41 && finalExtravagantValue <= 60)
            {
                holidayScoreTotal = holidayScoreTotal + 60;
            }
            if (finalExtravagantValue >= 61 && finalExtravagantValue <= 80)
            {
                holidayScoreTotal = holidayScoreTotal + 80;
            }
            if (finalExtravagantValue >= 81 && finalExtravagantValue <= 100)
            {
                holidayScoreTotal = holidayScoreTotal + 100;
            }

            //CHECKSCORES
        }

        if (warmRequired == true)
        {
            //Check score
            if (finalWarmValue >= 0 && finalWarmValue <= 20)
            {
                holidayScoreTotal = holidayScoreTotal + 20;
            }
            if (finalWarmValue >= 21 && finalWarmValue <= 40)
            {
                holidayScoreTotal = holidayScoreTotal + 40;
            }
            if (finalWarmValue >= 41 && finalWarmValue <= 60)
            {
                holidayScoreTotal = holidayScoreTotal + 60;
            }
            if (finalWarmValue >= 61 && finalWarmValue <= 80)
            {
                holidayScoreTotal = holidayScoreTotal + 80;
            }
            if (finalWarmValue >= 81 && finalWarmValue <= 100)
            {
                holidayScoreTotal = holidayScoreTotal + 100;
            }

            //CHECKSCORES
        }

        if (chillyRequired == true)
        {
            //Check score
            if (finalChillyValue >= 0 && finalChillyValue <= 20)
            {
                holidayScoreTotal = holidayScoreTotal + 20;
            }
            if (finalChillyValue >= 21 && finalChillyValue <= 40)
            {
                holidayScoreTotal = holidayScoreTotal + 40;
            }
            if (finalChillyValue >= 41 && finalChillyValue <= 60)
            {
                holidayScoreTotal = holidayScoreTotal + 60;
            }
            if (finalChillyValue >= 61 && finalChillyValue <= 80)
            {
                holidayScoreTotal = holidayScoreTotal + 80;
            }
            if (finalChillyValue >= 81 && finalChillyValue <= 100)
            {
                holidayScoreTotal = holidayScoreTotal + 100;
            }

            //CHECKSCORES
        }

        //Derive a score
        Debug.Log("The final total score is " + holidayScoreTotal);

        #endregion




        //Destroy those stamps, REMOVE THEM FROM INVENTORY
        foreach (GameObject activeStamp in activeStamps)
        {
            stampManager.GetComponent<StampDatabase>().removeStampfromPlayerInventory(activeStamp.GetComponent<objectStampScript>().stampSlug);
            Destroy(activeStamp);

        }

        //Add the HolidayInProgress graphic to the card that was clicked.
        sentOnHoliday(200, "hello");

        Debug.Log("sendOnHolidayButton hooked up with holiday!");

    }

    public void sentOnHoliday(int finalScore, string feedbackMessage)
    {

        onHoliday = true;
        onHolidayImage.SetActive(true);
        counterText.gameObject.SetActive(true);
        gameplayObject.GetComponent<testActivity>().onPostcardClose();

        //COUNTER OPERATIONS, TEXT ADJUSTMENT ETC WILL HAPPEN HERE
        // a void will be made like 'make holiday finished dialogue' in testActivity, which will be called here and will input the final score.

        counterOn = true;
        counterTimeLeft = 7800.0f;
    }


   
}

