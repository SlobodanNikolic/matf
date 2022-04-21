using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    public Popup popup;

    public void ShowPopup()
    {
        popup.gameObject.SetActive(true);
    }
}
