using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] VR_CanvasTable canvas;
    [SerializeField] VR_Raycast VR_Raycast;
    private VR_Box currentBox;

    public void StartSimulation(VR_Box Box)
    {
        currentBox = Box;
        canvas?.StartSimulation(currentBox.boxType);
    }

    public void StopSimulation()
    {
        currentBox = null;
        canvas.StopSimulation();
    }

    public void SetNguoiGui(string s)
    {
        Debug.Log(s);
        if (currentBox)
        {
            currentBox.SetNguoiGui(s);
        }
    }

    public void SetNguoiNhan(string s)
    {
        if (currentBox)
        {
            currentBox.SetNguoiNhan(s);
        }
    }

    public void SetDiaChi(string s)
    {
        if (currentBox)
        {
            currentBox.SetDiaChi(s);
        }
    }
}
