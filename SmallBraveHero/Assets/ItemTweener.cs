using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemTweener : MonoBehaviour
{
    [SerializeField] private float itemFloatHeight;
    [SerializeField] private float itemFloatSpeed;
    [SerializeField] private Ease tweenEase;

    // Start is called before the first frame update
    void Start()
    {
        transform.DOMoveY(transform.position.y + itemFloatHeight, itemFloatSpeed)
            .SetEase(tweenEase)
            .SetLoops(-1, LoopType.Yoyo);
    }

}
