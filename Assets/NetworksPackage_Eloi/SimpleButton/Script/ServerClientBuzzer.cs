using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ServerClientBuzzer : NetworkBehaviour {


    public Button _uiButton; 
    public AudioSource _onServer;
    public AudioSource _onClient;

    public float _clientDelaySound=3f;

	void Start () {
        _uiButton.onClick.AddListener(PlaySound);
	}

    private void PlaySound()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        Invoke("PlayClientSound", _clientDelaySound);
        CmdPlayServerSound();
    }

    [Command]
    public void CmdPlayServerSound()
    {

        Debug.Log("Play the server Sound");
            _onServer.Play();
    }

    private void PlayClientSound()
    {
        if (isServer)
            return;

        Debug.Log("Play the client Sound");
        _onClient.Play();

    }

}
