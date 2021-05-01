using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Code.StateMachine.AI.Actions;

[CustomEditor(typeof(AttackThePlayer))]
public class ShowMultipleAttacsArray : Editor
{
    Rect size = new Rect(0, 0, 100, 400);

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.BeginVertical();

        AttackThePlayer attackThePlayer = target as AttackThePlayer;

        attackThePlayer.isRanged = GUILayout.Toggle(attackThePlayer.isRanged, "Is Ranged");

        attackThePlayer.hasMultipleAttacks = GUILayout.Toggle(attackThePlayer.hasMultipleAttacks, "Has Multiple Attacks");

        EditorGUILayout.BeginHorizontal();
        if (attackThePlayer.hasMultipleAttacks)
        {            
            attackThePlayer.attackCount = EditorGUILayout.IntField("Attack Count: ", attackThePlayer.attackCount);           
        }
        else
        {
            attackThePlayer.attackCount = 0;
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.EndVertical();
    }
}
