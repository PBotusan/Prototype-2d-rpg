using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VectorValueOfPlayer : ScriptableObject, ISerializationCallbackReceiver
{
    /// <summary>
    /// Initialvalue of the playerposition, used to store the value before entering buildings.
    /// Stores the old position.
    /// </summary>
    public Vector2 initialValue;

    public Vector2 defaultValue;

    public void OnAfterDeserialize()
    {
        initialValue = defaultValue;
    }

    public void OnBeforeSerialize()
    {
       
    }
}
