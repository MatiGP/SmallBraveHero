using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Equipment.Items
{
    [CreateAssetMenu(fileName = "NewWeapon", menuName = "Items/Weapon")]
    public class Weapon : Item
    {
        [SerializeField] private int weaponMinDamage;
        public int WeaponMinDamage { get => weaponMinDamage; }

        [SerializeField] private int weaponMaxDamage;
        public int WeaponMaxDamage { get => weaponMaxDamage; }

        [SerializeField] private float weaponSpeed;
        public float WeaponSpeed { get => weaponSpeed; }

        [SerializeField] private WeaponType weaponType;
        public WeaponType WeaponType { get => weaponType; }
    
        [SerializeField] private Vector2 weaponColliderSize;
        public Vector2 WeaponColliderSize { get => weaponColliderSize; }

        [SerializeField] private Vector3 weaponColliderOffset;
        public Vector3 WeaponColliderOffset { get => weaponColliderOffset; }

        [SerializeField] private EItemSlot slot = EItemSlot.Weapon;      

        public override void Use(Inventory inventory)
        {
            inventory.WeaponHolder.EquipWeapon(this);
            inventory.EquipItem(slot, this);
        }

        
    }

    public enum WeaponType { Melee, Ranged }
}
