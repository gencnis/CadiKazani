using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script stores all of the cauldron's points, and figures out what the outcome should be.
/// </summary>
public class CauldronCalculator : MonoBehaviour
{
    private GameObject frog;
    private FrogTransfiguration frogScript;
    private int numPotions = 0;


    // Keep consistent with PotionPoints.cs. [0] - cat, [1] - duck, [2] - shrek
    private int[] cauldronPoints = new int[3];

    private void Start()
    {
        frog = GameObject.Find("Stone_Frog_Green");
        frogScript = frog.GetComponent<FrogTransfiguration>();

    }

    /// <summary>
    /// Adds a potion to this cauldron!
    /// </summary>
    /// <param name="potion"> The potion object to add to the cauldron </param>
    public void AddPotion(GameObject potion)
    {

        // Keep track of how many potions you have added
        numPotions++;
        PotionPoints potionScript = potion.GetComponent<PotionPoints>();
        int[] potionArray = potionScript.getPoints();

        // Add all of the points to the cauldron's total
        for(int i = 0; i < potionArray.Length; i++)
        {
            cauldronPoints[i] += potionArray[i];
        }


        if(numPotions >= 3)
        {
            ChooseOutcome();
        }
    }


    private void CreateShrek()
    {
        frogScript.transfigureShrek();
    }

    private void CreateDuck()
    {
        frogScript.transfigureDuck();
    }

    private void CreateCat()
    {
        frogScript.transfigureCat();
    }

    /// <summary>
    /// Chooses an outcome based on which value in the array has the most points
    /// </summary>
    public void ChooseOutcome()
    {
        int maxPoints = 0;
        int highestIndex = 0;

        // Find the largest number of points
        for(int i = 0; i < cauldronPoints.Length; i++)
        {
            if (cauldronPoints[i] > maxPoints)
            {
                maxPoints = cauldronPoints[i];
                highestIndex = i;
            }
        }

        Debug.Log("CAT: " + cauldronPoints[0] + ", DUCK: " + cauldronPoints[1] + ", SHREK: " + cauldronPoints[2]);

        // Determine which outcome to choose
        if(highestIndex == 0)
        {
            // Cat
            CreateCat();
            

        } else if (highestIndex == 1)
        {
            // Duck
            CreateDuck();

        } else if (highestIndex == 2)
        {
            // Shrek
            CreateShrek();

        }
    }

    /// <summary>
    /// Get the number of potions that have been added to this cauldron
    /// </summary>
    /// <returns> the number of potions in this cauldron </returns>
    public int getNumPotions()
    {
        return numPotions;
    }
}
