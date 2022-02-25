using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeepScript : MonoBehaviour
{
    public AudioClip beep;
    public AudioSource flatline;
    public GameObject player;
    public int gameDurationInBeeps = 60;
    float initialBeepUntilNextBeep = 1.768f;
    float timeUntilNextBeep;
    float beepCountDown;
    int beepLeft;
    bool gameOver;
    bool playerApproached;

    // Start is called before the first frame update
    void Start()
    {
        beepCountDown = initialBeepUntilNextBeep;
        timeUntilNextBeep = initialBeepUntilNextBeep;
        beepLeft = gameDurationInBeeps;
        gameOver = false;
        playerApproached = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerApproached)
        {
            if (Vector3.Distance(this.transform.position, player.transform.position) <= 40f)
            {
                playerApproached = true;
            }
            else if (beepCountDown > 0)
            {
                beepCountDown -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Current interval: " + timeUntilNextBeep);
                Debug.Log(Vector3.Distance(this.transform.position, player.transform.position));
                AudioSource.PlayClipAtPoint(beep, transform.position);
                beepCountDown = timeUntilNextBeep;
            }
        }
        else if (beepCountDown > 0)
        {
            beepCountDown -= Time.deltaTime;
        } 
        else
        {
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
                else if (!gameOver)
                {
                    flatline.Play();
                    gameOver = true;
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
