using UnityEngine;
using System.Collections;

public class RandomizedCooldown : MonoBehaviour {

    [SerializeField]
    private float cooldown = 1f;

    private float normalCooldownStartValue;

    [SerializeField]
    private float cooldownRandomizer = 0.3f;

    private bool executing = true;

    void Start() {
        normalCooldownStartValue = cooldown;
    }

    void FixedUpdate() {
        cooldown--;
        if (cooldown < 0) {
            cooldown = normalCooldownStartValue + Random.Range(-cooldownRandomizer, cooldownRandomizer);
            if(executing)
                Execute();
        }
    }

    virtual protected void Execute() {

    }

    public bool Executing
    {
        set { executing = value; }
    }
}
