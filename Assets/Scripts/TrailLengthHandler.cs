using UnityEngine;
using System.Collections;

public class TrailLengthHandler : MonoBehaviour {
    /*
    [SerializeField]
    private string trailPoolName = "Trail";

    [SerializeField]
    private TrailMovement trailMovement;

    [SerializeField]
    private int trailMaxLength = 20;

    [SerializeField]
    private int trailMinCutLength = 3;

    private float healthPerTrail = 0;

    private int trailsAmount = 0;

    public void StartTrailLengthUpdater()
    {
        healthPerTrail = healthBar.MaxHealth / trailMaxLength;

        StartCoroutine(TrailLengthUpdate());
    }

    IEnumerator TrailLengthUpdate()
    {
        while (healthBar.CurrentHealth != 0)
        {
            //calculate the amount of trails the player must have
            trailsAmount = Mathf.RoundToInt(healthBar.CurrentHealth / healthPerTrail);

            //spawn trails
            if (trailsAmount > trailMovement.TrailParts.Count)
            {
                int difference = trailsAmount - trailMovement.TrailParts.Count;
                for (int i = difference; i > 0; i--)
                {
                    SpawnTrail();
                }
            }//remove trails
            else if (trailsAmount < trailMovement.TrailParts.Count && trailsAmount >= 0)
            {
                RemoveTrailParts(trailsAmount, false);
            }

            yield return new WaitForFixedUpdate();
        }
    }

    public void SpawnTrail()
    {
        if (trailMovement.TrailParts.Count < trailMaxLength)
        {
            //get the object out of the pool
            GameObject spawnedObject = ObjectPool.instance.GetObjectForType(trailPoolName, true);

            spawnedObject.transform.parent = transform;

            //add the object to the trail list
            trailMovement.TrailParts.Add(spawnedObject.transform);

            //set the position of the trail
            if (trailMovement.TrailParts.Count == 1)
            {
                spawnedObject.transform.position = trailMovement.TrailConnectPoint.position;
                spawnedObject.GetComponent<RainbowEffect>().StartColor(1);
                playerColor.FirstTrailRainbowEffect = spawnedObject.GetComponent<RainbowEffect>();
            }
            else
            {
                spawnedObject.transform.position = trailMovement.TrailParts[trailMovement.TrailParts.Count - 2].position;
                spawnedObject.GetComponent<RainbowEffect>().StartColor(trailMovement.TrailParts[trailMovement.TrailParts.Count - 2].GetComponent<RainbowEffect>().ColorIndex);
            }

            spawnedObject.GetComponent<MoveDown>().enabled = false;
            spawnedObject.GetComponent<InteractableObject>().IsEnabled = false;
            spawnedObject.GetComponent<OutOfBoundsPool>().enabled = false;

            //give the trailpart its number in the list, we use this when we remove the trail part later.
            TrailTriggerDetection trailTriggerDetection = spawnedObject.GetComponent<TrailTriggerDetection>();

            trailTriggerDetection.Reset();
            trailTriggerDetection.NumberInList = trailMovement.TrailParts.Count;

            DistanceJoint2D distanceJoint2D = spawnedObject.GetComponent<DistanceJoint2D>();

            if (trailMovement.TrailParts.Count == 1) // this is the neck of the player
            {
                //the connected body is the trailConnectPoint of the player
                distanceJoint2D.connectedBody = trailMovement.TrailConnectPoint.GetComponent<Rigidbody2D>();

                //the distance is closer than normal
                distanceJoint2D.distance = trailMovement.NeckDistance;
            }
            else // a normal trail part
            {
                //the connected body is the last piece of the trial
                distanceJoint2D.connectedBody = trailMovement.TrailParts[trailMovement.TrailParts.Count - 2].GetComponent<Rigidbody2D>();

                //the distance is the normal distance between trails
                distanceJoint2D.distance = trailMovement.DistanceBetweenTrails;
            }
            distanceJoint2D.enabled = true;
        }
    }

    public void RemoveTrailParts(int _numberInList, bool _doDamage)
    {
        //do damage to the players healthbar when the trail is being cut off
        if (_doDamage)
        {
            //if the trail part that is being cut off is too close to the player, cut off another trail that is further away
            if (_numberInList <= trailMinCutLength)
                _numberInList = trailMinCutLength;
            healthBar.addValue((_numberInList - trailMovement.TrailParts.Count) * healthPerTrail);
        }

        //look at the numberInList of the trail part, destroy this trail and every trail that is higher in the list than us.
        for (int i = trailMovement.TrailParts.Count - 1; i >= _numberInList; i--)
        {
            Transform trailToRemove = trailMovement.TrailParts[i];

            //reset the velocity
            trailToRemove.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            //disable the distancejoint
            trailToRemove.GetComponent<DistanceJoint2D>().enabled = false;
            //set movedown on true, so it moves with the enviroment
            trailToRemove.GetComponent<MoveDown>().enabled = trailToRemove.GetComponent<TrailTriggerDetection>().Removed = true;
            //set interactive object on, so the player can eats its own trail
            trailToRemove.GetComponent<InteractableObject>().IsEnabled = true;
            //set outofboundspool on, so it gets deleted once its out of the screen
            trailToRemove.GetComponent<OutOfBoundsPool>().enabled = true;
            //remove the trail out of the list
            trailMovement.TrailParts.Remove(trailToRemove);
        }
    }
    */
}
