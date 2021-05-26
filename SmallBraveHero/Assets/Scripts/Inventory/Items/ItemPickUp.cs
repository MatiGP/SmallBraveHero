using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Code.Equipment.Items;
using Code.Equipment;
using DG.Tweening;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField] private Item item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log($"Picking up a new item {item.ItemName}");
            item.Use(collision.GetComponent<Inventory>());
            transform.parent.gameObject.SetActive(false);
        }
    }
}
