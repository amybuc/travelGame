using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testActivity : MonoBehaviour {

    public Text holidayDescription;

    public GameObject dialogueBox;

    public int holidayStat01;
    public int holidayStat02;
    public int holidayStat03;

    public GameObject resourcesObject;

    public GameObject holidaySetter;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void updateHoliday()
    {
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

        holidayDescription.text = " " + resourcesObject.GetComponent<holidayWishes>().holidayRequestPt1[Random.Range(1, resourcesObject.GetComponent<holidayWishes>().holidayRequestPt1.Length)] + " What I'd like is " + resourcesObject.GetComponent<holidayWishes>().holidayWish[holidayStat01] + ", " + resourcesObject.GetComponent<holidayWishes>().holidayWish[holidayStat02] + ", " + resourcesObject.GetComponent<holidayWishes>().holidayWish[holidayStat03] + "!";
    }

    public void closeBox()
    {
        dialogueBox.SetActive(false);
    }

    public void onHolidayAccept()
    {
        holidaySetter.GetComponent<setHoliday>().setupHoliday(holidayStat01, holidayStat02, holidayStat03);
    }


}
