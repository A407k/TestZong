using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIController : MonoBehaviour
{
    public Canvas mainUI;
    public Transform cam;

    public GameObject weaponsPanel;
    public GameObject pointsPanel;
    public GameObject instrumentsPanel;

    private bool isGameActive;
    private bool isCursorVisible;


    private void Start()
    {
        isGameActive = true;
        mainUI.enabled = false;
        isCursorVisible = false;

        

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseResume();
            ShowCursor();

            ChnageDppu();

        }
    }

    public void ShowCursor()
    {
        // Toggle cursor visibility
        isCursorVisible = !isCursorVisible;

        // Set cursor visibility based on the toggle state
        Cursor.visible = isCursorVisible;

        // Lock or unlock cursor based on visibility state
        Cursor.lockState = isCursorVisible ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void ChnageDppu()
    {
        CanvasScaler canvasScaler = mainUI.GetComponent<CanvasScaler>();

        canvasScaler.dynamicPixelsPerUnit = 142;
    }

    private void LateUpdate()
    {
        mainUI.transform.LookAt(mainUI.transform.position + cam.forward);
    }

    public void pauseResume()
    {
        
            if(isGameActive) 
            {
               // Time.timeScale = 0;
                isGameActive = false;
                mainUI.enabled = true;
            }
            else if (!isGameActive)
            {
              //  Time.timeScale = 1;
                isGameActive = true;
                mainUI.enabled= false;
                DisableSubCategory();
            }
       
        
    }

    public void DisableSubCategory()
    {
        weaponsPanel.SetActive(false);
        pointsPanel.SetActive(false);
        instrumentsPanel.SetActive(false);

    }

    public void ShowWeaponsSubCategories()
    {
        weaponsPanel.SetActive(true);
        pointsPanel.SetActive(false);
        instrumentsPanel.SetActive(false);
    }

    public void ShowPointsPanel()
    {
        weaponsPanel.SetActive(false);
        pointsPanel.SetActive(true);
        instrumentsPanel.SetActive(false);
    }

    public void ShowInstrumentsPanel()
    {
        weaponsPanel.SetActive(false);
        pointsPanel.SetActive(false);
        instrumentsPanel.SetActive(true);
    }

}
