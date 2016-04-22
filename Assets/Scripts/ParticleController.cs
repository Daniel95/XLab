using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour {

    [SerializeField]
    private float sizeToShrinkTo = 0.1f;

    [SerializeField]
    private float alphaToFadeTo = 0;

    private Shrink shrink;

    private Fade fade;

    void OnEnable()
    {
        shrink.FinishedShrinking += DoneShrinking;
        fade.FinishedFading += DoneFading;
    }

    void OnDisable()
    {
        shrink.FinishedShrinking -= DoneShrinking;
        fade.FinishedFading -= DoneFading;
    }

    void Awake() {
        shrink = GetComponent<Shrink>();
        fade = GetComponent<Fade>();

        shrink.StartShrinking(sizeToShrinkTo);
    }

    private void DoneShrinking() {
        fade.StartFading(alphaToFadeTo);
    }

    private void DoneFading()
    {
        Destroy(gameObject);
    }
}
