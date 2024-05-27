using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewpointUI : MonoBehaviour
{
    [SerializeField] private Text viewpointCounterText;
    [SerializeField] private ViewpointCounter viewpointCounter;

    // Update is called once per frame
    void Update()
    {
        viewpointCounterText.text = viewpointCounter.VisitedViewpoints + "/" + viewpointCounter.TotalViewpoints;
    }
}
