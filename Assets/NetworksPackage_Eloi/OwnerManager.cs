using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnerManager : MonoBehaviour {

    public SynchPlayerInfo _playerInfo;

    public void AssociateTo(GameObject target) {
        Debug.Log("Hey mon ami");
      OwnerManager owner =  target.AddComponent<OwnerManager>();
        owner._playerInfo = _playerInfo;
    }
}
