using System.Collections;
using System.Collections.Generic;
using Bapk;
using UnityEngine;
using UnityEngine.UI;


public class PlayerCollisionDetection : MonoBehaviour
{

    public PlayerMovement playerMovement;
    public GameObject[] missiles,bombs,notes,flowerLeft,flowerRight,vaccine,flowers,covid_virus;
    public GameObject rainbow, detonator, unemployment,shikara,FarmBill,newPariliament,leftFlowerLast, rightFlowerLast,thali;
    public GameObject goldLayer,LastScreen;
    public Sprite modi_in_shikara;
    public Vector3 scale;
    public Transform modiExitPositionBeforeCAA, modiExitPositionAfterCAA, Shikara_Entry_Position, modiExitPositionAfterTractor;
    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        scale = transform.localScale;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {

        playerMovement.canJump = true;
        print(collision.gameObject.name);
        switch (collision.gameObject.name)
        {
            

            case "LaunchPad":
                playerMovement.moveSpeed = 6f;
                playerMovement.jumpSpeed = 10f;
                playerMovement.jump();
                SoundManager.instance.spring();
                break;
            case "hurdle":
                //  collision.gameObject.SetActive(false);
                SoundManager.instance.hitsnd();

                if (transform.localScale.x > 0.1f)
                {
                    transform.localScale = new Vector3(transform.localScale.x - 0.005f, transform.localScale.y - 0.005f, transform.localScale.z - 0.005f);
                    scale = transform.localScale;
                }
                break;
            case "Enemy Plane":
                //  collision.gameObject.SetActive(false);
                SoundManager.instance.hitsnd();

                collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;

                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                if (transform.localScale.x > 0.1f)
                {
                    transform.localScale = new Vector3(transform.localScale.x - 0.005f, transform.localScale.y - 0.005f, transform.localScale.z - 0.005f);
                    scale = transform.localScale;
                }
                break;
            case "Bomb":
                //  collision.gameObject.SetActive(false);
                //SoundManager.instance.hitsnd();

                if (transform.localScale.x > 0.1f)
                {
                    transform.localScale = new Vector3(transform.localScale.x - 0.005f, transform.localScale.y - 0.005f, transform.localScale.z - 0.005f);
                    scale = transform.localScale;
                }

                break;
        }

        }
    public void OnCollisionExit2D(Collision2D collision)
    {

        playerMovement.canJump = false;
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.name);
        goldLayer = collision.transform.parent.gameObject;
        switch (collision.gameObject.name)
        {
            case "Shapath Patra":
                collision.gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                break;
            case "Tiger":
                collision.GetComponent<Animator>().enabled = true;
                break;
            case "MOB":
                playerMovement.canFly = true;
                transform.GetChild(0).gameObject.SetActive(true);
                collision.gameObject.SetActive(false);
                transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                break;
            case "MOB Out":
                playerMovement.canFly = false;
                transform.GetChild(0).gameObject.SetActive(false);
                transform.localScale = scale;

                break;
            case "Detonator":
                //collision.gameObject.SetActive(false);
                detonator.GetComponent<Animator>().enabled = true;
                SoundManager.instance.missilethrow();
                StartCoroutine(ActivateMissile());
                break;
            case "PODIUM":
                playerMovement.isOnpodium = true;
                transform.GetComponent<SpriteRenderer>().enabled = false;
                SoundManager.instance.secondOath();
                playerMovement.modiFace.SetActive(true);
                StartCoroutine(ActivateTapToPlayPanel());

                break;
            case "vote":
                addDurtGold(collision.gameObject.transform.position);
                SoundManager.instance.coin();
                collision.gameObject.SetActive(false);
                break;
            case "Exit Jump":
                playerMovement.moveSpeed = 3.25f;
                playerMovement.jumpSpeed = 6f;
                break;
               
            case "Enemy Plane":
                collision.gameObject.GetComponent<Animator>().enabled = false;
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;
                collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
                transform.localScale = new Vector3(transform.localScale.x - 0.005f, transform.localScale.y - 0.005f, transform.localScale.z - 0.005f);

                break;
                
            case "Pulwama Explosion":
                StartCoroutine(ExploseBombs());
                break;

            case "LaunchPad":
                collision.gameObject.GetComponent<Animator>().enabled = true;
                break;
            case "coin":
                addDurtGold(collision.gameObject.transform.position);
                collision.gameObject.SetActive(false);
                SoundManager.instance.coin();
                if(transform.localScale.x < 0.2f)
                {
                    transform.localScale = new Vector3(transform.localScale.x + 0.005f, transform.localScale.y + 0.005f, transform.localScale.z + 0.005f);
                    scale = transform.localScale;
                }
                break;
            case "Demonitisation_Powerup":
                collision.gameObject.SetActive(false);
                StartCoroutine(NoteChange());
                break;
            case "Section 377 Entry":
                collision.gameObject.SetActive(false);
                rainbow.GetComponent<Animator>().enabled = true;
                break;
            case "Unemployment_Entry":
                collision.gameObject.SetActive(false);
                unemployment.GetComponent<Animation_Script>().enabled = true;
                break;

            case "Unemployment_Exit":
                collision.gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(true);
                playerMovement.isOnShikara = true;
                transform.GetComponent<SpriteRenderer>().enabled = false;
                transform.position = Shikara_Entry_Position.position;
                shikara.SetActive(false);

                break;
            case "shooter":
                collision.GetComponent<Collider2D>().enabled = false;
                collision.GetComponent<Animator>().enabled = true;

                break;
            case "Shikara_Exit":
                playerMovement.isOnShikara = false;
                transform.GetChild(1).gameObject.SetActive(false);
                transform.position = modiExitPositionBeforeCAA.position;
                transform.GetComponent<SpriteRenderer>().enabled = true;
                break;
            case "Pipe Entry":
                playerMovement.isUnderPipe = true;
                collision.GetComponent<Collider2D>().enabled = false;
                StartCoroutine(GoDownInPipe());
                break;
            case "Pipe Exit":
                playerMovement.isUnderPipe = false;

                transform.position = modiExitPositionAfterCAA.position;
                transform.GetComponent<SpriteRenderer>().enabled = true;

                break;
            case "Pipe Exit Tractor":
                playerMovement.isUnderPipe = false;

                transform.position = modiExitPositionAfterTractor.position;
                transform.GetComponent<SpriteRenderer>().enabled = true;

                break;


            case "Mask_Power":
                collision.gameObject.SetActive(false);
                playerMovement.isWithMask = true;
                foreach (GameObject g in covid_virus)
                    g.GetComponent<Animation_Script>().enabled = true;

                break;
            case "Covid_Exit":
                playerMovement.isWithMask = false;
                break;
            case "Innaugration_Power":
                collision.gameObject.SetActive(false);
                playerMovement.isWithBrick = true;
                break;
            case "Innaugration_Exit":
                playerMovement.isWithBrick = false;
                FarmBill.GetComponent<Animation_Script>().enabled = true;
                break;
            case "Parliament_Inaugration_Power":
                collision.gameObject.SetActive(false);
                newPariliament.SetActive(true);
                break;
            case "Vaccine_Power":
                collision.gameObject.SetActive(false);
                StartCoroutine(Activatevaccine());
                break;
            case "Raffale_Entry":
                collision.gameObject.SetActive(false);
                SoundManager.instance.raffalemove();
                break;
            case "Mandir_Inaugration_Power":
                collision.gameObject.SetActive(false);
                SoundManager.instance.mandirpooja();
                StartCoroutine(FlowerAppear());
                break;
            case "Mandir_Pooja_Enter":
                collision.gameObject.SetActive(false);
                StartCoroutine(FlowerFall());
                thali.SetActive(true);
                leftFlowerLast.SetActive(true);
                rightFlowerLast.SetActive(true);
                break;
            case "Mandir_Pooja_Exit":
                collision.gameObject.SetActive(false);
                playerMovement.canFly = false;
                playerMovement.canJump = false;
                playerMovement.isPause = true;
                this.gameObject.SetActive(false);
                LastScreen.SetActive(true);
                break;
        }

        switch (collision.gameObject.tag)
        {
            case "power":
                collision.gameObject.SetActive(false);
                if (transform.localScale.x > 0.1f)
                {
                    transform.localScale = new Vector3(transform.localScale.x + 0.005f, transform.localScale.y + 0.005f, transform.localScale.z + 0.005f);
                    scale = transform.localScale;
                }
                break;
        }
        }

public IEnumerator ExploseBombs()
    {
        bombs[0].GetComponent<Animator>().enabled = true;
        SoundManager.instance.bombblast();
        yield return new WaitForSeconds(1.5f);
        bombs[1].GetComponent<Animator>().enabled = true;
        SoundManager.instance.bombblast();


    }

public IEnumerator NoteChange()
    {
        foreach (GameObject g in notes)
        {
            g.GetComponent<SpriteRenderer>().sprite = g.GetComponent<ChangeSprite>().newNote;
            SoundManager.instance.demonetisationsnd();

            yield return new WaitForSeconds(0.1f);
        }
    }

public IEnumerator ActivateMissile()
    {
        foreach (GameObject g in missiles)
            g.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        
    }
    public IEnumerator Activatevaccine()
    {
        foreach (GameObject g in vaccine)
            g.SetActive(true);
        yield return new WaitForSeconds(0.1f);

    }

    public IEnumerator ActivateTapToPlayPanel()
    {
        
        yield return new WaitForSeconds(2.0f);
        playerMovement.TapToPlayPanel.SetActive(true);

    }

    public IEnumerator FlowerFall()
    {
        foreach (GameObject g in flowers)
            g.SetActive(true);
        yield return new WaitForSeconds(0.1f);

    }
    public IEnumerator GoDownInPipe()
    {
        
        yield return new WaitForSeconds(0.1f);
        transform.GetComponent<SpriteRenderer>().enabled = false;

    }
   
    public void addDurtGold(Vector3 coinPosition)
    {
        GameObject durtGold = (GameObject)Instantiate(Resources.Load<GameObject>("Gold"));
        durtGold.transform.position = coinPosition;
        durtGold.transform.parent = goldLayer.transform;
    }
    public IEnumerator FlowerAppear()
    {
        yield return new WaitForSeconds(0.2f);
        for (int flowerIndex = 0;flowerIndex<=flowerLeft.Length-1;flowerIndex++)
        {
            flowerLeft[flowerIndex].SetActive(true);
            flowerRight[flowerIndex].SetActive(true);
            yield return new WaitForSeconds(0.1f);

        }

    }
}
