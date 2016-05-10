using UnityEngine;
using System.Collections;

public class ConnectionsController : MonoBehaviour {

    [SerializeField]
    private LoadData loadData;

    [SerializeField]
    private GridController gridController;

    [SerializeField]
    private Spawner spawner;

    private int oldValue = 0;

    void Start() {
        //StartCoroutine(RandomIncrementOrDecrement());
        gridController.FillNode();
    }

    void OnEnable()
    {
        loadData.FinishedLoading += ControlGridFunctions;
        gridController.ChosenNode += SpawnOccupiers;
    }

    void OnDisable()
    {
        loadData.FinishedLoading -= ControlGridFunctions;
        gridController.ChosenNode -= SpawnOccupiers;
    }
     
    void ControlGridFunctions(int _newValue) {
        //get the difference
        var difference = oldValue - _newValue;

        if (difference < 0)
        {
            for (int i = 0; i < Mathf.Abs(difference); i++) {
                gridController.EmptyNode();
            }
        }
        else if (difference > 0)
        {
            for (int i = 0; i < difference; i++)
            {
                gridController.FillNode();
            }
        }
    }
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
                gridController.EmptyNode();
            }
        }
        else if (difference > 0)
        {
            for (int i = 0; i < difference; i++)
            {
                gridController.FillNode();
            }
        }

        yield return new WaitForSeconds(1f);

        StartCoroutine(RandomIncrementOrDecrement());
    }*/

    void SpawnOccupiers(Node _node, float _nodeSize) {
        spawner.Spawn(_node, _nodeSize);
    }
}
