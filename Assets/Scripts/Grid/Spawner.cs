using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

    [SerializeField]
    private Transform spawnPointLeft1;

    [SerializeField]
    private Transform spawnPointLeft2;

    [SerializeField]
    private Transform spawnPointRight1;

    [SerializeField]
    private Transform spawnPointRight2;

    [SerializeField]
    private List<GameObject> studentsToSpawn;

    [SerializeField]
    private List<GameObject> teachterToSpawn;

    [SerializeField]
    private float nodeRamdomizerMaxBounds = 0.60f;

    [SerializeField]
    private float nodeRamdomizerMinBounds = 0.10f;

    //spawn the 2 occupiers and give them their target location to the node
    public void Spawn(Node _newNode, float _nodeSize) {

        //spawn occupier 1 on the left
        float yPosLeft = Random.Range(spawnPointLeft1.position.y, spawnPointLeft2.position.y);
        GameObject occupier1 = Instantiate(studentsToSpawn[Random.Range(0, studentsToSpawn.Count)], new Vector2(spawnPointLeft1.position.x, yPosLeft), transform.rotation) as GameObject;

        //choose a random position in the adjusted node size for x & y
        float randomX = Random.Range(nodeRamdomizerMinBounds * _nodeSize, nodeRamdomizerMaxBounds * _nodeSize);
        float randomY = Random.Range(nodeRamdomizerMinBounds * _nodeSize, nodeRamdomizerMaxBounds * _nodeSize);

        if (Random.Range(0, 0.99f) > 0.5f)
            randomX *= -1;
        if (Random.Range(0, 0.99f) > 0.5f)
            randomY *= -1;

        MoveTowards moveTowardsUser1 = occupier1.GetComponent<MoveTowards>();
        moveTowardsUser1.SetTargetToMove(new Vector2(_newNode.X * _nodeSize + randomX, _newNode.Y * _nodeSize + randomY));
        moveTowardsUser1.SetTargetToRotate(new Vector2(_newNode.X * _nodeSize + randomX, _newNode.Y * _nodeSize + randomY));

        //spawn occupier 2 on the right
        float yPosRight = Random.Range(spawnPointRight1.position.y, spawnPointRight2.position.y);
        GameObject occupier2 = Instantiate(teachterToSpawn[Random.Range(0, teachterToSpawn.Count)], new Vector2(spawnPointRight1.position.x, yPosRight), transform.rotation) as GameObject;

        MoveTowards moveTowardsUser2 = occupier2.GetComponent<MoveTowards>();
        moveTowardsUser2.SetTargetToMove(new Vector2(_newNode.X * _nodeSize + (randomX * -1), _newNode.Y * _nodeSize + (randomY * -1)));
        moveTowardsUser2.SetTargetToRotate(new Vector2(_newNode.X * _nodeSize + (randomX * -1), _newNode.Y * _nodeSize + (randomY * -1)));

        //instantiate the the target to rotate to, once the two occupiers get close
        occupier1.GetComponent<ChangeRotatingTarget>().Instantiate(occupier2.transform);
        occupier2.GetComponent<ChangeRotatingTarget>().Instantiate(occupier1.transform);

        //give the node its occupiers, so it can later send them away
        _newNode.AddOccupiers(occupier1, occupier2);
    }
}
