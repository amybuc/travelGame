using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using UnityEngine.EventSystems;

public class objectStampScript : MonoBehaviour{

    public string stampSlug;
    public string stampName;
    public string imagePath;
    public string description;
    public string stampType;

    public int beachStat;
    public int wildernessStat;
    public int cityStat;
    public int snowStat;
    public int woodlandStat;
    public int cruiseStat;

    public int funStat;
    public int excitementStat;
    public int romanceStat;
    public int historicalStat;
    public int relaxingStat;
    public int cheapStat;
    public int extravagantStat;
    public int warmStat;
    public int chillyStat;

    //Double Click Variables
    float clicked = 0;
    float clicktime = 0;
    float clickdelay = 0.5f;


    // Use this for initialization
    void Start () {

        gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(imagePath);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onMouseDown()
    {
        clicked++;
        if (clicked == 1) clicktime = Time.time;

        if (clicked > 1 && Time.time - clicktime < clickdelay)
        {
            clicked = 0;
            clicktime = 0;
            Debug.Log("Double CLick: " + this.GetComponent<RectTransform>().name);

        }
        else if (clicked > 2 || Time.time - clicktime > 1) clicked = 0;

    }
}
