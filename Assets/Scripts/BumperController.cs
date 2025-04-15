using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
	public int bumperForce = 800;
	private GameObject player;

	void Start() { player = GameObject.FindGameObjectWithTag("Player"); }

	public void OnTriggerEnter(Collider collider) {
		if (collider.gameObject == player) {
			player.GetComponent<Rigidbody>().AddExplosionForce(bumperForce, transform.position, 1);
		}
	}

}