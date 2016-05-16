using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayParticleOnCollision : MonoBehaviour {

    [SerializeField]
    private List<Transform> explosionEffect;

    [SerializeField]
    private string tagToPlayEffectOn;

    private void OnCollisionEnter(Collision _coll) {
        if (_coll.gameObject.tag == tagToPlayEffectOn)
        {
            Transform particleEffect = Instantiate(explosionEffect[Random.Range(0,explosionEffect.Count)], transform.position, transform.rotation) as Transform;
            StartCoroutine(WaitForParticleFinish(particleEffect));
        }
    }
    
    IEnumerator WaitForParticleFinish(Transform _particleObj) {
        WaitForFixedUpdate _waitForFixedUpdate = new WaitForFixedUpdate();

        ParticleSystem _particleSystem = _particleObj.GetComponentInChildren<ParticleSystem>();

        while (_particleSystem.isPlaying) {
            yield return _waitForFixedUpdate;
        }

        Destroy(_particleObj.gameObject);
    }
}
