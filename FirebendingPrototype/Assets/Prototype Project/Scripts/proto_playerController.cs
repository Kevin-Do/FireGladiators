using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Effects;

public class proto_playerController : NetworkBehaviour
{

	public float _playerSpeed;

	public float _playerJumpForce;

	public float _playerRollDistance;

	public GameObject bulletprefab;

	public Transform bulletSpawn;

	public float bulletSpeed;
	
	public override void OnStartLocalPlayer ()
	{
		GetComponent<Renderer>().material.color = Color.cyan;
	}
	
	// Update is called once per frame
	void Update () {

		if (!isLocalPlayer)
		{
			return;
		}
		
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * _playerSpeed;

		if (Input.GetKeyDown("space"))
		{
			CmdFire();
		}
		
		transform.Rotate(0, x, 0);
		transform.Translate(0, 0, z);
	}

	[Command]
	void CmdFire()
	{
		var bullet = (GameObject) Instantiate(
			bulletprefab,
			bulletSpawn.position,
			bulletSpawn.rotation);
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

		//Spawn on clients
		NetworkServer.Spawn(bullet);
		Destroy(bullet, 2.0f);
	}
}
