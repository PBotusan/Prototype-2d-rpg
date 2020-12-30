using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu] // MAKE object
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
{
    /// <summary>
    /// Initial value used to change the value.
    /// </summary>
    public float initialValue;

    private float runtimeValue;
    /// <summary>
    /// make private public with get set.
    /// </summary>
    public float RuntimeValue
    {
        get { return runtimeValue; }
        set { runtimeValue = value; }   
    }
   

    public void OnAfterDeserialize()
    {
        RuntimeValue = initialValue;
    }

    public void OnBeforeSerialize()
    {
        
    }
}
