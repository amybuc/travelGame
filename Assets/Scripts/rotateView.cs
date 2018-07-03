using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateView : MonoBehaviour {

    public GameObject cameraParent;

    public int rotationSpeed;

	// Use this for initialization
	void Start () {
		
	}


	
	// Update is called once per frame
	void Update () {

        

    }

    public void rotateButton()
    {
        StartCoroutine(RotateView(Vector3.up, 90, 1.0f));
       
    }

    IEnumerator RotateView(Vector3 axis, float angle, float duration = 1.0f)
    {
        Quaternion from = transform.rotation;
        Quaternion to = transform.rotation;
        to *= Quaternion.Euler(axis * angle);
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            transform.rotation = Quaternion.Slerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.rotation = to;
    }
}
