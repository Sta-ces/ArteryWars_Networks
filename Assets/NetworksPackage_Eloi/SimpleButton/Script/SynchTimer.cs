using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SynchTimer : NetworkBehaviour {


    [SyncVar(hook = "OnTimeChange")]
    public float _serverGameTime;


    [Header("Unity Event")]
    public UnityEvent _onTimeChangeEvent;


    [Header("Debug")]
    public Text _debugText;

	void OnTimeChange (float time) {
        _onTimeChangeEvent.Invoke();
        _debugText.text = string.Format("{0:00}:{1:00}", (int)(time / 60f), (int)(time % 60f) );

    }


    public IEnumerator Start()
    {
        if (!isServer)
            yield break;

        while (true) {

            _serverGameTime = Time.timeSinceLevelLoad;
            yield return new WaitForSeconds(0.2f);

        }
    }
}
