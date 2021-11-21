using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Finale : MonoBehaviour
{
    GameObject[] finaleObjects;
    	string playersName;
	public TextMeshProUGUI finaleTxt;

    void Start()    
    {
        finaleObjects = GameObject.FindGameObjectsWithTag("Finale");
    }
        private void OnTriggerEnter(Collider col)
    {
		finaleTxt.text = "There is nothing left for you to do " + playersName + ".";
		foreach (GameObject g in finaleObjects)
		{
			g.SetActive(true);
		}
    }
}
