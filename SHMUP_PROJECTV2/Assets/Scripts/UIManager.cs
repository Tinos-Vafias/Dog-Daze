using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject deathPanel;

    private void Awake()
    {
        // Still confused asa to why the death panel appeared on startup,
        // but this fixes that 
        deathPanel.SetActive(!deathPanel.activeSelf);
    }

    public void ToggleDeathPanel()
    {
        Debug.Log("I'm being called");
        deathPanel.SetActive(!deathPanel.activeSelf);
    }
}
