using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Equipment.Items
{
    public class Weapon : Item
    {
        [SerializeField] private int weaponMinDamage;
        public int WeaponMinDamage { get => weaponMinDamage; }
        [SerializeField] private int weaponMaxDamage;
        public int WeaponMaxDamage { get => weaponMaxDamage; }

        [SerializeField] private float weaponSpeed;
        public float WeaponSpeed { get => weaponSpeed; }

        public override void Use(Inventory inventory)
        {
            Inventory.Instance.WeaponHolder.EquipWeapon(this);
        }
    }
}
