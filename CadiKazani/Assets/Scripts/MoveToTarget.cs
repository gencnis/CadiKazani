using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Script to move an object to / from a target object
/// 
/// @author Alex Wills
/// </summary>
public class MoveToTarget : MonoBehaviour
{
    public UnityEvent OnTargetArrival;
    public UnityEvent OnHomeArrival;

    /// <summary>
    /// This variable can be used so that only one object can move at a time
    /// </summary>
    private static bool allowedToMove = true;

    /// <summary>
    /// The object to gradually move towards
    /// </summary>
    public GameObject target;
    private Transform targetTransform;

    /// <summary>
    /// How long this object should take to move to its destination
    /// </summary>
    public float moveTime;

    // Remember where this object started so we can go back later
    private Vector3 startPoint;

    // This is the distance to travel from point A to point B
    private Vector3 pathToTravel;

    // This is true when the object is moving
    private bool moving;
    private float timeElapsed;

    // This variable tells which unity event to call
    private bool toTarget;

    // Start is called before the first frame update
    void Start()
    {
        targetTransform = target.transform;
        startPoint = this.transform.position;
        moving = false;
        timeElapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 deltaDistance;

        // Only do something if we are moving
        if (moving)
        {
            // Move towards the destination
            deltaDistance = pathToTravel * (Time.deltaTime / moveTime);
            this.transform.Translate(deltaDistance, Space.World);

            // Stop moving if enough time has passed
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= moveTime)
            {
                moving = false;
                timeElapsed = 0;

                // Determine which event to call based on which direction the object moved
                if (toTarget)
                {
                    OnTargetArrival.Invoke();
                }
                else
                {
                    OnHomeArrival.Invoke();
                    
                }
            }
        }
    }

    /// <summary>
    /// Gradually move this object to the target from where it is
    /// </summary>
    public void StartMovingToTarget()
    {
        // Only start moving if it is allowed to, and it is not already moving
        if (!moving && allowedToMove)
        {
            pathToTravel = targetTransform.position - this.transform.position;
            moving = true;
            toTarget = true;

            // Only let one object move at a time
            allowedToMove = false;
        }
    }

    /// <summary>
    /// Gradually move this object to its starting point from where it is
    /// </summary>
    public void StartMovingBackToStart()
    {
        if (!moving)
        {
            allowedToMove = true;
            pathToTravel = startPoint - this.transform.position;
            moving = true;
            toTarget = false;
        }
    }

}
