using System.Collections;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance;

    [SerializeField] private Image characterHeadRenderer;
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private TextMeshProUGUI characterSentence;
    [SerializeField] private GameObject dialogFrame;
    [SerializeField] private float dialogTypingDelay;
    [SerializeField] private float dialogFrameMoveDuration;
    [SerializeField] private float dialogHeight;

    private float originYDialogFrame = -230f;
   

    private void Awake()
    {
        Instance = this;
    }

    public void SetUpDialog(Sprite headRenderer, string charName, string charSentence)
    {
        Debug.Log("Setting Up Dialog");

        characterHeadRenderer.sprite = headRenderer;
        characterName.text = charName;

        dialogFrame.transform.DOMoveY(originYDialogFrame + dialogHeight, dialogFrameMoveDuration).OnComplete(
            () => StartCoroutine(StartTypingSentence(charSentence)));
    }

    private IEnumerator StartTypingSentence(string charSentence)
    {
        characterSentence.text = "";

        for(int i = 0; i < charSentence.Length; i++)
        {
            characterSentence.text += charSentence[i];
            yield return new WaitForSeconds(dialogTypingDelay);
        }       
    }

    public void HideDialog()
    {
        dialogFrame.transform.DOMoveY(30 - dialogHeight, dialogFrameMoveDuration).OnComplete(ClearDialog);
    }

    private void ClearDialog()
    {
        characterName.text = "";
        characterSentence.text = "";
    }
}
