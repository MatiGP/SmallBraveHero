using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Code.Equipment.Items;
using System;

namespace Code.Equipment
{
    public class Inventory : MonoBehaviour
    {
        public static event Action<Item, int> OnItemEquipped;

        public static Inventory Instance; 

        [SerializeField] WeaponHolder weaponHolder;
        public WeaponHolder WeaponHolder { get => weaponHolder; }

        Item[] equippedItems = new Item[5];

        private void Awake()
        {
            Instance = this;
        }

        public void EquipItem(EItemSlot slot, Item item)
        {
            equippedItems[(int)slot] = item;

            OnItemEquipped.Invoke(item, (int)slot);
        }
    }
}
