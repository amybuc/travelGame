using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class StampDatabase : MonoBehaviour {


    public static List<Stamp> stampList;

    public GameObject inventoryObject;

    public List<Stamp> inventory = new List<Stamp>();

    //Inventory Script Items
    //public static List<Stamp> inventory;
    public GameObject stampPrefab;
    public GameObject stampRack;
    public GameObject shopStampPrefab;

    public GameObject stampShopActivityScrollView;
    public GameObject stampShopLocationScrollView;


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
            //Debugging Inventory
            /*
            addStamptoPlayerInventory("romanticDinner");
            addStamptoPlayerInventory("carnival");
            addStamptoPlayerInventory("castleTour");
            addStamptoPlayerInventory("puppyMassage");
            addStamptoPlayerInventory("museum");
            addStamptoPlayerInventory("shoppingTrip");
            addStamptoPlayerInventory("sauna");
            addStamptoPlayerInventory("skiing");
            */
            populateStampRack();

            addStamptoShop("romanticDinner", "activity");

            //Debug.Log("The first stamp in the player inventory is " + inventory[0].stampName);
        }

        if (inventory == null)
        {
            Debug.Log("Inventory list does not exist!");
        }

        //Populate Shop stamprack
        //Will also eventually need a countdown for this - to avoid people just restarting to refresh





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

    public void removeStampfromPlayerInventory(string stampSlug)
    {
        foreach (Stamp stamp in stampList)
        {
            if (stamp.stampSlug.Equals(stampSlug))
            {
                inventory.Remove(stamp);
                Debug.Log("The " + stamp.stampName + " has been removed from the inventory");
                populateStampRack();
                return;
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
            stampTemplate.GetComponent<objectStampScript>().price = stamp.price;

            stampTemplate.transform.SetParent(stampRack.transform, false);
        }
    }

    //SHOP

    //A method that, OnStart, will populate the Shop with stamp templates that display a coin price, 
    //and a button setup that adds a stamp to the player inventory, also detracting the coin value, when clicked

    public void populateStampShop()
    {
        //Assigning all the location stamps to their scrollview
        addStamptoShop("snowLocation", "location");
        addStamptoShop("beachLocation", "location");
        //DO THE REST OF THESE

        //Assigning a random mix of activity stamps to their scrollview, based on rarity eventually
        //Add all stamps of type activity to a list of stamps
        //For eight iterations, randomise a number between 0 and the length of the activity list, and add those
        //   stamps to the shop. BUT: if a stamp has a rarity of above common, randomise a number between 0
        //   and 100 - if it's between 75-100, go through with adding the stamp to the shop. If it's between
        //   90 and 100, a stamp of type Rare can be added to the shop :0
        //For later: Make sure the stamp shop only updates once a day - use the dataManager script for this
        //   to check the time and calculate when the next time the shop updates will be.
    }

    public void addStamptoShop(string stampSlug, string scrollView)
    {
        Debug.Log("Method fired");

        foreach (Stamp stamp in stampList)
        {
            if (stamp.stampSlug.Equals(stampSlug))
            {
                Debug.Log("Matching stamp found");

                //Instantiate the Prefab
                GameObject shopStampTemplate = Instantiate(shopStampPrefab);
                Debug.Log("Stamp instantiated!");

                //Filling in the info:
                shopStampTemplate.GetComponent<objectStampScript>().stampSlug = stamp.stampSlug;
                shopStampTemplate.GetComponent<objectStampScript>().name = stamp.stampName;
                shopStampTemplate.GetComponent<objectStampScript>().imagePath = stamp.imagePath;
                shopStampTemplate.GetComponent<objectStampScript>().description = stamp.description;
                shopStampTemplate.GetComponent<objectStampScript>().stampType = stamp.stampType;

                shopStampTemplate.GetComponent<objectStampScript>().beachStat = stamp.beachStat;
                shopStampTemplate.GetComponent<objectStampScript>().wildernessStat = stamp.wildernessStat;
                shopStampTemplate.GetComponent<objectStampScript>().cityStat = stamp.cityStat;
                shopStampTemplate.GetComponent<objectStampScript>().snowStat = stamp.snowStat;
                shopStampTemplate.GetComponent<objectStampScript>().woodlandStat = stamp.woodlandStat;
                shopStampTemplate.GetComponent<objectStampScript>().cruiseStat = stamp.cruiseStat;

                shopStampTemplate.GetComponent<objectStampScript>().funStat = stamp.funStat;
                shopStampTemplate.GetComponent<objectStampScript>().excitementStat = stamp.excitementStat;
                shopStampTemplate.GetComponent<objectStampScript>().romanceStat = stamp.romanceStat;
                shopStampTemplate.GetComponent<objectStampScript>().historicalStat = stamp.historicalStat;
                shopStampTemplate.GetComponent<objectStampScript>().relaxingStat = stamp.relaxingStat;
                shopStampTemplate.GetComponent<objectStampScript>().cheapStat = stamp.cheapStat;
                shopStampTemplate.GetComponent<objectStampScript>().extravagantStat = stamp.extravagantStat;
                shopStampTemplate.GetComponent<objectStampScript>().warmStat = stamp.warmStat;
                shopStampTemplate.GetComponent<objectStampScript>().chillyStat = stamp.chillyStat;

                shopStampTemplate.GetComponent<objectStampScript>().price = stamp.price;

                //set transform
                //shopStampTemplate.transform.SetParent(GameObject.Find(scrollView).transform, false);
                if (scrollView.Equals("activity"))
                {
                    shopStampTemplate.transform.SetParent(stampShopActivityScrollView.transform, false);
                }
                else if (scrollView.Equals("location"))
                {
                    shopStampTemplate.transform.SetParent(stampShopLocationScrollView.transform, false);
                }

            }
        }


    }

    // Update is called once per frame
    void Update () {
		
	}
}
