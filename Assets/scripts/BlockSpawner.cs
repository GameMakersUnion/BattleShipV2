using UnityEngine;
using System.Collections;

public class BlockSpawner : MonoBehaviour {

  public GameObject Selection;
  public GameObject GyroPrefab;
  public GameObject PowerPrefab;
  public GameObject ThrusterPrefab;
  private GameObject spawnPrefab;

  public void Update() {
    if (Input.GetMouseButtonDown(0)) {
      CheckSelector();
      CheckPlacement();
    }
  }

  private void CheckPlacement() {

    var worldClick = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Convert the screen coordinates to World
    var hit = Physics2D.OverlapPoint(worldClick, LayerMask.GetMask("Hull"));
    if (!hit || spawnPrefab == null) return;
    Manager.instance.ship.AddBlock(spawnPrefab, hit.transform.position, hit.transform);

  }

  private void CheckSelector() {
    var worldClick = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Convert the screen coordinates to World
    var hit = Physics2D.OverlapPoint(worldClick, LayerMask.GetMask("Selectors"));
    if (!hit) return;
    Selection.transform.position = hit.transform.position;
    switch (hit.name) {
      case "GyroSelector":
        spawnPrefab = GyroPrefab;
        break;
      case "PowerSourceSelector":
        spawnPrefab = PowerPrefab;
        break;
      case "ThrusterSelector":
        spawnPrefab = ThrusterPrefab;
        break;
    }
  }
}
