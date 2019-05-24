using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using TMPro;

public class Main : MonoBehaviour {

    bool focussed;
    bool passwordisright = false;
    bool reset = false;
    public string password;
    public TMP_InputField passwordbar;
    public GameObject dontsteal;
    public GameObject passwordiscorrect;
    public TMP_InputField newpasswordbar;
    public TextMeshProUGUI currentpassword;

    
    private void Start() {
        if (PlayerPrefs.GetString("password") != string.Empty)
        {
            currentpassword.text = PlayerPrefs.GetString("password");
            password = currentpassword.text;
        } else
        {
            currentpassword.text = password;
        }


        if (PlayerPrefs.GetInt("passwordisright") == 1)
            passwordisright = true;
        if (passwordisright)
        {
            dontsteal.SetActive(false);
            passwordiscorrect.SetActive(true);
        }
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.Space))
            OnApplicationQuit();

        if (passwordbar.text == password)
        {
            passwordisright = true;
            dontsteal.SetActive(false);
            passwordiscorrect.SetActive(true);
            PlayerPrefs.SetInt("passwordisright", 1);
        }


        if (!focussed && !passwordisright)
        {
            OnApplicationQuit();
        }

    }

    private void OnApplicationFocus(bool focus) {
        focussed = focus;
    }

    private void OnApplicationQuit() {
        if (!passwordisright && !reset) {

            passwordisright = true;
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = "CustomPassword";

        Process.Start(startInfo);
        }
    }

    public void Reset() {
        passwordisright = false;
        PlayerPrefs.SetInt("passwordisright", 0);
        passwordiscorrect.SetActive(false);
        dontsteal.SetActive(true);
        passwordbar.text = "";
        reset = true;
        Application.Quit();
    }

    

    public void newPassword() {
        password = newpasswordbar.text;
        PlayerPrefs.SetString("password", password);
        newpasswordbar.text = "";
        currentpassword.text = password;
    }
}
