using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _17_2_Scr_Treasure : MonoBehaviour {

	_17_2_Scr_GameManager manager;

	void Start () 
	{
		manager = Camera.main.GetComponent<_17_2_Scr_GameManager> ();
		manager.booty.Add (transform);
	}
}
