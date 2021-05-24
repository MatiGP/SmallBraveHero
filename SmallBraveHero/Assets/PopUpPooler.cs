using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpPooler : MonoBehaviour
{
    public static PopUpPooler Instance;

    [SerializeField] private PopUp popUpPrefab = null;
    [SerializeField] private Queue<PopUp> popUpQueue = null;
    [SerializeField] private int popUpCount = 5;

    private void Awake()
    {
        Instance = this;
        PreparePool();
    }

    private void PreparePool()
    {
        popUpQueue = new Queue<PopUp>();

        for(int i = 0; i < popUpCount; i++)
        {
            PopUp popUp = Instantiate(popUpPrefab, transform);
            popUp.gameObject.SetActive(false);
            
            popUpQueue.Enqueue(popUp);
        }
    }

    public void DisablePopUp(PopUp popUp)
    {
        popUp.gameObject.SetActive(false);
        popUpQueue.Enqueue(popUp);      
    }

    public void SpawnPopUpFromQueue(string popUpText, Vector3 position)
    {
        PopUp newPopUp = popUpQueue.Dequeue();
        newPopUp.SetPopUpText(popUpText);
        newPopUp.MoveToPosition(position);
        newPopUp.PlayPopUpAnim();
    }


}
