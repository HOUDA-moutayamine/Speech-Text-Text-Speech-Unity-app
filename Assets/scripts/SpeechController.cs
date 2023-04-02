// Ce script gère la reconnaissance vocale et la synthèse vocale à l'aide des plugins TextSpeech pour Unity.

using System.Collections;
using System.Collections.Generic;
using TextSpeech;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;
using TMPro;

public class SpeechController : MonoBehaviour
{
    // Code de langue pour la reconnaissance et la synthèse vocale
    const string LANG_CODE= "en-US";

    [SerializeField]
    TextMeshProUGUI uiText;
    public TextMeshProUGUI tts;

    void Start() {
        // Configuration des événements de reconnaissance vocale et de synthèse vocale
        Setup(LANG_CODE);
        SpeechToText.Instance.onPartialResultsCallback= OnPartialSpeechResult;
        SpeechToText.Instance.onResultCallback = OnFinalSpeechResult;
        TextToSpeech.Instance.onStartCallBack= OnSpeakStart;
        TextToSpeech.Instance.onDoneCallback= OnSpeakStop;

        // Vérification de l'autorisation de l'utilisateur pour accéder au microphone
        CheckPermission();
    }

    void CheckPermission(){
        // Demande d'autorisation d'accéder au microphone si elle n'est pas déjà accordée
        if( !Permission.HasUserAuthorizedPermission(Permission.Microphone)){
            Permission.RequestUserPermission(Permission.Microphone);
        }
    }

    #region Text to Speech
    // Méthode pour commencer la synthèse vocale
    public void StartSpeaking(){
        TextToSpeech.Instance.StartSpeak(tts.text);
    }
    // Méthode pour arrêter la synthèse vocale
    public void StopSpeaking(){
        TextToSpeech.Instance.StopSpeak();
    }
    // Callback déclenché lorsque la synthèse vocale démarre
    void OnSpeakStart(){
        Debug.Log("Talking started...");
    }
    // Callback déclenché lorsque la synthèse vocale s'arrête
    void OnSpeakStop(){
        Debug.Log("Talking stopped!");
    }

    #endregion


    #region Speech to Text

    // Méthode pour commencer la reconnaissance vocale
    public void StartListening(){
        SpeechToText.Instance.StartRecording();
    }
    // Méthode pour arrêter la reconnaissance vocale
    public void StopListening(){
        SpeechToText.Instance.StopRecording();
    }

    // Callback déclenché lorsque la reconnaissance vocale a un résultat final
    public void OnFinalSpeechResult(string result){
        uiText.text= result;
    }

    // Callback déclenché lorsque la reconnaissance vocale a un résultat partiel
    public void OnPartialSpeechResult(string result){
        uiText.text= result;
    }

    #endregion

    void Setup(string code){
        // Configuration des plugins de synthèse et de reconnaissance vocale avec le code de langue
        TextToSpeech.Instance.Setting(code, 1,1);
        SpeechToText.Instance.Setting(code);
    }
}
