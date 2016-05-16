using UnityEngine;
using System.Collections;

public class MoveReletativeToCamera : MonoBehaviour {

    [SerializeField]
    private GridController gridController;

    [SerializeField]
    private float amountToMove = 0.4f;

    [SerializeField]
    private bool movePositive;

    private Vector2 startPos;

    void Start() {
        startPos = transform.localPosition;

        if (!movePositive)
            amountToMove *= -1;
    }

	// Update is called once per frame
	void Update () {
        transform.localPosition = new Vector2(startPos.x + gridController.OccupatedNodesRowsRadius * amountToMove, startPos.y);
	}
}
