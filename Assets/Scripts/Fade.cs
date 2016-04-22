using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour {

    //delegate type
    public delegate void FadeMethod();

    //delegate instance
    public FadeMethod FinishedFading;

    [SerializeField]
    private float time = 1;

    private Renderer renderer;

    private float velocity;

	// Use this for initialization
	void Start () {
        renderer = GetComponent<Renderer>();
    }

    public void StartFading(float _alpha) {
        StartCoroutine(Fading(_alpha));
    }

    IEnumerator Fading(float _minAlpha)
    {
        while (renderer.material.color.a > _minAlpha * 1.1f)
        {
            Color color = renderer.material.color;
            color.a = Mathf.SmoothDamp(color.a, _minAlpha, ref velocity, time);
            renderer.material.color = color;
            yield return new WaitForFixedUpdate();
        }
        
        if (FinishedFading != null)
            FinishedFading();
    }
}
