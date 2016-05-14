using UnityEngine;
using System.Collections.Generic;

public class CheckUniqueConnections : MonoBehaviour {

    //delegate type
    public delegate void AddNodeMethod(int _nodeNumber);

    //delegate instance
    public AddNodeMethod AddNode;

    //delegate type
    public delegate void RemoveNodeMethod(int _nodeNumber);

    //delegate instance
    public RemoveNodeMethod RemoveNode;

    private List<int> activeConnections = new List<int>();

    private bool[] stillExistingConnections;

    private List<int> connectionsToAdd = new List<int>();

    public void UpdateConnections(string _connectionsData) {

        string[] splittedData = _connectionsData.Split('-');

        stillExistingConnections = new bool[activeConnections.Count];

        for (int d = splittedData.Length - 1; d >= 0; d--)
        {
            int activeConnectionsIndex = 0;

            //loop through all already active connections
            for (int c = 0; c < activeConnections.Count; c++)
            {
                //check if there are connections we already know
                if (activeConnections[c] == int.Parse(splittedData[d]))
                {
                    stillExistingConnections[c] = true;
                    activeConnectionsIndex = c;
                    break;
                }
            }

            //this is the connections that exists, but not yet in the list
            if (stillExistingConnections.Length == 0 || !stillExistingConnections[activeConnectionsIndex])
            {
                connectionsToAdd.Add(int.Parse(splittedData[d]));
            } 
        }

        //remove connections that are not marked that they still exist
        for (int a = activeConnections.Count - 1; a >= 0; a--)
        {
            if (!stillExistingConnections[a]) {
                int numberToRemove = activeConnections[a];

                print("node to remove: " + numberToRemove);
                activeConnections.Remove(numberToRemove);

                if(RemoveNode != null)
                    RemoveNode(activeConnections[a]);
            }
        }

        //add the connections we marked to be new
        for (int i = 0; i < connectionsToAdd.Count; i++) {
            activeConnections.Add(connectionsToAdd[i]);
            print("node to add = " + connectionsToAdd[i]);

            if(AddNode != null)
               AddNode(connectionsToAdd[i]);
        }

        //clear the connectionsToAdd list
        connectionsToAdd.Clear();
    }
}