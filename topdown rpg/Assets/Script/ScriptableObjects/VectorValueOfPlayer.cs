using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VectorValueOfPlayer : ScriptableObject
{
    /// <summary>
    /// Initialvalue of the playerposition, used to store the value before entering buildings.
    /// Stores the old position.
    /// </summary>
    public Vector2 initialValue;
}
