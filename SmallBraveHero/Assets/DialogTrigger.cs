using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] private Sprite headIcon;    
    [SerializeField] private string charName;
    [TextArea(1,3)]
    [SerializeField] private string sentence;    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision!");

        if (collision.tag == "Player")
        {
            DialogManager.Instance.SetUpDialog(headIcon, charName, sentence);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            DialogManager.Instance.HideDialog();
        }
    }
}
