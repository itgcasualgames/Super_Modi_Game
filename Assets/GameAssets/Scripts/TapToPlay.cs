using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TapToPlay : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Transform modipositionafterpodium;

    
    private void OnEnable()
    {
        playerMovement.isPause = true;
        if (playerMovement.isOnpodium)
        {
            this.transform.GetComponentInChildren<Text>().alignment = TextAnchor.LowerCenter;
        }
       else
        {
            this.transform.GetComponentInChildren<Text>().alignment = TextAnchor.MiddleCenter;
        }
       // SoundManager.instance.muteAll();
    }
    private void OnDisable()
    {
        playerMovement.isPause = false;
       // SoundManager.instance.unMuteAll();

    }

    private void Start()
    {
        print(this.isActiveAndEnabled);
        if(this.isActiveAndEnabled)
        {
            playerMovement.isPause = true;
        }
    }

    
    public void deActivate()
    {
        if(playerMovement.isOnpodium)
        {
            playerMovement.transform.position = modipositionafterpodium.position;
            playerMovement.isOnpodium = false;
            playerMovement.transform.GetComponent<SpriteRenderer>().enabled = true;
            playerMovement.modiFace.SetActive(false);
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    public void restat()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   
}
