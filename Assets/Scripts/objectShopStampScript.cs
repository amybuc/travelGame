using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectShopStampScript : MonoBehaviour {

    string slug;
    int price;
    GameObject stampManager;
    GameObject gameManager;

    public Text priceText;

	// Use this for initialization
	void Start () {

        stampManager = GameObject.Find("stampManager");
        gameManager = GameObject.Find("gameplayObject");
        slug = gameObject.GetComponent<objectStampScript>().stampSlug;
        price = gameObject.GetComponent<objectStampScript>().price;

        priceText.text = "" + price;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onPurchase()
    {

        if (gameManager.GetComponent<testActivity>().playerCoins >= price)
        {
            stampManager.GetComponent<StampDatabase>().addStamptoPlayerInventory(slug);
            gameManager.GetComponent<testActivity>().playerCoins = gameManager.GetComponent<testActivity>().playerCoins - price;

        }
        //charge coins
        //If coins not sufficient, throw error (sound?)
    }
}
