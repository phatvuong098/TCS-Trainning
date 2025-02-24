using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_Label : MonoBehaviour, IGroup
{
    [SerializeField] VR_Raycast hand;
    [SerializeField] private LabelElement[] elements;

    private GameObject currentLabel;

    void Start()
    {
        foreach (LabelElement e in elements)
        {
            e.Setup(this);
        }
    }

    public void StickLabel()
    {
        currentLabel = null;
    }

    public void ClearLabel()
    {
        hand.ClearLabel();
        Destroy(currentLabel);
        currentLabel = null;
    }

    public void SelectLabel(LabelElement label, bool billConfirm = false)
    {
        if (currentLabel)
        {
            Destroy(currentLabel);
            currentLabel = null;
        }

        currentLabel = InstanceLabel(label.labelType);
        hand.SetLabel(currentLabel.transform, label.labelType);
    }

    private GameObject InstanceLabel(int label)
    {
        GameObject result = Instantiate(Resources.Load("labels/" + label.ToString()) as GameObject);
        return result;
    }
}
