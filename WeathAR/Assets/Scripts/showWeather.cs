using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showWeather : MonoBehaviour
{
    private GameObject andereWetterdaten;     //vorherhige Wetterdaten / von anderem bundesland
	private GameObject wetterdaten;
    private GameObject andereVb1;
    private GameObject andereVb2;
    private GameObject vb1;                 //switch buttons
    private GameObject vb2;
	//private bool selected = false;
    // Start is called before the first frame update
    void Start()
    {
        andereWetterdaten = null;
        wetterdaten = null;
        andereVb1 = null;
        andereVb2 = null;
        vb1 = null;
        vb2 = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(andereWetterdaten != null){
            andereWetterdaten.SetActive(false);
            andereVb1.SetActive(false);
            andereVb2.SetActive(false);
        }
        andereWetterdaten = wetterdaten;
        andereVb1 = vb1;
        andereVb2 = vb2;
        wetterdaten.SetActive(true);
        vb1.SetActive(true);
        vb2.SetActive(true);
  
    }

    void OnTriggerEnter(Collider col){
    	if(col.tag == "Marker"){
            wetterdaten = col.transform.Find("Wetterdaten").gameObject;
            vb1 = col.transform.Find("switch_button_zurueck").gameObject;
            vb2 = col.transform.Find("switch_button").gameObject;
            Debug.Log(vb1);
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
