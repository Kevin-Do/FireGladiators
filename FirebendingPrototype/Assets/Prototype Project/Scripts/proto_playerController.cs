﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class proto_playerController : NetworkBehaviour
{

	public float _playerSpeed;

	public float _playerJumpForce;

	public float _playerRollDistance;
	// Use this for initialization
	public override void OnStartLocalPlayer ()
	{
		GetComponent<Material>().color = Color.cyan;
	}
	
	// Update is called once per frame
	void Update () {

		if (!isLocalPlayer)
		{
			return;
		}
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * _playerSpeed;

		transform.Rotate(0, x, 0);
		transform.Translate(0, 0, z);
	}
}
