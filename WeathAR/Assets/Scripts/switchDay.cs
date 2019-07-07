﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SwitchDay : MonoBehaviour
{
	public TextMeshPro tag;

    public void SwitchForward()
    {
    	if(tag.text == "Heute"){
    		tag.text = "Morgen";
    		this.transform.Find("switch_button_backward").gameObject.SetActive(true);
    		return;
    	}
    	if(tag.text == "Morgen"){
    		tag.text = "Übermorgen";
    		this.transform.Find("switch_button_forward").gameObject.SetActive(false);
    		return;
    	}
    }

    public void SwitchBackward()
    {
    	if(tag.text == "Übermorgen"){
    		tag.text = "Morgen";
    		this.transform.Find("switch_button_forward").gameObject.SetActive(true);
    		return;
    	}
    	if(tag.text == "Morgen"){
    		tag.text = "Heute";
    		this.transform.Find("switch_button_backward").gameObject.SetActive(false);
    		return;
    	}
    }

    public void Reset(){
    	tag.text = "Heute";
    	this.transform.Find("switch_button_forward").gameObject.SetActive(false);
    	this.transform.Find("switch_button_backward").gameObject.SetActive(false);
    }
}