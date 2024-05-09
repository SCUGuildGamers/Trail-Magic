using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainExtras : MonoBehaviour
{
    public static Vector3 WorldCoordinates(Terrain terrain, Vector3 point)
    {
        Vector3 tdSize = terrain.terrainData.size;
        point.y = terrain.terrainData.GetHeight((int)(point.x * terrain.terrainData.heightmapResolution), (int)(point.z * terrain.terrainData.heightmapResolution));
        point.x *= tdSize.x;
        point.z *= tdSize.z;
        point += terrain.transform.position;
        return point;
    }
}
