using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu] // MAKE object
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
{
    public float initialValue;

    private float runtimeValue;
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
