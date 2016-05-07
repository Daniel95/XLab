﻿using UnityEngine;
using System.Collections;

public class AutoZoomCamera : MonoBehaviour
{
    [SerializeField]
    private GridController gridController;

    [SerializeField]
    private float zoomTime;

    private Vector3 velocity;

    private Camera camera;

    private Vector3 startPos;

    void Start() {
        camera = GetComponent<Camera>();

        //position itself at the middle of the grid
        transform.position = startPos = new Vector3(gridController.MaxXLength / 2 * gridController.NodeSize, gridController.MaxYLength / 2 * gridController.NodeSize, transform.position.z);
    }

    void Update() {
        if (transform.position != new Vector3(startPos.x, startPos.y, startPos.z - gridController.NodeSize * (gridController.OccupatedNodesRowsRadius * 2)))
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(startPos.x, startPos.y, startPos.z - gridController.NodeSize * (gridController.OccupatedNodesRowsRadius * 2)), ref velocity, zoomTime);
    }
}
