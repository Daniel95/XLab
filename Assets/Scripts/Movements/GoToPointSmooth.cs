using UnityEngine;
using System.Collections;

public class GoToPointSmooth : MonoBehaviour
{
    //delegate type
    public delegate void ReachedPointMethod();

    //delegate instance
    public ReachedPointMethod ReachedPoint;

    [SerializeField]
    private float maxSpeed = 0.03f;

    /** The heavyier the object, the more momentum it has while steering */
    [SerializeField]
    private float mass = 100;

    [SerializeField]
    private float minDistanceToPoint = 0.5f;

    /** Vector to save the current velocity, X & Y */
    private Vector2 currentVelocity;
    /** Vector to save the current position, X & Y */
    private Vector2 currentPosition;
    /** Vector om de locatie bij te houden waar we heen willen */
    /** Vector to save the position of the current target*/
    private Vector2 currentPoint;

    void Start()
    {
        // we starten zonder beweging (geen velocity)
        currentVelocity = new Vector2();
        // Assign currentPosition to the start position of this object
        currentPosition = transform.position;
    }

    // Get the target V3 from another script
    public Vector3 Point
    {
        get { return currentPoint; }
        set { currentPoint = value; }
    }

    public void StartSeeking() {
        StartCoroutine(Seek());
    }

    public void StopSeeking()
    {
        StopCoroutine(Seek());
    }

    IEnumerator Seek() {
        currentPosition = transform.position;

        while (CheckDistanceToPoint()) {
            // we berekenen eerst de afstand/Vector tot de 'target' (in dit voorbeeld het mikpunt)		
            Vector2 desiredStep = currentPoint - currentPosition;
            // deze desiredStep mag niet groter zijn dan de maximale Speed
            //
            // als een vector ge'normalized' is .. dan houdt hij dezelfde richting
            // maar zijn lengte/magnitude is 1
            desiredStep.Normalize();

            // als je deze genormaliseerde vector weer vermenigvuldigt met de maximale snelheid dan
            // wordt de lengte van deze Vector maxSpeed (aangezien 1 x maxSpeed = maxSpeed)
            // de x en y van deze Vector wordt zo vanzelf omgerekend
            Vector2 desiredVelocity = desiredStep * maxSpeed;

            // bereken wat de Vector moet zijn om bij te sturen om bij de desiredVelocity te komen
            Vector2 steeringForce = desiredVelocity - currentVelocity;

            // uiteindelijk voegen we de steering force toe maar wel gedeeld door de 'mass'
            // hierdoor gaat hij niet in een rechte lijn naar de target
            // hoe zwaarder het object des te groter de bocht
            currentVelocity += steeringForce / mass;

            // Als laatste updaten we de positie door daar onze beweging (velocity) bij op te tellen
            currentPosition += currentVelocity;
            transform.position = currentPosition;
            
            yield return new WaitForFixedUpdate();
        }

        if (ReachedPoint != null)
            ReachedPoint();
    }

    //checks if the distance between this object and the currentPoint is lower then minDistanceToPoint
    public bool CheckDistanceToPoint()
    {
        //check if the distance is higher than the minimal distance to the point
        if (Vector3.Distance(transform.position, currentPoint) > minDistanceToPoint)
            return true;
        else
            return false;
    }
}