using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer bodyRenderer;
    [SerializeField] private SpriteRenderer headRenderer;
    [SerializeField] private SpriteRenderer legsRenderer;
    [SerializeField] private SpriteRenderer armsRenderer;

    [SerializeField] private Animator bodyAnimator;
    [SerializeField] private Animator headAnimator;
    [SerializeField] private Animator legsAnimator;
    [SerializeField] private Animator armsAnimator;

    public float Direction { get => headRenderer.flipX ? -1 : 1; }

    private string currentAnimationState = "";

    public void PlayAnimation(string animName)
    {
        bodyAnimator.Play(animName);
        headAnimator.Play(animName);       
        legsAnimator.Play(animName);

        currentAnimationState = animName;
    }

    public void FlipBodyRenderer(float direction)
    {      
        if (direction == 1)
        {
            bodyRenderer.flipX = false;
            headRenderer.flipX = false;
            legsRenderer.flipX = false;
            armsRenderer.flipX = false;
        }
        else if (direction == -1)
        {
            bodyRenderer.flipX = true;
            headRenderer.flipX = true;
            legsRenderer.flipX = true;
            armsRenderer.flipX = true;
        }
    }

    public void PlayArmsAnimation(string animName)
    {
        armsAnimator.Play(animName);
    }

    public void PlayDefaultArmsAnim()
    {
        armsAnimator.Play(currentAnimationState);
    }


    
}
