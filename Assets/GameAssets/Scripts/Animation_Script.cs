using UnityEngine;
using System.Collections;

namespace Bapk
{

    public class Animation_Script : MonoBehaviour
    {
        public Sprite[] sprites;
        public float durationOneFrame;
        public bool repeat;
        public bool destroyWhenFinish;

        private int frame;
        private float stateTime;
        private int currentIndex;
        public bool isFinish;

        public bool isRunning;

        public void Start()
        {
            currentIndex = 0;
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[currentIndex];
            frame = sprites.Length;
            isRunning = true;
        }

        public void Update()
        {
            if (isRunning)
            {

                UpdateAnimation();
            }
        }

        private void UpdateAnimation()
        {
            stateTime += Time.deltaTime;
            print("abc");
            if (stateTime >= durationOneFrame)
            {
                if (this.isFinish)
                {
                    print("isFinish");
                    if (this.destroyWhenFinish)
                    {
                        print("destroy");
                        Destroy(gameObject);
                        return;
                    }
                }
                currentIndex++;
                if (currentIndex == frame - 1)
                {
                    if (!repeat)
                    {
                        this.isFinish = true;
                        this.setRunning(false);
                    }
                }
                if (currentIndex == frame)
                    currentIndex = 0;
                stateTime = 0;
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[currentIndex];
            }
        }

        public void setRunning(bool isRunning)
        {
            this.isRunning = isRunning;
        }
    }
}