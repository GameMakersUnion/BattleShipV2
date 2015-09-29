using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class HullSpawner : MonoBehaviour {
  public GameObject hullPrefab;
  public GameObject shipHull;
  public GameObject grid;
  private static readonly List<Vector3> Dirs = new List<Vector3>() {
    new Vector3(1, 0),
    new Vector3(0, 1),
    new Vector3(-1, 0),
    new Vector3(0, -1),
  };

  public void Update() {
    if (Input.GetMouseButtonDown(0)) { //When the mouse is clicked
      EditHull();
    }
  }

  private void EditHull() {
    var worldClick = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Convert the screen coordinates to World
    var col = Physics2D.OverlapPoint(worldClick); //Check what is at that coordinate
    if (!col) return;
    if (col.gameObject == grid) { //check if we hit the grid
      if (!HasAdjecent(worldClick)) return;
      var newHull = Instantiate(hullPrefab);
      newHull.transform.position = new Vector2(Mathf.Floor(worldClick.x) + .5f, Mathf.Floor(worldClick.y) + .5f);
      newHull.transform.parent = shipHull.transform;
    }
    else if (col.tag == "hull" && col.gameObject != shipHull) {
      if (!IsEssential(col)) Destroy(col.gameObject);
    }
  }

  private bool HasAdjecent(Vector3 worldPos) {
    return Dirs.Any(d => GetBlock(worldPos + d));
  }

  private bool IsEssential(Collider2D col) {
    var worldpos = col.transform.position;
    if (col.gameObject == shipHull) return true;
    var all = Dirs.All(d => !GetBlock(worldpos + d) || ConnectedToMain(worldpos + d, new HashSet<Collider2D>() { col }) );
    return !all;
  }

  private bool ConnectedToMain(Vector3 worldClick, HashSet<Collider2D> visited) {
    if (visited == null) visited = new HashSet<Collider2D>();
    var hit = Physics2D.OverlapPoint(worldClick, LayerMask.GetMask("Hull"));
    if (!hit || hit.tag != "hull" || visited.Contains(hit)) return false;
    if (hit.gameObject == shipHull) return true;
    visited.Add((hit));
    return Dirs.Any(d => ConnectedToMain(worldClick + d, visited));
  }

  Collider2D GetBlock(Vector3 worldPos) {
    var hit = Physics2D.OverlapPoint(worldPos, LayerMask.GetMask("Hull"));
    return hit && hit.tag == "hull" ? hit : null;
  }
}

