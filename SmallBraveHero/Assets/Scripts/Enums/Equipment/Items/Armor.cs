using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Equipment.Items
{
    [CreateAssetMenu(fileName = "NewArmor", menuName = "Items/Armor")]
    public class Armor : Item
    {
        [SerializeField] private EItemSlot slot = EItemSlot.BodyArmor;

        [SerializeField] private int bonusDefence = 2;
  
        public override void Use(Inventory inventory)
        {
            inventory.EquipItem(slot, this);
        }
    }
}
