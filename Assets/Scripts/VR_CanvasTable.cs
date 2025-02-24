using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_CanvasTable : MonoBehaviour
{
    [SerializeField] GameObject note;
    [SerializeField] GameObject normal;

    private void Start()
    {
        StopSimulation();
    }

    public void StartSimulation(BOX_TYPE type)
    {
        note.SetActive(type == BOX_TYPE.CARDTON);
        normal.SetActive(true);
    }
    public void StopSimulation()
    {
        note.SetActive(false);
        normal.SetActive(false);
    }
}
