using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TrailMovement : MonoBehaviour
{
    /*
    [SerializeField]
    private TrailLengthHandler trailLengthHandler;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private Transform trailConnectPoint;

    [SerializeField]
    private GameObject wings;
    [SerializeField]
    private Animator[] wingAnimators;

    private PlayerMovement playerMovement;

    private PowerupHandler powerupHandler;

    [SerializeField]
    private float trailAutoSpeedMultiplier = 4;

    [SerializeField]
    private float superModeSpeedMultiplier = 20;

    [SerializeField]
    private float trailGravityMultiplier = 50;

    [SerializeField]
    private float distanceBetweenTrails = 0.5f;

    [SerializeField]
    private float neckDistance = 0.2f;

    [SerializeField]
    private float startTrailSize = 0.4f;

    [SerializeField]
    private int trailEndAmount = 3;

    [SerializeField]
    private float trailSizeDecrement = 0.05f;

    [SerializeField]
    private HealthBar healthbar;

    [SerializeField]
    private int wingTrailNumber = 4;

    private bool superMode;

    private List<Transform> trailParts = new List<Transform>();

    // Use this for initialization
    void Awake()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        powerupHandler = player.GetComponent<PowerupHandler>();
    }

    void OnEnable()
    {
        healthbar.EnterSuperMode += EnteredSuperMode;
        healthbar.EnterNormalMode += EnteredNormalMode;
        powerupHandler.AddedShield += AddedShieldPowerup;
        powerupHandler.RemovedShield += RemovedShieldPowerup;
    }

    void OnDisable()
    {
        healthbar.EnterSuperMode -= EnteredSuperMode;
        healthbar.EnterNormalMode -= EnteredNormalMode;
        powerupHandler.AddedShield -= AddedShieldPowerup;
        powerupHandler.RemovedShield -= RemovedShieldPowerup;
    }

    /*
    public void StartTrail()
    {
        trailLengthHandler.StartTrailLengthUpdater();
    }
    
    private IEnumerator WaitForObjectPool()
    {
        //wait one frame, so the object pool is loaded
        yield return new WaitForFixedUpdate();

        trailLengthHandler.StartTrailLengthUpdater();
    }


    void FixedUpdate()
    {
        Vector2 lastPosition = trailConnectPoint.position;

        // Update the movement of the Trails
        for (int i = 0; i < trailParts.Count; i++)
        {

            //so i dont have to wirte trailsParts[i] all the time
            Transform currentTrail = trailParts[i];

            //the difference in vector to the target
            Vector2 vectorToTarget = lastPosition - new Vector2(currentTrail.position.x, currentTrail.position.y);

            //calculate the angle to our target
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90;

            //use the angle to get the rotation to our target
            currentTrail.rotation = Quaternion.Euler(0, 0, angle);

            //give the trail gravity
            Vector3 velocity = new Vector3(0, -GameSpeed.MoveSpeed * trailGravityMultiplier, 0);

            float minDistance = distanceBetweenTrails;

            if (i == 0) minDistance = neckDistance;

            //float minDistance = distanceBetweenTrails;
            if (Vector2.Distance(currentTrail.position, lastPosition) > minDistance)
            {
                //move to the object, the further the object is, the faster we move. we use this to counter the gravity of the trail
                velocity += (new Vector3(vectorToTarget.x, vectorToTarget.y, 0) * trailAutoSpeedMultiplier) * (GameSpeed.SpeedMultiplier + GameSpeed.ExtraSpeed * superModeSpeedMultiplier);

                //move when the players moves
                velocity += currentTrail.transform.up * playerMovement.TotalSpeed;
            }

            //give the trailparts its velocity
            currentTrail.GetComponent<Rigidbody2D>().velocity = velocity;

            //set lastPosition on our new position. we use this so we know where the next trail parts needs to rotate to.
            lastPosition = currentTrail.transform.position;

            if (i >= trailParts.Count - trailEndAmount)
            {
                //calculate which trail this is in the endAmount
                int numberInEnd = i - trailParts.Count + trailEndAmount + 1;

                //the higher the numberInEnd, the lower the scale
                currentTrail.localScale = new Vector2(startTrailSize, startTrailSize) - new Vector2(numberInEnd * trailSizeDecrement, numberInEnd * trailSizeDecrement);
            } else
                currentTrail.localScale = new Vector2(startTrailSize, startTrailSize);
        }
    }

    void EnteredSuperMode()
    {
        //add a different sprite to a selected trail
        if (trailParts.Count > wingTrailNumber)
        {
            foreach (Animator temp in wingAnimators)
            {
                temp.SetBool("superMode", true);
                temp.gameObject.GetComponent<Fade>().StartFade();
            }
            wings.GetComponent<HaveSamePositionAsTarget>().Target = trailParts[wingTrailNumber-1].transform;
        }
    }

    void EnteredNormalMode() {
        //reset the sprite of the selected trial
        if (trailParts.Count > wingTrailNumber)
        {
            foreach (Animator temp in wingAnimators)
            {
                temp.SetBool("superMode", false);
                temp.gameObject.GetComponent<Fade>().EndFade();
            }
        }
    }



    //disable the collision of the trails when the shield effect starts
    void AddedShieldPowerup() {
        for (int i = 0; i < trailParts.Count; i++) {
            trailParts[i].GetComponent<TrailTriggerDetection>().Shielded = true;
        }
    }

    //enable the collision of the trails when the shield effect is over
    void RemovedShieldPowerup() {
        for (int i = 0; i < trailParts.Count; i++)
        {
            trailParts[i].GetComponent<TrailTriggerDetection>().Shielded = false;
        }
    }
    public List<Transform> TrailParts
    {
        get { return trailParts; }
    }

    public Transform TrailConnectPoint
    {
        get { return trailConnectPoint; }
    }

    public float DistanceBetweenTrails
    {
        get { return distanceBetweenTrails; }
    }

    public float NeckDistance
    {
        get { return neckDistance; }
    }
    */
}