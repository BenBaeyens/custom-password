using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using TMPro;

public class Main : MonoBehaviour
{

    bool focussed;
    bool passwordisright = false;
    public string password;
    public TMP_InputField passwordbar;

    void Update()
    {

        if (passwordbar.text == password)
            passwordisright = true;

        if (!focussed && !passwordisright)
        {
            UnityEngine.Debug.Log("test");
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "test.bat";
            Process.Start(startInfo);
        }

    }

    private void OnApplicationFocus(bool focus) {
        focussed = focus;
    }

}
