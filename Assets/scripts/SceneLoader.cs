using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneLoader : MonoBehaviour
{
     public TMP_InputField inputField;
    public GameObject messagePrefab;
    public GameObject chatScreen;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene("Main");
    }

    public void goToIntroScene(string sceneName)
    {
        SceneManager.LoadScene("Intro");
    }

    public void OnSendClicked()
    {
         string messageText = inputField.text;
        if (messageText != "")
        {
            GameObject newMessage = Instantiate(messagePrefab, chatScreen.transform);
            TMP_Text messageTextComponent = newMessage.GetComponentInChildren<TMP_Text>();
            messageTextComponent.text = messageText;
            inputField.text = "";
        }
    }
}
