using UnityEngine;
using System.Collections;

public class ConnectionsController : MonoBehaviour {

    [SerializeField]
    private LoadData loadData;

    [SerializeField]
    private GridController gridController;

    [SerializeField]
    private Spawner spawner;

    [SerializeField]
    private CheckUniqueConnections checkUniqueConnections;

    private int oldValue = 0;

    void OnEnable()
    {
        loadData.FinishedLoadingConnections += ControlGridFunctions;
        checkUniqueConnections.AddNode += gridController.FillNode;
        checkUniqueConnections.RemoveNode += gridController.EmptyNode;
        gridController.ChosenNode += SpawnOccupiers;
    }

    void OnDisable()
    {
        loadData.FinishedLoadingConnections -= ControlGridFunctions;
        checkUniqueConnections.AddNode -= gridController.FillNode;
        checkUniqueConnections.RemoveNode -= gridController.EmptyNode;
        gridController.ChosenNode -= SpawnOccupiers;
    }

    void ControlGridFunctions(string _unsplitData, bool _isBlindDate)
    {
        checkUniqueConnections.UpdateConnections(_unsplitData);
    }

    void SpawnOccupiers(Node _node, float _nodeSize) {
        spawner.Spawn(_node, _nodeSize);
    }

    //old functions to test the simulation
    /*
    IEnumerator RandomIncrementOrDecrement()
    {
        int difference = Random.Range(-1, 2);
        if (difference < 1) {
            difference = Random.Range(-1, 2);
            if(difference < 1)
                difference = Random.Range(-1, 2);
        }

        if (difference < 0)
        {
            for (int i = 0; i < Mathf.Abs(difference); i++)
            {
                gridController.EmptyNode(0);
            }
        }
        else if (difference > 0)
        {
            for (int i = 0; i < difference; i++)
            {
                gridController.FillNode();
            }
        }

        yield return new WaitForSeconds(1.5f);

        StartCoroutine(RandomIncrementOrDecrement());
    }*/

    /*
    void ControlGridFunctions(int _newValue) {
        //get the difference
        var difference = oldValue - _newValue;

        if (difference < 0)
        {
            for (int i = 0; i < Mathf.Abs(difference); i++) {
                gridController.EmptyNode(0);
            }
        }
        else if (difference > 0)
        {
            for (int i = 0; i < difference; i++)
            {
                gridController.FillNode();
            }
        }
    }*/
}
