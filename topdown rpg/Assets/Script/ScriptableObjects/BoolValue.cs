using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class BoolValue : ScriptableObject, ISerializationCallbackReceiver
{
    /// <summary>
    /// Initial value used to change the value.
    /// </summary>
    [SerializeField] bool initialValue;
    public bool InitialValue { get { return initialValue; } set { initialValue = value; } }

    [SerializeField] bool runtimeValue;
    public bool RuntimeValue { get { return runtimeValue; } set { runtimeValue = value; } }


    public void OnAfterDeserialize()
    {
        runtimeValue = initialValue;
    }

    public void OnBeforeSerialize()
    {

    }
}
