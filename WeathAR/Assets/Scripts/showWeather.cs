using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showWeather : MonoBehaviour
{
    private GameObject andereWetterdaten;     //vorherhige Wetterdaten / von anderem bundesland
	private GameObject wetterdaten;
	//private bool selected = false;
    // Start is called before the first frame update
    void Start()
    {
        andereWetterdaten = null;
        wetterdaten = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(andereWetterdaten != null){
            andereWetterdaten.SetActive(false);
        }
        andereWetterdaten = wetterdaten;
        wetterdaten.SetActive(true);
  
    }

    void OnTriggerEnter(Collider col){
    	if(col.tag == "Marker"){
            wetterdaten = col.transform.Find("Wetterdaten").gameObject;
    		//selected = true;
    	}

    }

    /*
    void OnTriggerExit(Collider col){
    	if(col.tag == "Marker"){
    		selected = false;

    		Debug.Log("y");
    	}

    }
    */
}
