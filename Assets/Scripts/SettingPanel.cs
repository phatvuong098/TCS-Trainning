using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.MUIP;

public class SettingPanel : MonoBehaviour
{
    [SerializeField] KeyCode settingKey;
    [SerializeField] GameObject settingPanel;
    [SerializeField] MouseLook mouseLook;
    [SerializeField] CharacterMovementWithHeadBobbing character;
    [SerializeField] SliderManager sliderMouse;
    [SerializeField] SliderManager sliderWalk;

    CursorLockMode currentLockMode;
    bool isVisibel;
    bool isMouseLookActive;

    void Update()
    {
        if (Input.GetKeyDown(settingKey))
        {


            settingPanel.SetActive(!settingPanel.activeInHierarchy);

            if (settingPanel.activeInHierarchy)
            {
                isMouseLookActive = mouseLook.active;
                currentLockMode = Cursor.lockState;
                isVisibel = Cursor.visible;
                mouseLook.active = false;

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                mouseLook.active = isMouseLookActive;
                Cursor.lockState = currentLockMode;
                Cursor.visible = isVisibel;
                mouseLook.active = true;
            }
        }
    }

    public void SL_SenSi(float value)
    {
        mouseLook.mouseSensitivity = value;
    }

    public void SL_WalkSpeed(float value)
    {
        character.moveSpeed = value;
    }
}
