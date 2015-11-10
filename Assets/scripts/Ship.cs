using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ship : MonoBehaviour {

	public Dictionary<Point, Equipment> EquipmentDict = new Dictionary<Point, Equipment> ();
	public Dictionary<Point, Hull> HullDict = new Dictionary<Point, Hull> ();
	//int gyroCount = 0;
	//int thrusterCount = 0;
//	int hullCount = 0;
	public void AddHull (GameObject hullPrefab, Vector2 WorldPos){

		var pt_hull = new Point (WorldPos);
		var newHull = Instantiate(hullPrefab);
		newHull.transform.position = new Vector2(pt_hull.x + .5f, pt_hull.y + .5f);
		newHull.transform.parent = transform.FindChild("HullContainer");
		HullDict [pt_hull] = newHull.GetComponent<Hull> ();
	}

	public void AddBlock (GameObject SpawnPrefab, Vector2 WorldPos, Transform parent)
	{
		var pt = new Point (WorldPos);
		if (pt.x == 0 && pt.y == 0)
			return;
		
		var go = Instantiate (SpawnPrefab);
		go.transform.parent = parent;
		go.transform.position = WorldPos;
		
		if (EquipmentDict.ContainsKey (pt)) {
			Destroy (EquipmentDict [pt].gameObject);
		}
		EquipmentDict [pt] = go.GetComponent<Equipment> ();
		
	}
	public Equipment GetBlock (Vector2 WorldPos)
	{
		var pt = new Point (WorldPos);
		//EquipmentDict [new Point (0,0)].GetComponent;
		if (EquipmentDict.ContainsKey (pt))
			return EquipmentDict [pt];
		return null;
	}

	public void RemoveHull (Vector2 worldPos){
		var pt_hull = new Point (worldPos);
		if (HullDict.ContainsKey (pt_hull)) {
			Destroy (HullDict [pt_hull].gameObject);
		}
		HullDict.Remove (pt_hull);
	}

	public void RemoveBlock (Vector2 worldPos)
	{
		var pt = new Point (worldPos);
		if (pt.x == 0 && pt.y == 0)
			return;
		if (EquipmentDict.ContainsKey (pt)) {
			Destroy (EquipmentDict [pt].gameObject);
			EquipmentDict.Remove (pt);
			
		}
	}
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
