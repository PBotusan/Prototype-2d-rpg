using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
[System.Serializable]
public class BoolValue : ScriptableObject
{
    /// <summary>
    /// Initial value used to change the value.
    /// </summary>
    [SerializeField] bool initialValue;
    public bool InitialValue { get { return initialValue; } set { initialValue = value; } }

    [SerializeField] bool runtimeValue;
    public bool RuntimeValue { get { return runtimeValue; } set { runtimeValue = value; } }

}
