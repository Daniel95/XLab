﻿using UnityEngine;
using System.Collections;

public class Node {

    private int x;

    private int y;

    private bool occupied;

    public Node(int _x, int _y)
    {
        x = _x;
        y = _y;
    }

    public int X
    {
        get { return x; }
    }

    public int Y
    {
        get { return y; }
    }

    public bool Occupied
    {
        get { return occupied; }
        set { occupied = value; }
    }
}
