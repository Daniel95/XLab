using UnityEngine;
using System.Collections.Generic;

public class GridController : MonoBehaviour {

    [SerializeField]
    private GameObject testObj;

    [SerializeField]
    private int xLength = 10;

    [SerializeField]
    private int yLength = 10;

    private Node[,] nodes;

    void Awake()
    {
        nodes = new Node[xLength, yLength];
        for (int x = 0; x < xLength; x++) {
            for (int y = 0; y < yLength; y++) {
                GameObject obj = Instantiate(testObj, new Vector3(0,0), transform.rotation) as GameObject;
                nodes[x, y] = new Node(x, y, obj);
                nodes[x, y].TestObj.transform.position = new Vector2(nodes[x, y].X, nodes[x, y].Y);
                nodes[x, y].TestObj.SetActive(false);
            }
        }
    }

    public void FillSpot()
    {
        int xPosToChange = xLength / 2;

        int yPosToChange = yLength / 2;

        int xDirection = 1;

        int yDirection = 0;

        int rowLengthToCheck = 1;

        int index = 0;

        bool xWasPos = false;

        bool yWasPos = true;

        bool increaseRowLength = false;

        while (nodes[xPosToChange, yPosToChange].Occupied) {
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

                //let the x direction go back and forth between 1- , 0 and 1
                if (xDirection == 0)
                {
                    if (xWasPos)
                        xDirection = -1;
                    else
                        xDirection = 1;
                }
                else
                {
                    if (xDirection > 0)
                        xWasPos = true;
                    else
                        xWasPos = false;
                    xDirection = 0;
                }

                //let the y direction go back and forth between 1- , 0 and 1
                if (yDirection == 0)
                {
                    if (yWasPos)
                        yDirection = -1;
                    else
                        yDirection = 1;
                }
                else
                {
                    if (yDirection > 0)
                        yWasPos = true;
                    else
                        yWasPos = false;
                    yDirection = 0;
                }

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

        nodes[xPosToChange, yPosToChange].TestObj.SetActive(true);
        nodes[xPosToChange, yPosToChange].Occupied = true;
    }

    public void EmptySpot()
    {
        List<Node> occupiedNodes = new List<Node>();

        foreach (Node node in nodes) {
            if (node.Occupied) {
                occupiedNodes.Add(node);
            }
        }

        if (occupiedNodes != null)
        {
            Node nodeToDestroy = occupiedNodes[Random.Range(0, occupiedNodes.Count)];
            nodeToDestroy.Occupied = false;
            nodeToDestroy.TestObj.SetActive(false);
        }
    }
}
