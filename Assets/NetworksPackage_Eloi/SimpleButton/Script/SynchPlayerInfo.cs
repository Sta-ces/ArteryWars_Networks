using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class SynchPlayerInfo : NetworkBehaviour
{
        
    [SyncVar]
    public string _pseudo;



    public void ChangePseudo(string name) {
        CmdChangePseudoName(name);
    }

    [Command]
    public void CmdChangePseudoName(string name)
    {
        Debug.Log("new name:" + name);
        if(isServer)
        _pseudo = name;

    }
}
