using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TransitionData", order = 1)]

public class TransitionData : ScriptableObject
{
    public Gradient sunColor;
    public Gradient skyTopColor;
    public Gradient skyBottomColor;
    public Gradient skyExponent;
}
