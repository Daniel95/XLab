using UnityEngine;
using System.Collections;

public class RandomizedCooldown : MonoBehaviour {

    [SerializeField]
    private float cooldown = 1f;

    private float normalCooldownStartValue;

    [SerializeField]
    private float cooldownRandomizer = 0.3f;

    void Start() {
        normalCooldownStartValue = cooldown;
    }

    void FixedUpdate() {
        cooldown--;
        if (cooldown < 0) {
            cooldown = Random.Range(-cooldownRandomizer, cooldownRandomizer);
            Execute();
        }
    }

    virtual protected void Execute() {

    }
}
