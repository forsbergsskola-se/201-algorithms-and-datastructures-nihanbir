using System.Collections;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject infoBox;
    public GameObject youWinScreen;
    public GameObject gemInfo;
    public static bool GameIsActive;
    public static bool buttonActive;
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

    public IEnumerator YouWin()
    {
        yield return new WaitForSeconds(.5f);
        gemInfo.SetActive(false);
        GameIsActive = false;
        youWinScreen.SetActive(true);
    }
    
}
