using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Equipment.Items
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapon")]
    public class Weapon : Item
    {
        [SerializeField] private float weaponRange;
        public float WeaponRange { get => weaponRange; }

        [SerializeField] private float weaponSpeed;
        public float WeaponSpeed { get => weaponSpeed; }

        [SerializeField] private int weaponDamage;
        public int WeaponDamage { get => weaponDamage; }
    }
}
