using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(NeighborhoodBuilder))]
[ExecuteInEditMode]
public class NeighborhoodBuilderEditor : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        NeighborhoodBuilder neighborhoodBuild = (NeighborhoodBuilder)target;

        GUILayout.BeginHorizontal();

        if(GUILayout.Button("Build"))
        {
            neighborhoodBuild.Build();
        }

        if (GUILayout.Button("Assign"))
        {
            neighborhoodBuild.AssignIncomeClass();
        }

        if (GUILayout.Button("Reset"))
        {
            neighborhoodBuild.ResetIncomeClass();
        }

        GUILayout.EndHorizontal();
    }
}
