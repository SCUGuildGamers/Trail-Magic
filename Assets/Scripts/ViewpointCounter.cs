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
    [SerializeField] private float counterShowTime = 5f;
    
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

        viewpointCounterText.alpha = 0f; // Hide the counter at the start
        CountVisitedViewpoints();
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

        viewpointCounterText.text = visitedViewpoints + "/" + totalViewpoints;
    }

    public void VisitViewpoint(string viewpointName)
    {
        if (viewpointStatus.ContainsKey(viewpointName))
        {
            viewpointStatus[viewpointName] = true;
            CountVisitedViewpoints();

            StartCoroutine(ShowViewpointCounter()); // Show the counter for a few seconds
        }
        else
        {
            Debug.LogError("Viewpoint " + viewpointName + " not found in dictionary");
        }
    }

    private IEnumerator ShowViewpointCounter()
    {
        viewpointCounterText.alpha = 1f; // Show the counter
        yield return new WaitForSeconds(counterShowTime);
        viewpointCounterText.alpha = 0f; // Hide the counter
    }
}
