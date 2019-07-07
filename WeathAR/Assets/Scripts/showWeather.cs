using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;


public class showWeather : MonoBehaviour
{
    private GameObject andereWetterdaten;     //vorherhige Wetterdaten / von anderem bundesland
	private GameObject wetterdaten;
    private GameObject b1;

    private string name;
    private string name2;
	//private bool selected = false;
    // Start is called before the first frame update
    void Start()
    {
        andereWetterdaten = null;
        wetterdaten = null;
        b1 = null;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(andereWetterdaten == null);
        if(andereWetterdaten != null && andereWetterdaten != wetterdaten){
            andereWetterdaten.GetComponent<switchDay>().Reset();
            andereWetterdaten.SetActive(false);
        }
            andereWetterdaten = wetterdaten;
            wetterdaten.SetActive(true);
            b1.SetActive(true);
    }

    void OnTriggerEnter(Collider col){
        //Debug.Log(andereWetterdaten == null);
    	if(col.tag == "Marker"){
            wetterdaten = col.transform.Find("Wetterdaten").gameObject;
            b1 = col.transform.Find("switch_button_forward").gameObject;
    		//selected = true;
    	}
    }

    
    void OnTriggerExit(Collider col){

    }
}
