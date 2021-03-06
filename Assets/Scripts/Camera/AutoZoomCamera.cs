﻿using UnityEngine;
using System.Collections;

public class AutoZoomCamera : MonoBehaviour
{
    [SerializeField]
    private GridController gridController;

    [SerializeField]
    private float zoomTime;

    [SerializeField]
    private float xOffset = 0.3f;

    private Vector3 velocity;

    private Vector3 startPos;

    void Start() {
        //position itself at the middle of the grid
        transform.position = startPos = new Vector3(gridController.MaxXLength / 2 * gridController.NodeSize, gridController.MaxYLength / 2 * gridController.NodeSize, transform.position.z);
    }

    void Update() {
        if (transform.position != new Vector3(startPos.x, startPos.y, startPos.z - gridController.OccupatedNodesRowsRadius))
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(startPos.x + gridController.OccupatedNodesRowsRadius * xOffset, startPos.y, startPos.z - gridController.OccupatedNodesRowsRadius * 1.1f), ref velocity, zoomTime);
        }
    }
}
