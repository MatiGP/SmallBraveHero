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
        [SerializeField] private Weapon weapon;

        public bool HasWeapon { get => weapon != null; }
        
        public void EquipWeapon(Weapon weapon)
        {
            
            animator.Play("Idle");
        }

        public void DequipWeapon()
        {
            
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
