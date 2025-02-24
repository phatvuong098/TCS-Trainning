using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] VR_Box currentBox;
    [SerializeField] Controller controller;

    private void OnTriggerEnter(Collider other)
    {
        if(currentBox == null)
        {
            currentBox = other.GetComponentInParent<VR_Box>();
            if(currentBox != null )
            {
                currentBox.Forcus();
                controller.StartSimulation(currentBox);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        VR_Box box = other.GetComponentInParent<VR_Box>();
        if (currentBox == box && box != null)
        {
            currentBox.StopForcus();
            controller.StopSimulation();
            currentBox = null;
        }
    }
}
