using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleat : MonoBehaviour
{
    public float maxWait; //Max time for wating to bleat
    public float wait; //Time waiting until next bleat

    public bool waiting; //Control waiting for next bleat

    public AudioSource baaClip;

    // Start is called before the first frame update
    void Start()
    {
        waiting = false;
        baaClip = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Baa();
    }

    void Baa()
    {
        //If  sheep is not waiting, bleat
        if(waiting == false)
        {
            RandomWait();
            PlayClip();
        }
    }

    //Generate a random time to wait to bleat
    void RandomWait()
    {
        wait = Random.Range(1, maxWait+1);
    }

    //Wait until audio is done
    void FinishClip()
    {
        StartCoroutine(WaitClip());
    }

    //When bleating is done, start waiting
    void DelayBleat()
    {
        FinishClip();
        StartCoroutine(CountWait());
    }

    void PlayClip()
    {
        DelayBleat();
        baaClip.Play();
    }

    //Wait for length of randomly generated wait time, then stop waiting
    IEnumerator CountWait()
    {
        yield return new WaitForSeconds(wait);
        waiting = false;
    }

    IEnumerator WaitClip()
    {
        waiting = true;
        yield return new WaitForSeconds(2);
    }
}
