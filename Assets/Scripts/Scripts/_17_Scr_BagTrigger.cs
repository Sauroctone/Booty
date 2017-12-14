using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _17_Scr_BagTrigger : MonoBehaviour {

	_17_Scr_GameManager manager;

	void Start()
	{
		manager = Camera.main.GetComponent<_17_Scr_GameManager> ();
	}

	void OnTriggerEnter (Collider col)
	{
		if (manager.state == GameStates.Ticking) 
		{
			if (col.GetComponent<_17_Tag_Treasure> () != null) 
			{
				manager.booty.Remove (col.transform);
				print (manager.booty.Count);

				if (manager.booty.Count <= 1)
					manager.Win ();
			}

			else 
			{
				manager.Lose ();
			}
		}
	}
}
