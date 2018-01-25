using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckForPlayers : MonoBehaviour {

    public SynchPlayerInfo [] _players;

    [Header("Debug")]
    public Text _playersName;

    void Start () {
        InvokeRepeating("CheckPlayersInScene", 0, 1f);	
	}
	
	void CheckPlayersInScene() {
        string names = "";
        _players =  GameObject.FindObjectsOfType<SynchPlayerInfo>();
        for (int i = 0; i < _players.Length; i++)
        {
            names += " "+ _players[i]._pseudo;

        }
        _playersName.text = names;
	}
}
