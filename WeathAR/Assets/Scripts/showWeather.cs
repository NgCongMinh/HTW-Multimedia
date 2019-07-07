using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;


public class showWeather : MonoBehaviour
{
	private GameObject collided;
    private GameObject wetterdaten;
    private GameObject b1;
    private SwitchDay skript;


    void Start()
    {
        collided = null;
        wetterdaten = null;
        b1 = null;
        skript = null;
    }

    void OnTriggerEnter(Collider col){
    	if(col.tag == "Marker"){
                if(wetterdaten != null){
                    skript = (SwitchDay) collided.GetComponent(typeof(SwitchDay));
                    skript.Reset();
                    wetterdaten.SetActive(false);
                }
            collided = col.transform.gameObject;
            wetterdaten = col.transform.Find("Wetterdaten").gameObject;
            b1 = col.transform.Find("switch_button_forward").gameObject;

                wetterdaten.SetActive(true);
                b1.SetActive(true);
                return;
    	}
        return;
    }

    
    void OnTriggerExit(Collider col){
    }
}
