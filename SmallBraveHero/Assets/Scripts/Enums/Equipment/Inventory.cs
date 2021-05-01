using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Code.Equipment.Items;

namespace Code.Equipment
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] WeaponHolder weaponHolder;
        public WeaponHolder WeaponHolder { get => weaponHolder; }

        public static Inventory Instance;

        Item[] equippedItems = new Item[5];
        Item[] itemsInBackpack;

        private void Awake()
        {
            Instance = this;
        }
    }
}
