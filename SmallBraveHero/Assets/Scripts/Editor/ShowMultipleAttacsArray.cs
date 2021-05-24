using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Code.StateMachine.AI.Actions;

[CustomEditor(typeof(AttackInMelee))]
public class ShowMultipleAttacsArray : Editor
{ 
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        AttackInMelee attackThePlayer = target as AttackInMelee;

        EditorGUILayout.BeginVertical();


        attackThePlayer.hasMultipleAttacks = EditorGUILayout.ToggleLeft("Has Multiple Attacks ", attackThePlayer.hasMultipleAttacks);

        if (attackThePlayer.hasMultipleAttacks)
        {
            attackThePlayer.attackCount = EditorGUILayout.IntField("Number of attacks :", attackThePlayer.attackCount);
        }

        if (GUILayout.Button("Save Asset"))
        {
            EditorUtility.SetDirty(attackThePlayer);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        
        EditorGUILayout.EndVertical();
    }
}
