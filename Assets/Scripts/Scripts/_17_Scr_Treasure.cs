using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _17_Scr_Treasure : MonoBehaviour {

	_17_Scr_GameManager manager;

	void Start () 
	{
		manager = Camera.main.GetComponent<_17_Scr_GameManager> ();
		manager.booty.Add (transform);
		print (gameObject.name);
	}
}
