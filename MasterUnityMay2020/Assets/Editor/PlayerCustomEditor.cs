using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(PlayerBrain))]
public class PlayerCustomEditor : Editor
{
    private PlayerBrain brain;
    private SerializedObject _object;
    private SerializedProperty settings;

    private void OnEnable()
    {
        brain = (PlayerBrain)target;
        _object = new SerializedObject(target);
        settings = _object.FindProperty("settings");
    }

    public override void OnInspectorGUI()
    {
        _object.Update();
        DrawSettingsObject();
        _object.ApplyModifiedProperties();

    }

    private void OnSceneGUI()
    {
        DrawHandles();
    }

    private void DrawHandles()
    {
        Handles.color = Color.green;
        Handles.DrawWireDisc(brain.transform.position, Vector3.up, brain.Settings.AttackRange);
    }

    private void DrawSettingsObject()
    {
        EditorGUILayout.ObjectField(settings);
    }


}
