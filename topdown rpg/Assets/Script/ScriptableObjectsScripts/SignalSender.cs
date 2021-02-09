using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SignalSender : ScriptableObject
{
    /// <summary>
    /// Creates list of listeners.
    /// </summary>
    public List<SignalListener> listeners = new List<SignalListener>();

    /// <summary>
    /// Raises listener
    /// </summary>
    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnSignalRaised();
        }
    }

    /// <summary>
    /// registers the listener and adds it to the list.
    /// </summary>
    /// <param name="listener"></param>
    public void RegisterListener(SignalListener listener)
    {
        listeners.Add(listener);
    }

    /// <summary>
    /// remove listener from list.
    /// </summary>
    /// <param name="listener"></param>
    public void DeRegisterListener(SignalListener listener)
    {
        listeners.Remove(listener);
    }
}
