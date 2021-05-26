using Code.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Equipment.Items
{
    [CreateAssetMenu(fileName = "NewWeapon", menuName = "Items/Consumeable")]
    public class Consumeable : Item
    {
        public override void Use(Inventory inventory)
        {
            inventory.GetComponent<Health>().Heal(8);
        }      
    }
}
