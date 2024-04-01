using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    // Start is called before the first frame update
    public static bool isMusicOn, isSoundOn;
    //public AudioSource BGMusic;
    public AudioSource GameSound;
    //public AudioClip ButtonClickSnd, ScoreSnd, GameOverSnd, spinSound,SpecialSnd;
    public AudioClip SeconOath, Pooja, missile, raffale, springJump, demonetisation, bomb, jump, coincollect,hit;

    void Awake()
    {
        MakeSingleton();
    }


    public void MakeSingleton()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        //if(!FindObjectOfType<SoundManager>())
        // DontDestroyOnLoad(this.gameObject);
        //OnBirdFly();
    }
    private void OnEnable()
    {
        checkAndsetMusicAndSnd();
    }
    private void Update()
    {

        checkAndsetMusicAndSnd();
    }

    public void OnApplicationFocus(bool focus)
    {

        if(focus)
        {
            checkAndsetMusicAndSnd();
            print("focus on");
        }
        else
        {
           // BGMusic.volume = 0f;
            GameSound.volume = 0f;
            print("focus off");
            
            
        }
    }

    public void muteAll()
    {
        print("stop initialise");

        GameSound.Stop();
      //  BGMusic.Stop();
        print("stop done");
           
    }
    public void unMuteAll()
    {
        print("play initialise");

        GameSound.Play();
      //  BGMusic.Play();
        print("play done");

    }


    public void checkAndsetMusicAndSnd()
    {
        //print("music = " + isMusicOn);
        //print("sound = " + isSoundOn);
        //print("isplaying = "+BGMusic.isPlaying);

        if (isMusicOn)
        {
         //   BGMusic.volume = 0.0f;
           // BGMusic.Stop();
        }
        if (!isMusicOn)
        {
           // BGMusic.volume = 0.1f;
            //BGMusic.Play();
        }
        if (isSoundOn)
        {
            GameSound.volume = 0.0f;
        }
        if (!isSoundOn)
        {
            GameSound.volume = 1.0f;
        }
    }
    public void MusicOn()
    {
        isMusicOn = true;
        print("music on");
    }
    public void MusicOff()
    {
        isMusicOn = false;
        print("music off");

    }
    public void SoundOn()
    {
        isSoundOn = true;
        print("sound on");

    }
    public void SoundOff()
    {
        isSoundOn = false;
        print("music off");

    }
/*
    public void OnButtonClick()
    {
        GameSound.clip = ButtonClickSnd;

        GameSound.Play();
    }
    public void OnScoreGet()
    {
        GameSound.clip = ScoreSnd;

        GameSound.Play();
        print("score snd play");
    }
    public void OnSpin()
    {
        GameSound.clip = spinSound;

        GameSound.Play();
        print("fly snd play");

    }
    public void OnSoundStop()
    {
        GameSound.clip = null;
        GameSound.Play();
    }
    public void OnGameOver()
    {
        GameSound.clip = GameOverSnd;

        GameSound.Play();
        print("over snd play");

    }
    public void OnSpecialSnd()
    {
        GameSound.clip = SpecialSnd;

        GameSound.Play();
        print("spcl snd play");

    }
*/

    //for Modi run

    public void secondOath()
    {
        GameSound.clip = SeconOath;

        GameSound.Play();
        print("oath snd play");
    }
    public void mandirpooja()
    {
        GameSound.clip = Pooja;

        GameSound.Play();
        print("pooja snd play");
    }
    public void missilethrow()
    {
        GameSound.clip = missile;

        GameSound.Play();
        print("missile snd play");
    }
    public void raffalemove()
    {
        GameSound.clip = raffale;

        GameSound.Play();
        print("raffale snd play");
    }
    public void spring()
    {
        GameSound.clip = springJump;

        GameSound.Play();
        print("spring snd play");
    }
    public void demonetisationsnd()
    {
        GameSound.clip = demonetisation;

        GameSound.Play();
        print("note snd play");
    }
    public void bombblast()
    {
        GameSound.clip = bomb;

        GameSound.Play();
        print("bomb snd play");
    }

    public void jumping()
    {
        GameSound.clip = jump;

        GameSound.Play();
        print("jump snd play");
    }
    public void coin()
    {
        GameSound.clip = coincollect;

        GameSound.Play();
        print("coincollect snd play");
    }

    public void hitsnd()
    {
        GameSound.clip = hit;

        GameSound.Play();
        print("coincollect snd play");
    }

}
