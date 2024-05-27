using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewpointCounter : MonoBehaviour
{
    [SerializeField] private List<Viewpoint> viewpoints;
    private Dictionary<string, bool> viewpointStatus;
    int visitedViewpoints;
    int totalViewpoints;
    
    // Start is called before the first frame update
    void Start()
    {
        viewpointStatus = new Dictionary<string, bool>();
        visitedViewpoints = 0;
        foreach(Viewpoint viewpoint in viewpoints)
        {
            viewpointStatus.Add(viewpoint.viewpointName, false);
        }

        totalViewpoints = viewpoints.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int VisitedViewpoints
    {
        get { return visitedViewpoints; }
    }

    public int TotalViewpoints
    {
        get { return totalViewpoints; }
    }

    void VisitViewpoint(string viewpointName)
    {
        if (viewpointStatus.ContainsKey(viewpointName))
        {
            viewpointStatus[viewpointName] = true;
        }
        else
        {
            Debug.LogError("Viewpoint " + viewpointName + " not found in dictionary");
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("PolaroidArea"))
        {
            VisitViewpoint(other.gameObject.transform.parent.gameObject.transform.parent.gameObject.name);
        }
    }
}
