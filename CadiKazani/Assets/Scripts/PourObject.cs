using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PourObject : MonoBehaviour
{

    public UnityEvent OnPourEnd;

    /// <summary>
    /// Time in seconds to rotate to the maxRotation
    /// </summary>
    public float rotationTime = 1;

    /// <summary>
    /// How foar to rotate the object
    /// </summary>
    public float maxRotation = 90;

    /// <summary>
    /// Time in seconds to stay at the max rotation before rotating back
    /// </summary>
    public float pourTime = 0.5f;

    private Vector3 startingRotation;

    private bool rotating;
    private bool waiting;
    private bool rotatingBack;

    private float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        rotating = false;
        waiting = false;
        rotatingBack = false;
        startingRotation = this.transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (rotating)
        {
            // Rotate the object
            timeElapsed += Time.deltaTime;
            this.transform.Rotate(Vector3.right * maxRotation * (Time.deltaTime / rotationTime), Space.Self);

            // Rotate until done pouring
            if (timeElapsed >= rotationTime)
            {
                waiting = true;
                timeElapsed = 0;
                rotating = false;
            }

            // After rotating, we wait before rotating back
        } else if (waiting)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= pourTime)
            {
                timeElapsed = 0;
                waiting = false;
                rotatingBack = true;
            }

            // After waiting, rotate back
        } else if (rotatingBack)
        {
            timeElapsed += Time.deltaTime;
            this.transform.Rotate(-Vector3.right * maxRotation * (Time.deltaTime / rotationTime), Space.Self);

            // At the end of rotation, make sure the rotation is set back to what it was before
            if (timeElapsed >= rotationTime)
            {
                timeElapsed = 0;
                rotatingBack = false;
                this.transform.rotation = Quaternion.Euler(startingRotation);

                OnPourEnd.Invoke();
            }
                
        }
    }

    public void startRotating()
    {
        rotating = true;
    }
}
