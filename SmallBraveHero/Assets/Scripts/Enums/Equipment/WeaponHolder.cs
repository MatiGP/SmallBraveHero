using Code.Equipment.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Equipment
{
    public class WeaponHolder : MonoBehaviour
    {
        public event EventHandler OnAttack;

        [SerializeField] private SpriteRenderer weaponRenderer;
        [SerializeField] private Animator animator;
        [SerializeField] private Weapon currentWeapon;
        public Weapon CurrentWeapon { get => currentWeapon; }
        [SerializeField] private BoxCollider2D weaponCollider;   

        public bool HasWeapon { get => currentWeapon != null; }

        float attackDelay;
        int damage;           

        private void Update()
        {
            if(attackDelay > 0)
            {
                attackDelay -= Time.deltaTime;
                return;
            }

            if (!HasWeapon)
            {
                return;
            }
          
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                OnAttack.Invoke(this, EventArgs.Empty);
                
            }

        }      

        public void EquipWeapon(Weapon weapon)
        {
            currentWeapon = weapon;
            weaponRenderer.sprite = weapon.ItemSprite;
            weaponCollider.size = currentWeapon.WeaponColliderSize;
            weaponCollider.offset = weaponRenderer.transform.position + currentWeapon.WeaponColliderOffset;
            animator.Play("Idle");
        }

        public void DequipWeapon()
        {
            
        }

        public void Attack()
        {           
            damage = UnityEngine.Random.Range(currentWeapon.WeaponMinDamage, currentWeapon.WeaponMaxDamage + 1);
            attackDelay = currentWeapon.WeaponSpeed;
            animator.Play("Swing");
        }

        public void EnableWeaponCollider()
        {
            weaponCollider.enabled = true;
        }

        public void DisableWeaponCollider()
        {
            weaponCollider.enabled = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Enemy")
            {
                collision.GetComponent<Health>().TakeDamage(damage);
            }
        }

        private void OnDrawGizmos()
        {
            if (!currentWeapon)
            {
                return;
            }

            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(weaponRenderer.transform.position + currentWeapon.WeaponColliderOffset, currentWeapon.WeaponColliderSize);
        }
    }

    
}
