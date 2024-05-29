using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.UI.Toggle;

public class FullscreenToggle : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] bool interactable = true;
    [SerializeField] bool m_isOn = true;
    [SerializeField] Image graphicOn;
    [SerializeField] Image graphicOff;
    [SerializeField] ToggleEvent onValueChanged = new ToggleEvent();
    bool initizalizationComplete = false;

    void Start()
    {
        initizalizationComplete = true;
    }

    public bool isOn
    {
        get { return m_isOn; }
        set 
        { 
            m_isOn = value;

            // graphicOn.gameObject.SetActive(m_isOn);
            // graphicOff.gameObject.SetActive(!m_isOn);

            graphicOn.canvasRenderer.SetAlpha(m_isOn ? 1 : 0);
            graphicOff.canvasRenderer.SetAlpha(m_isOn ? 0 : 1);

            if (initizalizationComplete)
                onValueChanged.Invoke(m_isOn);
        }
    }

    public bool Interactable
    {
        get { return interactable; }
        set { interactable = value; }
    }

    private void InternalToggle()
    {
        if (!interactable)
            return;

        isOn = !isOn;
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            InternalToggle();
        }
    }
}
