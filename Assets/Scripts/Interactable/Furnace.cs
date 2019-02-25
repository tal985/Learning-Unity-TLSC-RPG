using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : MonoBehaviour, IInteractable
{
    public bool isInteractable = true;

    public void Interact()
    {
        Debug.Log("Furnace.Interact()");
    }
}
