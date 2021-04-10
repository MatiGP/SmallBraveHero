using Code.Equipment.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Equipment
{
    public class WeaponHolder : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer weaponRenderer;
        [SerializeField] private Animator animator;

        private bool HasWeapon { get => currentWeapon != null; }
        private Weapon currentWeapon;
        
        public void EquipWeapon(Weapon weapon)
        {
            currentWeapon = weapon;
            weaponRenderer.sprite = weapon.ItemSprite;
            animator.Play("Idle");
        }

        public void DequipWeapon()
        {
            currentWeapon = null;
        }

        public void Attack()
        {
            if (!HasWeapon)
            {
                return;
            }

            animator.Play("Swing");
        }
    }
}
