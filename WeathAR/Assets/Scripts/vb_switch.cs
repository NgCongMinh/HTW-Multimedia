using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;


public class vb_switch : MonoBehaviour, IVirtualButtonEventHandler
{
	VirtualButtonBehaviour[] virtualButtonBehaviours;
	string vbName;
    // Start is called before the first frame update

	//public GameObject firstPanel, secondPanel;

    void Start()
    {
        virtualButtonBehaviours = GetComponentsInParent<VirtualButtonBehaviour>();

        for(int i = 0; i < virtualButtonBehaviours.Length; i++){
        	virtualButtonBehaviours[i].RegisterEventHandler(this);
        }
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
    	vbName = vb.VirtualButtonName;

    	if(vbName == "switch_button"){
    		Debug.Log("switch_button");
    	}
        if(vbName == "switch_button_zurueck"){
            Debug.Log("switch_button_zurueck");
        }
    }


    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {

    }

}
