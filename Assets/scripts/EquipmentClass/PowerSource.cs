using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerSource : Equipment {

  public static HashSet<Color> usedColors = new HashSet<Color>();

  public Color wireColor;
  // Use this for initialization
  public HashSet<Equipment> ConnectedEquipments;

  void Start () {
    Color x = Color.red;
    while (usedColors.Contains(x)) {
      Vector3 r = Random.insideUnitSphere;
      x = new Color(r.x, r.y, r.z);
    }
    usedColors.Add(x);
    wireColor = x;
    ConnectedEquipments = new HashSet<Equipment>();;
    }
	
	// Update is called once per frame
	void Update () {
	  
	}
}
