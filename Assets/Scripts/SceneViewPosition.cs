#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class SceneViewPosition : MonoBehaviour
{
    void OnDrawGizmos()
    {
        if (SceneView.lastActiveSceneView != null)
        {
            // Get the position of the Scene view camera
            Vector3 sceneCameraPosition = SceneView.lastActiveSceneView.camera.transform.position;

            // Log the position to the console
            // Debug.Log("Scene Camera Position: " + sceneCameraPosition);

            // Draw the text in the Scene view
            Handles.BeginGUI();
            GUI.Label(new Rect(10, 10, 400, 20), "Scene Camera Position: " + sceneCameraPosition);
            Handles.EndGUI();
        }
    }
}
#endif