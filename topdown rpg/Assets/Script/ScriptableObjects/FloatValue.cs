using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu] // MAKE object
[System.Serializable]
public class FloatValue : ScriptableObject
{
    /// <summary>
    /// Initial value used to change the value.
    /// </summary>
    [SerializeField] float initialValue;
    public float InitialValue{ get { return initialValue; } set { initialValue = value; } }

    [SerializeField] float runtimeValue;
    public float RuntimeValue {get { return runtimeValue; } set { runtimeValue = value; } }

}
