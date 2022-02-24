using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeepScript : MonoBehaviour
{
    public AudioClip beep;
    public AudioSource continuousBeep;
    public int gameDurationInBeeps = 60;
    float initialBeepUntilNextBeep = 1.768f;
    float timeUntilNextBeep;
    float beepCountDown;
    int beepLeft;

    // Start is called before the first frame update
    void Start()
    {
        beepCountDown = initialBeepUntilNextBeep;
        timeUntilNextBeep = initialBeepUntilNextBeep;
        beepLeft = gameDurationInBeeps;
    }

    // Update is called once per frame
    void Update()
    {
        if (beepCountDown > 0)
        {
            beepCountDown -= Time.deltaTime;
        } else {
            if (beepLeft <= 0)
            {
                // beep ten times more after this
                if (beepLeft >= -10)
                {
                    Debug.Log("LAST TEN BEEPS, Current interval: " + timeUntilNextBeep);
                    beepLeft--;
                    AudioSource.PlayClipAtPoint(beep, transform.position);
                    beepCountDown = timeUntilNextBeep;
                }
                else
                {
                    // continuousBeep.Play();
                    Debug.Log("he dead");
                }
            } 
            else
            {
                Debug.Log("Current interval: " + timeUntilNextBeep);
                beepLeft--;
                AudioSource.PlayClipAtPoint(beep, transform.position);
                timeUntilNextBeep -= 0.025f;
                beepCountDown = timeUntilNextBeep;
            }
        }
    }
}
