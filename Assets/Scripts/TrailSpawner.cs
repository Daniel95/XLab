using UnityEngine;
using System.Collections;

public class TrailSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject objectToSpawn;

    [SerializeField]
    private float cooldown = 40;

    private float startCooldown;

    [SerializeField]
    private float randomCooldown = 0.3f;

    [SerializeField]
    private float randomPosition = 1;

    void Start() {
        startCooldown = cooldown;
        randomCooldown = cooldown * randomCooldown;
    }

	void FixedUpdate () {
        cooldown--;
        if (cooldown < 0) {
            cooldown = startCooldown + Random.Range(-randomCooldown, randomCooldown);
            Vector2 randomPos = new Vector2(transform.position.x + Random.Range(-randomPosition, randomPosition), transform.position.y + Random.Range(-randomPosition, randomPosition));
            Instantiate(objectToSpawn, randomPos, transform.rotation);
        }
	}
}
