// Ce script gère les événements de clic sur le bouton et exécute les actions correspondantes lorsque le bouton est enfoncé et relâché.

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

// Ce script nécessite un composant de bouton pour fonctionner correctement
[RequireComponent(typeof(Button))]
public class ClickHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Button button;
    // UnityEvents qui seront déclenchés lorsque le bouton est enfoncé et relâché
    public UnityEvent onButtonDown;
    public UnityEvent onButtonUp;

    void Start()
    {
        // Get reference to the button component
        button = GetComponent<Button>();
    }

    // Cette méthode est appelée lorsque le bouton est enfoncé
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Button Down");
        // Déclenche l'UnityEvent onButtonDown
        onButtonDown.Invoke();
    }

    // Cette méthode est appelée lorsque le bouton est relâché
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Button Up");
        // Déclenche l'UnityEvent onButtonUp
        onButtonUp.Invoke();
    }
}
