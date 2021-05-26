using Code.Equipment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Code.Equipment.Items;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] private Image[] itemSlots = new Image[5];

    private void Awake()
    {
        BindEvents();
    }

    private void BindEvents()
    {
        Inventory.OnItemEquipped += Inventory_OnItemEquipped;
    }

    private void UnBindEvents()
    {
        Inventory.OnItemEquipped -= Inventory_OnItemEquipped;
    }

    private void Inventory_OnItemEquipped(Item newItem, int slot)
    {
        itemSlots[slot].gameObject.SetActive(true);

        itemSlots[slot].sprite = newItem.ItemSprite;
    }

    private void OnDestroy()
    {
        UnBindEvents();
    }
}
