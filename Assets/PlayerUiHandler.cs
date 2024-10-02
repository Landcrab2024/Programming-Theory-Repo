using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerUiHandler : MonoBehaviour
{
    public TMP_Text playerName;

    // Start is called before the first frame update
    void Start()
    {
        SetPlayerName();
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
    }

    void MyInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            LoadMenu();
        }

        if (Input.GetKeyDown(KeyCode.Z) && !Cursor.visible)
        {
            Debug.Log("Input.GetKeyDown(KeyCode.Z) && !Cursor.visible");
            StartCoroutine(WaitForFunction());
        }
    }

    void SetPlayerName()
    {
        Debug.Log("PlayerUiHandler.SetPlayerName() = " + MainManager.Instance.playerName);
        playerName.text = "Welcome: " + MainManager.Instance.playerName;
    }

    void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator WaitForFunction()
    {
        Debug.Log("WaitForFunction()");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        yield return new WaitForSeconds(5);
    }
}
