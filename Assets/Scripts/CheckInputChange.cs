using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CheckInputChange : MonoBehaviour
{
    public UnityEvent<string> onValueChange;
    private InputField input;
    private string currentText;

    void Awake()
    {
        input = GetComponent<InputField>();
    }

    private void OnEnable()
    {
        currentText = currentText = input.text;
        StartCoroutine(Coro_loop());
    }

    IEnumerator Coro_loop()
    {
        WaitForSeconds wait = new WaitForSeconds(.05f);
        while (true)
        {
            yield return wait;

            if(currentText != input.text)
            {
                currentText = input.text;
                onValueChange?.Invoke(currentText);
            }
        }
    }
}
