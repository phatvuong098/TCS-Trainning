using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum BOX_TYPE
{
    CARDTON,
    CIRCLE
}
public class VR_Box : MonoBehaviour
{
    [SerializeField] TMP_Text txtNguoiGui;
    [SerializeField] TMP_Text txtNguoiNhan;
    [SerializeField] TMP_Text txtDiaChi;
    [SerializeField] Outline outline;

    public BOX_TYPE boxType;

    public void Forcus()
    {
        outline.enabled = true;
    }

    public void StopForcus()
    {
        outline.enabled = false;
    }


    public void SetNguoiGui(string s)
    {
        txtNguoiGui.text = s;
    }

    public void SetNguoiNhan(string s)
    {
        txtNguoiNhan.text = s;
    }

    public void SetDiaChi(string s)
    {
        txtDiaChi.text = s;
    }
}
