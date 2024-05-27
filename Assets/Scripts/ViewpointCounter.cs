using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ViewpointCounter : MonoBehaviour
{
    [SerializeField] private List<GameObject> viewpoints;
    private Dictionary<string, bool> viewpointStatus;
    int visitedViewpoints;
    int totalViewpoints;
    [SerializeField] private TextMeshProUGUI viewpointCounterText;
    
    // Start is called before the first frame update
    void Start()
    {
        viewpointStatus = new Dictionary<string, bool>();
        visitedViewpoints = 0;
        foreach(GameObject viewpoint in viewpoints)
        {
            viewpointStatus.Add(viewpoint.name, false);
        }

        totalViewpoints = viewpoints.Count;

        CountVisitedViewpoints();
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

    void CountVisitedViewpoints()
    {
        visitedViewpoints = 0;
        foreach(KeyValuePair<string, bool> viewpoint in viewpointStatus)
        {
            if(viewpoint.Value)
            {
                visitedViewpoints++;
            }
        }

        viewpointCounterText.text = "Viewpoints: " + visitedViewpoints + "/" + totalViewpoints;
    }

    void VisitViewpoint(string viewpointName)
    {
        if (viewpointStatus.ContainsKey(viewpointName))
        {
            viewpointStatus[viewpointName] = true;
            CountVisitedViewpoints();
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
            GameObject particle = other.gameObject.transform.parent.gameObject;
            GameObject viewpoint = particle.transform.parent.gameObject;
            VisitViewpoint(viewpoint.name);
        }
    }
}
