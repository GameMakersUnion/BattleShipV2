using UnityEngine;
using System.Collections;

public class Navigator : MonoBehaviour {
	public GameObject ship;
	public float thrust = 400;
	private Rigidbody2D shiprigidbody;
	//private float acceleratetime = 1;
	//private int gyrocount;
	
	// Use this for initialization
	void Start () {
		ship = GameObject.Find("Ship");
		shiprigidbody = ship.GetComponent<Rigidbody2D> ();

		//gyrocount = ship.GetComponent <Ship> ().gyroCount;
		//Vector3 up = gameObject.transform.up;
	}
	
	
	
	// Update is called once per frame
	void Update () {
		
		float moverotation = Input.GetAxis ("Horizontal");
		float moveforward = Input.GetAxis ("Vertical");
		print (moveforward);

		if (moverotation != 0) {
			ship.transform.localEulerAngles += new Vector3 (0, 0, moverotation * -5f);
		}
		
		if (moveforward != 0) {
			shiprigidbody.AddForce(ship.transform.up * thrust * moveforward);

		}

		
		/*if (Input.GetKeyDown (KeyCode.W)) {
			shiprigidbody.AddForce ( new Vector2 (0 ,thrust*acceleratetime));
			acceleratetime += 1;
		}
		if (Input.GetKeyDown(KeyCode.S)) {
			shiprigidbody.AddForce (new Vector2 (0, -thrust));
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			shiprigidbody.AddForce (new Vector2 (-thrust, 0));
		}
		if (Input.GetKeyDown (KeyCode.D)){
			shiprigidbody.AddForce (new Vector2 (thrust, 0));
		}*/
	}
}
