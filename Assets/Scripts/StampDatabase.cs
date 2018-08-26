using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class StampDatabase : MonoBehaviour {


    public static List<Stamp> stampList;

    public GameObject inventoryObject;

    List<Stamp> inventory = new List<Stamp>();

    //Inventory Script Items
    //public static List<Stamp> inventory;
    public GameObject stampPrefab;
    public GameObject stampRack;


    private void BuildDatabase()
    {
        stampList = JsonConvert.DeserializeObject<List<Stamp>>(Resources.Load<TextAsset>("JSON/stampDatabase").ToString());
        //Debug.Log(stampList[0].stampName + stampList[0].stampType);
    }

    public Stamp getStamp (string stampSlug)
    {
        foreach (Stamp stamp in stampList)
        {
            if (stamp.stampSlug == stampSlug)
            {
                return stamp;
            }
            else
            {
                Debug.Log("Stamp of name " + stampSlug + " could not be found");
            }

        }
        return null;
    }


	// Use this for initialization
	void Start () {

        BuildDatabase();

        if (stampList == null)
        {
            BuildDatabase();
        }

        if (stampList != null && inventory != null)
        {
            Debug.Log("Stamp " + getStamp("snowLocation").stampName);
            addStamptoPlayerInventory("snowLocation");
            populateStampRack();
            //Debug.Log("The first stamp in the player inventory is " + inventory[0].stampName);
        }

        if (inventory == null)
        {
            Debug.Log("Inventory list does not exist!");
        }
	
	}

    public void addStamptoPlayerInventory(string stampSlug)
    {
       
        foreach (Stamp stamp in stampList)
        {
            if (stamp.stampSlug.Equals(stampSlug))
            {
                inventory.Add(stamp);
                Debug.Log("The " + stamp.stampName + " has been added to the inventory!");
                populateStampRack();
                return;
            }
            else if (stamp.stampSlug != stampSlug)
            {
                Debug.Log("No stamp of that name found");
            }
        }

    }

    public void populateStampRack()
    {

        //Destroys existing stamps in the rack so they don't accumulate each time inventory is refreshed
        foreach (Transform child in stampRack.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        //for every stamp in inventory, instantiate stamp object, filling with correct stats
        foreach (Stamp stamp in inventory)
        {


            GameObject stampTemplate = Instantiate(stampPrefab);

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
            stampTemplate.GetComponent<objectStampScript>().cruiseStat = stamp.cruiseStat;

            stampTemplate.GetComponent<objectStampScript>().funStat = stamp.funStat;
            stampTemplate.GetComponent<objectStampScript>().excitementStat = stamp.excitementStat;
            stampTemplate.GetComponent<objectStampScript>().romanceStat = stamp.romanceStat;
            stampTemplate.GetComponent<objectStampScript>().historicalStat = stamp.historicalStat;
            stampTemplate.GetComponent<objectStampScript>().relaxingStat = stamp.relaxingStat;
            stampTemplate.GetComponent<objectStampScript>().cheapStat = stamp.cheapStat;
            stampTemplate.GetComponent<objectStampScript>().extravagantStat = stamp.extravagantStat;
            stampTemplate.GetComponent<objectStampScript>().warmStat = stamp.warmStat;
            stampTemplate.GetComponent<objectStampScript>().chillyStat = stamp.chillyStat;

            stampTemplate.transform.SetParent(stampRack.transform, false);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
