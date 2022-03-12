using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script stores the potion's points for the different outcomes.
/// </summary>
public class PotionPoints : MonoBehaviour
{

   
    // Having this as an array makes it easy to add more outcomes in the future
    [Tooltip("Values for the potion. Each index stores the points for a different outcome: \n0 - Cat \n1 - Duck \n2 - Shrek")]
    public int[] points = { 0, 0, 0 };

    /// <summary>
    /// Get the point array for the potions
    /// </summary>
    /// <returns> the array of points </returns>
    public int[] getPoints()
    {
        return points;
    }
}
