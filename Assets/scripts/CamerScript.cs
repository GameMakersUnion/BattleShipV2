using UnityEngine;
using System.Collections;

public class CamerScript : MonoBehaviour {
	public GameObject shipcamera;
	public GameObject ship;


	// Use this for initialization
	void Start () {
	
		shipcamera = GameObject.Find ("Main Camera");
		ship = GameObject.Find ("Ship");

	}
	
	// Update is called once per frame
	void Update () {
	
		shipcamera.GetComponent<Transform> ().position = ship.GetComponent<Transform> ().position + new Vector3 (0, 0, -10);
	}
}
