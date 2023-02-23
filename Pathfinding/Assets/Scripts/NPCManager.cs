using System;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject infoBox;

    private void Start()
    {
        
    }

    private void OnMouseDown()
    {
        menu.SetActive(!menu.activeSelf);
    }
}
