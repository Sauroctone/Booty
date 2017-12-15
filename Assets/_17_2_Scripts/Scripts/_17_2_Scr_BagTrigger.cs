using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _17_2_Scr_BagTrigger : MonoBehaviour {

	_17_2_Scr_GameManager manager;
	AudioSource fail;

	void Start()
	{
		manager = Camera.main.GetComponent<_17_2_Scr_GameManager> ();
		fail = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter (Collider col)
	{
		if (manager.state == GameStates.Ticking) 
		{
			if (col.GetComponent<_17_2_Tag_Treasure> () != null) 
			{
				manager.booty.Remove (col.transform.parent);
				//print (manager.booty.Count);
				col.GetComponent<AudioSource>().Play();


				if (manager.booty.Count <= 0)
					manager.Win ();
			}

			else 
			{
				manager.Lose ();
				fail.Play ();
				Camera.main.GetComponent<AudioSource> ().Stop ();
			}
		}
	}
}
