using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTrees : MonoBehaviour
{
    //public static GameObject flowerPrefab;
    public static void MakeTreeColliders(Terrain terrain)
    { 
        GameObject treeColliders = new GameObject("Tree Colliders");
        treeColliders.transform.parent = terrain.transform;
        TerrainData td = terrain.terrainData;
        TreeInstance[] tis = td.treeInstances;
        TreePrototype[] tps = td.treePrototypes;
        Vector3[] bounds = new Vector3[tps.Length];

        float[] radii = new float[tps.Length];
        //IEnumerable<World.Tree> worldTrees = Globals.instance.worldProperties.terrains.First(wt => wt.name == terrain.name).GetTrees();
        for (int i = 0; i < tps.Length; i++)
        {
            //bounds[i] = tps[i].prefab.gameObject.GetComponent<MeshFilter>().sharedMesh.bounds; //doesnt work bc the meshfilters are split among children of object
            bounds[i] = tps[i].prefab.gameObject.GetComponent<BoxCollider>().size;
            //radii[i] = worldTrees.First(wt => wt.name == tps[i].prefab.name).trunkSize;
        }
        int index = 0;
        foreach (TreeInstance ti in tis)
        {
            /*GameObject tc = new GameObject("TC" + string.Format("{0:00000}", index));
            BoxCollider cc = tc.AddComponent<BoxCollider>();
            cc.size = new Vector3(bounds[ti.prototypeIndex].x, bounds[ti.prototypeIndex].y*4f, bounds[ti.prototypeIndex].z);
            //cc.radius = radii[ti.prototypeIndex] * ti.widthScale;
            //cc.height = bounds[ti.prototypeIndex].y * ti.heightScale;
            //cc.center = Vector3.up * cc.height / 2f;
            tc.transform.parent = treeColliders.transform;
            tc.transform.position = TerrainExtras.WorldCoordinates(terrain, ti.position);
            tc.transform.position += new Vector3(0f, cc.size.y/2, 0f);
            cc.isTrigger = true;
            index++;*/

            //GameObject tc = new GameObject("TC" + string.Format("{0:00000}", index));
            GameObject nt = Instantiate(tps[ti.prototypeIndex].prefab, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
            nt.name = tps[ti.prototypeIndex].prefab.name + string.Format("{0:00000}", index);
            nt.transform.parent = treeColliders.transform;
            nt.transform.position = TerrainExtras.WorldCoordinates(terrain, ti.position);
            nt.transform.localScale *= 2f;
            nt.SetActive(true);
            //nt.transform.position += new Vector3(0f, nt.transform.localScale.y / 2, 0f);
            index++;

        }

    }
}
