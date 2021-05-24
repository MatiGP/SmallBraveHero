using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class PopUp : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI popUpText = null;

    [SerializeField] private Color damageColor;
    [SerializeField] private Color healColor;
    [SerializeField] private float popUpMoveHeight = 30f;
    [SerializeField] private float popUpMoveDuration = 1f;
    [SerializeField] private float popUpOffset = 10f;
    [SerializeField] private Ease tweenEase;

    public void SetPopUpText(string text)
    {
        popUpText.SetText(text);
        if(text[0] == '+')
        {
            popUpText.color = healColor;
        }
        else
        {
            popUpText.color = damageColor;
        }
    }

    public void MoveToPosition(Vector3 position)
    {
        position.y += popUpOffset;
        transform.position = position;
        gameObject.SetActive(true);
    }

    public void PlayPopUpAnim()
    {
        transform.DOMoveY(transform.position.y + popUpMoveHeight, popUpMoveDuration)
            .SetEase(tweenEase)
            .OnComplete(() => {
            PopUpPooler.Instance.DisablePopUp(this);
        });
    }
}
