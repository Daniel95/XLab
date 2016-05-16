using UnityEngine;
using System.Collections;

public class Draggable : MonoBehaviour {

    void OnMouseDown() {
        StartCoroutine(Dragging());
    }

    IEnumerator Dragging() {
        while (Input.GetMouseButton(0)) {
            var worldMousePos = Input.mousePosition;
            worldMousePos.z = 10f;
            transform.position = Camera.main.ScreenToWorldPoint(worldMousePos);
            yield return null;
        }
    }
}
