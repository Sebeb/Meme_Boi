using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioPitchSlowmo : MonoBehaviour {
    AudioSource audio;
    bool slowMo;
    public float normalPitch = 1;

	void Awake () {
        audio = GetComponent<AudioSource>();
	}


    void Update()
    {
        if (game.controller.timeSpeed != 0)
        {
            if (!slowMo)
            {
                normalPitch = audio.pitch;
                slowMo = true;
            }
            audio.pitch = game.controller.timeSpeed / normalPitch;
        }
        else
            audio.pitch = normalPitch;
    }
}
