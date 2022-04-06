using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public InputField inputField;


    private void Start()
    {
        string myText = inputField.GetComponent<InputField>().text;
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
                Application.Quit();
        #endif
    }

    public void CurrentName()
    {
        string currName;
        currName = inputField.text;
        DataManager.Instance.Player = currName;
    }

}
