using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _17_Scr_MouseController : MonoBehaviour {

	RaycastHit hit;
	Ray ray;
//	Transform target;
	Rigidbody rbTarget;
	Vector3 mousePos;
	Vector3 prevMousePos;
	Vector3 mouseDelta;
	Vector3 force;
	public float forceStrength;
	_17_Scr_GameManager manager;

	void Start()
	{
		manager = Camera.main.GetComponent<_17_Scr_GameManager> ();
	}

	void Update() 
	{
		if (manager.state == GameStates.Ticking) 
		{
			MouseDown ();
			MouseUp ();
		}
	}

	void FixedUpdate()
	{
		if (manager.state == GameStates.Ticking) 
		{
			MouseMove ();
		}
	}

	void MouseDown()
	{
		if (Input.GetMouseButtonDown(0))
		{
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit, 100f)) 
			{
				rbTarget = hit.rigidbody;

				if (rbTarget != null) 
				{
				//	target = hit.transform;
					Vector3 v3 = Input.mousePosition;
					v3.z = 10;
					mousePos = Camera.main.ScreenToWorldPoint (v3);
					prevMousePos = mousePos;
				}
			}
		}
	}

	void MouseMove()
	{
		if (Input.GetMouseButton (0) && rbTarget != null) 
		{
			Vector3 v3 = Input.mousePosition;
			v3.z = 10;
			mousePos = Camera.main.ScreenToWorldPoint (v3);
			mouseDelta = mousePos - prevMousePos;
			prevMousePos = mousePos;

			force = new Vector3 (mouseDelta.x, 0f, mouseDelta.y) * forceStrength;
			//force = new Vector3 (mousePos.x - target.position.x, 0f, mousePos.y - target.position.z) * forceStrength;

			rbTarget.AddForce (force);
		}
	}

	void MouseUp()
	{
		if (Input.GetMouseButtonUp (0) && rbTarget != null) 
		{
			rbTarget = null;
			//target = null;
		}
	}
}
