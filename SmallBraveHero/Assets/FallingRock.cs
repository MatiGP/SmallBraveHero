using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FallingRock : MonoBehaviour
{
    [SerializeField] private GameObject rockGameObject1;
    [SerializeField] private GameObject rockGameObject2;
    [SerializeField] private GameObject rockGameObject3;

    [SerializeField] private float rockFallingDistance = 2f;
    [SerializeField] private float rockFallDuration = 1f;

    [SerializeField] private Ease tweenEase;

    [SerializeField] private float plateFallingDistance = 0.5f;
    [SerializeField] private float plateFallDuration = 0.01f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RockFall();
        PlateFall();
    }

    void RockFall()//spadanie kamieni
    {
        if(rockGameObject1!=null)
        rockGameObject1.transform.DOMoveY(rockGameObject1.transform.position.y - rockFallingDistance, rockFallDuration);

        if(rockGameObject2!=null)
        rockGameObject2.transform.DOMoveY(rockGameObject2.transform.position.y - rockFallingDistance, rockFallDuration);
        
        if(rockGameObject3!=null)
        rockGameObject3.transform.DOMoveY(rockGameObject3.transform.position.y - rockFallingDistance, rockFallDuration);
    }

    void PlateFall()//ukrycie/destroy płytki
    {
        GameObject.Destroy(gameObject);
        //transform.DOMoveY(transform.position.y - plateFallingDistance, plateFallDuration);
    }
}