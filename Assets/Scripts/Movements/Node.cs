﻿using UnityEngine;
using System.Collections;

public class Node {

    private float x;

    private float y;

    private int nodeNumber;

    private bool occupied;

    private GameObject occupier1;
    private GameObject occupier2;

    public Node(float _x, float _y)
    {
        x = _x;
        y = _y;
    }

    public float X
    {
        get { return x; }
    }

    public float Y
    {
        get { return y; }
    }

    public bool Occupied
    {
        get { return occupied; }
        set { occupied = value; }
    }

    public int NodeNumber {
        set { nodeNumber = value; }
        get { return nodeNumber; }
    }

    public void AddOccupiers(GameObject _occupier1, GameObject _occupier2) {
        occupier1 = _occupier1;
        occupier2 = _occupier2;
    }

    public void RemoveOccupiers()
    {
        occupier1.GetComponent<MoveTowards>().StartPreparingMoveAway();
        occupier2.GetComponent<MoveTowards>().StartPreparingMoveAway();
    }
}
