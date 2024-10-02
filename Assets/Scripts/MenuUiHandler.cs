using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUiHandler : MonoBehaviour
{
    public GameObject TMP_InputField_Username;
    //public TMP_Text TMP_Text_Score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerName()
    {
        Debug.Log("SetPlayerName():" + TMP_InputField_Username.GetComponent<TMP_InputField>().text);
        MainManager.Instance.playerName = TMP_InputField_Username.GetComponent<TMP_InputField>().text;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitApplication()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }



}
