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

    void Start() {
        StartCoroutine(RandomIncrementOrDecrement());
        //gridController.FillNode(0);
    }

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

    void ControlGridFunctions(string _unsplitData)
    {
        if (_unsplitData != "")
            checkUniqueConnections.UpdateConnections(_unsplitData);
        else
            gridController.EmptyAllNodes();
    }

    void SpawnOccupiers(Node _node, float _nodeSize) {
        spawner.Spawn(_node, _nodeSize);
    }

    //old functions to test the simulation
    
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
                gridController.EmptyNode(Random.Range(0, gridController.GetOccupiedNodeLength()));
            }
        }
        else if (difference > 0)
        {
            for (int i = 0; i < difference; i++)
            {
                gridController.FillNode(Random.Range(0, gridController.GetOccupiedNodeLength()));
            }
        }

        yield return new WaitForSeconds(2f);

        StartCoroutine(RandomIncrementOrDecrement());
    }
}
