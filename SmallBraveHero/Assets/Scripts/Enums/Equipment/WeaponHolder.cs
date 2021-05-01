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
        [SerializeField] private Weapon currentWeapon;

        public bool HasWeapon { get => currentWeapon != null; }

        float attackDelay;

        private void Update()
        {
            if(attackDelay > 0)
            {
                attackDelay -= Time.deltaTime;
                return;
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
            }
        }

        public void EquipWeapon(Weapon weapon)
        {
            currentWeapon = weapon;
            weaponRenderer.sprite = weapon.ItemSprite;
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
            attackDelay = currentWeapon.WeaponSpeed;
            animator.Play("Swing");
        }
    }
}
