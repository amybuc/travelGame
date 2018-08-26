using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stampInventory : MonoBehaviour {
    /*
    public List<Stamp> inventory;
    public GameObject stampDatabase;
    public GameObject stampPrefab;
    public GameObject stampRack;

    public void populateStampRack()
    {
        foreach (Stamp stamp in inventory)
        {
            GameObject stampTemplate =  Instantiate(stampPrefab);

            stampTemplate.GetComponent<objectStampScript>().stampSlug = stamp.stampSlug;
            stampTemplate.GetComponent<objectStampScript>().stampName = stamp.stampName;
            stampTemplate.GetComponent<objectStampScript>().imagePath = stamp.imagePath;
            stampTemplate.GetComponent<objectStampScript>().description = stamp.description;
            stampTemplate.GetComponent<objectStampScript>().stampType = stamp.stampType;

            stampTemplate.GetComponent<objectStampScript>().beachStat = stamp.beachStat;
            stampTemplate.GetComponent<objectStampScript>().wildernessStat = stamp.wildernessStat;
            stampTemplate.GetComponent<objectStampScript>().cityStat = stamp.cityStat;
            stampTemplate.GetComponent<objectStampScript>().snowStat = stamp.snowStat;
            stampTemplate.GetComponent<objectStampScript>().woodlandStat = stamp.woodlandStat;

            stampTemplate.GetComponent<objectStampScript>().funStat = stamp.funStat;
            stampTemplate.GetComponent<objectStampScript>().excitementStat = stamp.excitementStat;
            stampTemplate.GetComponent<objectStampScript>().romanceStat = stamp.romanceStat;
            stampTemplate.GetComponent<objectStampScript>().historicalStat = stamp.historicalStat;
            stampTemplate.GetComponent<objectStampScript>().relaxingStat = stamp.relaxingStat;

            stampTemplate.transform.SetParent(stampRack.transform, false);
        }
    }
    /*
    public void addStampToInventory(string stampSlug)
    {
        foreach (Stamp selectedStamp in stampDatabase.GetComponent<StampDatabase>().stampList)
        {
            if (stampSlug == selectedStamp.stampSlug)
            {
                inventory.Add(selectedStamp);
                populateStampRack();
                Debug.Log("The " + selectedStamp.stampName + " stamp has been added to the inventory!");
            }
            else
            {
                Debug.Log("No stamp of that name found");
            }
        }
    }
    */
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		
	}
}
