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
                nodes[x, y] = new Node(x, y);
            }
        }
        FillSpot();
    }

    public void FillSpot()
    {
        int xPosToChange = xLength / 2;

        int yPosToChange = yLength / 2;

        int xDirection = 1;

        int yDirection = 1;

        int rowLengthToCheck = 1;

        int index = 0;

        bool xWasPos = false;

        bool yWasPos = true;

        bool increaseRowLength = false;

        while (nodes[xPosToChange, yPosToChange].Occupied) {
            print("check");
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
            print("yooy");
            Instantiate(testObj, new Vector2(nodes[xPosToChange, yPosToChange].X * 10, nodes[xPosToChange, yPosToChange].Y * 10), transform.rotation);
            nodes[xPosToChange, yPosToChange].Occupied = true;

            FillSpot();
        }
    }



    public void EmptySpot()
    {

    }
}
