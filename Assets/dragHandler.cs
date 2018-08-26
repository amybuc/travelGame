using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class dragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public static GameObject itemBeingDragged;
    Vector3 startPosition;
    public Transform startParent;
    public Transform fullScreenCanvas;
    public GameObject minYObject;
    public GameObject maxYObject;

    public bool itemIsOnPostcard;

    public GameObject stampInfoDialogue;
    

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;

        if (startPosition == null)
        {
            startPosition = transform.position;
            startParent = transform.parent;
        }

        //GetComponent<CanvasGroup>().blocksRaycasts = false;
        transform.transform.parent = fullScreenCanvas.transform;

        //throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;

        if (transform.position.y < maxYObject.transform.position.y && transform.position.y > minYObject.transform.position.y)
        {
            itemIsOnPostcard = true;
        }
        else
        {
            itemIsOnPostcard = false;
        }

        stampInfoDialogue.SetActive(true);
        stampInfoDialogue.GetComponentInChildren<Text>().text = itemBeingDragged.GetComponent<objectStampScript>().description;

        //throw new System.NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        Debug.Log(" " + itemIsOnPostcard);

        if (itemIsOnPostcard == true)
        {
            Debug.Log("stamp added to postcard!" + itemIsOnPostcard);
            gameObject.tag = "activeStamp";
        }
        else if (itemIsOnPostcard == false)
        {
            transform.position = startPosition;
            transform.parent = startParent;
            gameObject.tag = "Untagged";
        }

        stampInfoDialogue.SetActive(false);

        /*
        itemBeingDragged = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (transform.parent != startParent)
        {
            
        }
        */

        //throw new System.NotImplementedException();
    }

    // Use this for initialization
    void Start () {

        startParent = GameObject.Find("/ScrollViewCanvas/stampScrollView/Viewport/Content").transform;
        fullScreenCanvas = GameObject.Find("UICanvas").transform;
        minYObject = GameObject.Find("minYObject");
        maxYObject = GameObject.Find("maxYObject");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
