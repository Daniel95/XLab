using UnityEngine;
using System.Collections.Generic;

public class GridController : MonoBehaviour {

    //delegate type
    public delegate void GridControllerMethods(Node _node, float nodeSize);

    //delegate instance
    public GridControllerMethods ChosenNode;

    [SerializeField]
    private GameObject testObj;

    [SerializeField]
    private int maxXLength = 10;

    [SerializeField]
    private int maxYLength = 10;

    private int occupatedNodesRowsRadius;

    [SerializeField]
    private float nodeSize = 1;

    private Node[,] nodes;

    void Awake()
    {
        //make the nodes
        nodes = new Node[maxXLength, maxYLength];
        for (int x = 0; x < maxXLength; x++) {
            for (int y = 0; y < maxYLength; y++) {
                GameObject obj = Instantiate(testObj, new Vector3(0,0), transform.rotation) as GameObject;
                nodes[x, y] = new Node(x, y, obj);
                nodes[x, y].TestObj.transform.position = new Vector2(nodes[x, y].X * nodeSize, nodes[x, y].Y * nodeSize);
                nodes[x, y].TestObj.SetActive(false);
            }
        }
    }

    public void FillNode()
    {
        //our starting position
        int xPosToChange = maxXLength / 2;

        int yPosToChange = maxYLength / 2;
        
        //our current, 2d direction
        int xDirection = 1;

        int yDirection = 0;

        int rowLengthToCheck = 1;

        //index that we use to count
        int index = 0;

        //so we can check what the direction was when we last changed it
        bool xWasPos = false;

        bool yWasPos = true;

        bool increaseRowLength = false;

        while (CheckNodeOccupied(xPosToChange, yPosToChange)) {
            //go to the next node in the row
            if (index < rowLengthToCheck)
            {
                xPosToChange += xDirection;
                yPosToChange += yDirection;

                index++;
            }
            else
            {
                //reset the index
                index = 0;

                //go to the next direction for x and y
                BackAndForth(ref xDirection, ref xWasPos);
                BackAndForth(ref yDirection, ref yWasPos);

                //increase row length alternately
                if (increaseRowLength)
                {
                    rowLengthToCheck++;
                    increaseRowLength = false;
                }
                else
                    increaseRowLength = true;
            }
        }


        //check how many nodes are occupied
        int occupiedNodeIndex = 0;

        foreach (Node node in nodes)
        {
            if (node.Occupied)
            {
                occupiedNodeIndex++;
            }
        }

        //calc the new node radius, so the camera can use that number to zoom in or out
        occupatedNodesRowsRadius = OccupiedNodesRadius(occupiedNodeIndex);

        if (xPosToChange < maxXLength && yPosToChange < maxYLength)
        {
            nodes[xPosToChange, yPosToChange].TestObj.SetActive(true);
            nodes[xPosToChange, yPosToChange].Occupied = true;

            if (ChosenNode != null)
                ChosenNode(nodes[xPosToChange, yPosToChange], nodeSize);
        }
    }

    bool CheckNodeOccupied(int _x, int _y) {
        //check if the node is occupied, and check if the node we are checking exists
        if (_x < maxXLength && _y < maxYLength)
            return nodes[_x, _y].Occupied;
        else
            return false;
    }
    
    //goes back and forth between -1 and 1
    private void BackAndForth(ref int _dir, ref bool _wasPos) {
        //if it is zero, what the direction was when we last changed it
        if (_dir == 0)
        {
            if (_wasPos)
                _dir = -1;
            else
                _dir = 1;
        }
        else //if it is positive or negative, set the bool positive or negative, and set the dir to zero
        {
            if (_dir > 0)
                _wasPos = true;
            else
                _wasPos = false;
            _dir = 0;
        }
    }

    private int OccupiedNodesRadius(int _occupiedNodesAmount) {
        return Mathf.FloorToInt(Mathf.FloorToInt(Mathf.Sqrt(_occupiedNodesAmount)) / 2);
    }

    public void EmptyNode()
    {
        List<Node> occupiedNodes = new List<Node>();

        //add all occupied nodes to a list
        foreach (Node node in nodes) {
            if (node.Occupied) {
                occupiedNodes.Add(node);
            }
        }

        //calc the new node radius, so the camera can use that number to zoom in or out
        occupatedNodesRowsRadius = OccupiedNodesRadius(occupiedNodes.Count);

        //empty a random node of occupiednodes
        if (occupiedNodes.Count != 0)
        {
            Node nodeToEmpty = occupiedNodes[Random.Range(0, occupiedNodes.Count)];
            nodeToEmpty.Occupied = false;
            nodeToEmpty.TestObj.SetActive(false);
            nodeToEmpty.RemoveOccupiers();
        }
    }

    public float NodeSize
    {
        get { return nodeSize; }
    }

    public float MaxXLength
    {
        get { return maxXLength; }
    }

    public float MaxYLength
    {
        get { return maxYLength; }
    }

    public int OccupatedNodesRowsRadius
    {
        get { return occupatedNodesRowsRadius; }
    }
}
