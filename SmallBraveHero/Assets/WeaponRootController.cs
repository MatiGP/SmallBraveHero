using Code.Equipment;
using Code.Equipment.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRootController : MonoBehaviour
{
    [Header("Weapon Flip Settings")]
    [SerializeField] private WeaponHolder weaponHolder;
    [SerializeField] private PlayerController playerController;

    private void Awake()
    {
        weaponHolder.OnAttack += RotateWeapon;
    }

    private void RotateWeapon(object sender, System.EventArgs e)
    {
        if (!weaponHolder.HasWeapon)
        {
            return;
        }

        if (weaponHolder.CurrentWeapon.WeaponType == WeaponType.Melee)
        {
            if (playerController.IsFacingRight)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    } 
    
}
