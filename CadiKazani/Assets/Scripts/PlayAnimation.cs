using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script to control an animator
/// </summary>
public class PlayAnimation : MonoBehaviour
{
    [Tooltip("The animator to play an animation from (must have playAnim boolean parameter)")]
    public Animator animator;

    private void Start()
    {
        this.animator = this.GetComponent<Animator>();
    }

    /// <summary>
    /// Turn playAnim to true, starting the animation
    /// </summary>
    public void StartAnimation()
    {
        animator.SetBool("playAnim", true);
    }

    /// <summary>
    /// Turn playAnim to false, ending the animation
    /// </summary>
    public void StopAnimation()
    {
        animator.SetBool("playAnim", false);
    }
}
