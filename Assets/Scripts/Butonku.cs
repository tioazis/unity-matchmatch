using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Butonku : MonoBehaviour {

    AudioSource audio;
    Image gambar;
    public Sprite on, off;

	// Use this for initialization
	void Start () {
        audio = this.GetComponent<AudioSource>();
        gambar = this.GetComponent<Image>();
        


    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void onClick()
    {
        audio.mute = true;
        gambar.overrideSprite = off;
    }
    
}
