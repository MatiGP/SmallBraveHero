using Code.Equipment;
using Code.Equipment.Items;
using UnityEngine;

public class WeaponRootController : MonoBehaviour
{
    [SerializeField] private WeaponHolder weaponHolder;
    [SerializeField] private PlayerController playerController;

    private void Awake()
    {
        weaponHolder.OnAttack += RotateWeapon;
        weaponHolder.OnAttackCompleted += PlayDefaultArmsAnimation;
    }

    private void PlayDefaultArmsAnimation(object sender, System.EventArgs e)
    {
        playerController.PlayerModel.PlayDefaultArmsAnim();
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
