using UnityEngine;

public class ConnectionsController : MonoBehaviour {

    [SerializeField]
    private LoadData loadData;

    [SerializeField]
    private GridController gridController;

    private int oldValue = 0;

    void OnEnable()
    {
        loadData.FinishedLoading += ControlGridFunctions;
    }

    void OnDisable()
    {
        loadData.FinishedLoading -= ControlGridFunctions;
    }
     
    void ControlGridFunctions(int _newValue) {
        //get the difference
        var difference = oldValue - _newValue;

        if (difference < 0)
        {
            for (int i = 0; i < Mathf.Abs(difference); i++) {
                gridController.EmptySpot();
            }
        }
        else if (difference > 0)
        {
            for (int i = 0; i < difference; i++)
            {
                gridController.FillSpot();
            }
        }
    }
}
