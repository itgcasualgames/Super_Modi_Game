using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Runtime.InteropServices;

public class test : MonoBehaviour
{
   

    public PlayerMovement playerMovement;

    public void ShareExperience()
    {
       // Share();
    }

    public GameObject SharePanelForWeb;
    public GameObject rotateScreen;



    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        
      
           // platFormText.text = "Web";
            rotateScreen.SetActive(false);
            playerMovement.TapToPlayPanel.SetActive(true);
            //fullScreenBtn.SetActive(false);
        
    }

    //Whether your webgl is being playing on mobile devices or not.
    

    //Activate Fullscreen.
   

    //Check current orientation.    public bool isLandScape()
   

    //When your fullscreen button is clicked(touched).
    public void OnPointerClick()
    {
        //If you're using mobile devices.
       
    }

    void Update()
    {
        //Keep on checking the orientation.
     
            // platFormText.text = "Web";
            rotateScreen.SetActive(false);
            if(playerMovement.isPause)
            playerMovement.TapToPlayPanel.SetActive(true);
            //fullScreenBtn.SetActive(false);
        
    }

    public void OnClickShareButton()
    {
        
         if(!SharePanelForWeb.activeInHierarchy)
        {
            SharePanelForWeb.SetActive(true);
            playerMovement.isShareMode = true;
        }
        else if (SharePanelForWeb.activeInHierarchy)
        {
            playerMovement.isShareMode = false;
            SharePanelForWeb.SetActive(false);
        }
    }
   public void OnClickWebShare(Button b)
    {
        switch(b.name)

        {
            case "FB":
                Application.OpenURL("https://www.facebook.com/sharer.php?u=https://www.indiatoday.in/interactive/immersive/up-election-2022-the-game/");
                break;
            case "Twitter":
                Application.OpenURL("https://twitter.com/share?url=https://www.indiatoday.in/interactive/immersive/up-election-2022-the-game/");
                break;
            case "Whatsapp":
                Application.OpenURL("https://web.whatsapp.com/send?text=Experience The Modi Run Game - https://www.indiatoday.in/interactive/immersive/up-election-2022-the-game/");
                break;
        }    }
    
}