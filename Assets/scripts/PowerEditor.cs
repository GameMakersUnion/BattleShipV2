using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerEditor : MonoBehaviour {

  public PowerSource start;
  public HashSet<PowerSource> sources;
  public Material lineMaterial;
	// Use this for initialization
	void Start () {
	
	}

  void OnEnable() {
    sources = new HashSet<PowerSource>();
    foreach (var Eq in Manager.instance.ship.Values) {
      var p = Eq.GetComponent<PowerSource>();
      if (p != null) {
        sources.Add(p);
      }
    }

    foreach (PowerSource powerSource in sources) {
      foreach (var connectedEquipment in powerSource.ConnectedEquipments) {
        MakeLineRenderer(powerSource, connectedEquipment);
      }
    }
  }
  

  private void MakeLineRenderer(PowerSource powerSource, Equipment connectedEquipment) {
    GameObject g = new GameObject("PowerLine");
    g.transform.parent = this.transform;
    LineRenderer r = g.AddComponent<LineRenderer>();
    r.useWorldSpace = false;
    r.SetVertexCount(2);
    r.SetPosition(0, powerSource.transform.position);
    r.SetPosition(1, connectedEquipment.transform.position);
    r.material = lineMaterial;
    r.sortingLayerName = "Above";
    r.SetColors(powerSource.wireColor, powerSource.wireColor);
    r.SetWidth(0.2f, 0.2f);
  }

  // Update is called once per frame
	void Update () {

      if (Input.GetMouseButtonDown(0))
      {
        var worldClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Equipment q = Manager.instance.GetBlock(worldClick);
        if (q is PowerSource) {
          start = (PowerSource)q;
        }
      }
    if (start !=  null && Input.GetMouseButtonUp(0))
    {
      var worldClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      Equipment q = Manager.instance.GetBlock(worldClick);
      if (!(q is PowerSource)) {
        start.ConnectedEquipments.Add(q);
        MakeLineRenderer(start, q);
      }
      start = null;
    }
  }

}
