using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setHoliday : MonoBehaviour {

    public GameObject postcardTemplate;

    public GameObject content;

    

	// Use this for initialization
	void Start () {
		
	}
	

    public void setupHoliday (int holidayStat01, int holidayStat02, int holidayStat03)
    {
        GameObject addedHoliday = Instantiate(postcardTemplate);
        addedHoliday.GetComponent<postcardScript>().holidayWish01 = holidayStat01;
        addedHoliday.GetComponent<postcardScript>().holidayWish02 = holidayStat02;
        addedHoliday.GetComponent<postcardScript>().holidayWish03 = holidayStat03;
        addedHoliday.transform.SetParent(content.transform.parent, false);
        addedHoliday.transform.position = new Vector3(0, 0, 0);
    }
}
