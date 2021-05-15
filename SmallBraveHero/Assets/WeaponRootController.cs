using Code.Equipment;
using Code.Equipment.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRootController : MonoBehaviour
{
    [Header("Weapon Flip Settings")]
    [SerializeField] float weaponMaxAngle = 80f;
    [SerializeField] float weaponMinAngle = -80f;
    [SerializeField] WeaponHolder weaponHolder;

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

        float angle = PlayerController.AngleBetweenPlayerAndCursor;

        if (weaponHolder.CurrentWeapon.WeaponType == WeaponType.Melee)
        {
            if (angle < weaponMaxAngle && angle > weaponMinAngle)
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
