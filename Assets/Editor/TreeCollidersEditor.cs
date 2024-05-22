using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TreeCollidersEditor : MonoBehaviour
{
    [MenuItem("GameObject/Make Tree Colliders")]
    static void MakeTreeCollidersMenuItem()
    {
        foreach (Transform selection in Selection.transforms)
        {

            Terrain terrain = selection.GetComponent<Terrain>();
            if (terrain)
                GenerateTrees.MakeTreeColliders(terrain);

        }
    }

    [MenuItem("GameObject/Make Tree Colliders", true)]
    static bool ValidateMakeTreeCollidersMenuItem()
    {
        if (Selection.activeTransform)
        {
            foreach (Transform selection in Selection.transforms)
            {
                Terrain terrain = selection.GetComponent<Terrain>();
                if (terrain)
                    return true;
            }
            return false;
        }
        else
            return false;
    }
}
