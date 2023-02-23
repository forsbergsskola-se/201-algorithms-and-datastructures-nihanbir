using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject infoBox;
    public static bool GameIsActive;

    private void Start()
    {
        infoBox.SetActive(true);
        GameIsActive = false;
    }
    
    private void OnMouseDown()
    {
        menu.SetActive(!menu.activeSelf);
    }

    public void HideInfoBox()
    {
        infoBox.SetActive(false);
        GameIsActive = true;
    }
}
