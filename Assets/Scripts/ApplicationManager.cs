using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationManager : MonoBehaviour
{
    public GameObject blackScreenPanel;
    public GameObject errorText;
    public GameObject Images;
    
    public float inputTimeoutDuration = 5f;
    public float warningDuration = 3f;
    public float elapsedTime = 0f;
    
    private bool isBlackScreenActive = false;
    private bool wrongChoiseActive = false;
    
    void Update()
    {
        if (isBlackScreenActive == false)
        {
            CheckInput();
        }
        
        if (isBlackScreenActive == true)
        {
            if (Input.anyKeyDown)
            {
                Images.SetActive(true);
                Invoke("ImagesGOff", 3f);
            }
        }

        if (wrongChoiseActive == true)
        {
            Images.SetActive(false);
        }
    }
    void ImagesGOff()
    {
        Images.SetActive(false);
    }
    void CheckInput()
    {
        if (Input.anyKeyDown)
        {
            elapsedTime = 0f;
        }
        
        else
        {
            elapsedTime += Time.deltaTime;
            
            if (elapsedTime >= inputTimeoutDuration)
            {
                ShowImageObjects();
            }
        }
    }
    void ShowImageObjects()
    {
        blackScreenPanel.SetActive(true);
        isBlackScreenActive = true;
    }

    public void correctClick()
    {
        blackScreenPanel.SetActive(false);
        isBlackScreenActive = false;
        elapsedTime = 0f;
    }

    public void wrongClick()
    {
        ShowWarning();
        wrongChoiseActive = true;
    }
    void ShowWarning()
    {
        errorText.SetActive(true);

        Invoke("QuitApplication", warningDuration);
    }

    void QuitApplication()
    {
        Application.Quit();
        Debug.Log("uygulama kapandi");
    }

}
