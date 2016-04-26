using UnityEngine;
using System.Collections;

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
    private GameObject objectToSpawn;

    [SerializeField]
    private Vector2 targetPosition1;

    [SerializeField]
    private Vector2 targetPosition2;

    // Use this for initialization
    void Start () {
        Spawn();
	}

    void Spawn() {
        float yPosLeft = Random.Range(spawnPointLeft1.position.y, spawnPointLeft2.position.y);
        GameObject user1 = Instantiate(objectToSpawn, new Vector2(spawnPointLeft1.position.x, yPosLeft), transform.rotation) as GameObject;
        user1.GetComponent<MoveTowards>().Target = targetPosition1;

        float yPosRight = Random.Range(spawnPointRight1.position.y, spawnPointRight2.position.y);
        GameObject user2 = Instantiate(objectToSpawn, new Vector2(spawnPointRight1.position.x, yPosRight), transform.rotation) as GameObject;
        user2.GetComponent<MoveTowards>().Target = targetPosition2;
    }
}
