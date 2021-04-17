using Code.StateMachine.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    [SerializeField] AIController controller;
    [SerializeField] AttackCollider[] attackColliders;


    //Attack Index => Jaki AttackCollider ma być użyty.
    public void HitEvent(int attackIndex)
    {
        Debug.Log($"Calling HitEvent from animation event with parameters : [attackIndex : {attackIndex}]");

        if(attackIndex > attackColliders.Length-1)
        {
            Debug.Log("Bad AttackIndex, returning.");
            return;
        }
        // Pozycja ataku
        Vector3 attackPosition = (Vector2)transform.position + attackColliders[attackIndex].AttackPosition;
        // Skanowanie w poszukiwaniu gracza w konkretnej klatce animacji.
        Collider2D playerCollider = Physics2D.OverlapCircle(attackPosition, 
            attackColliders[attackIndex].AttackRadius, LayerMask.GetMask("Player"));

        if(playerCollider != null)
        {
            Debug.Log("Player is taking damage!");
            controller.Target.CharacterHealth.TakeDamage(attackColliders[attackIndex].AttackDamage);
        }

    }
    //Gizmosy by zwizualizować collidery ataku.
    private void OnDrawGizmosSelected()
    {
        for(int i = 0; i < attackColliders.Length; i++)
        {
            Vector3 attackPosition = (Vector2)transform.position + attackColliders[i].AttackPosition;

            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(attackPosition, attackColliders[i].AttackRadius);
        }
    }
}

[System.Serializable]
struct AttackCollider
{
    [SerializeField] Vector2 attackPosition;
    public Vector2 AttackPosition { get => attackPosition; }
    [SerializeField] float attackRadius;
    public float AttackRadius { get => attackRadius; }
    [SerializeField] int attackDamage;
    public int AttackDamage { get => attackDamage; }
}
