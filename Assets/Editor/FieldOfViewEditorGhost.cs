using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FieldOfView))]


public class FieldOfViewEditorGhost : Editor
{
#if UNITY_EDITOR
    private void OnSceneGUI()
    {
        FieldOfView fov = (FieldOfView)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.sightLocation.transform.position, Vector3.forward, Vector3.up, 360, fov.Radius);

        Vector3 viewAngle01 = DirectionFromAngle(fov.transform.eulerAngles.y, -fov.Angle / 2);
        Vector3 viewAngle02 = DirectionFromAngle(fov.transform.eulerAngles.y, fov.Angle / 2);

        Handles.color = Color.yellow;

        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle01 * fov.Radius);
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngle02 * fov.Radius);

        if (fov.CanSeePlayer)
        { 
            Handles.color+= Color.green;
            Handles.DrawLine(fov.sightLocation.transform.position, fov.PlayerRef.transform.position);

        }

    }


    private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
#endif
}
