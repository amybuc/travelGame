using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogClickHandler : MonoBehaviour {

    bool dogClicked;
    public GameObject gameplayObject;
    public GameObject newHolidayUI;
    public GameObject barkUI;
    public AudioClip barkClip;
    public AudioSource barkSource;

	// Use this for initialization
	void Start () {

        gameplayObject = GameObject.Find("gameplayObject");

        //setting dogclicked to false - will need to access systemprefs later i guess
        dogClicked = false;

        if (dogClicked == false)
        {
            newHolidayUI.SetActive(true);
        }
		
	}
	
	// Update is called once per frame
	void Update () {

        
		
	}

    public void OnMouseDown()
    {
        //Debug.Log("clicking works");

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "dog")
            {
                if (dogClicked == false)
                {
                    //Debug.Log("Pupparoo clickaroo");
                    gameplayObject.GetComponent<testActivity>().updateHoliday();
                    dogClicked = true;
                    newHolidayUI.SetActive(false);
                }
                else if (dogClicked == true)
                {
                    barkSource = gameObject.GetComponent<AudioSource>();
                    barkSource.PlayOneShot(barkClip);
                    StartCoroutine(showBarkUI());
                    //PLAY BARK
                }
                
               
            }
        }
    }

    IEnumerator showBarkUI()
    {
        barkUI.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        barkUI.SetActive(false);
    }
}
