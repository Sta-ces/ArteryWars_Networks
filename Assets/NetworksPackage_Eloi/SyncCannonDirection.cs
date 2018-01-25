using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SyncCannonDirection : NetworkBehaviour {

    public Transform _direction;
    public Transform _affected;
    
    [System.Serializable]
    public class Range {
        public Range(float min=-180, float max=180) {
            _min = min;
            _max = max;
        }
        public float _min = -180, _max = 180;

        public float GetValue(float pourcent) {
            return Mathf.Lerp(_min, _max, pourcent);
        }
    }

    [SyncVar]
    [Range(0,1)]
    public float _horizontalRotation;
    public Range _horizontalRange = new Range(-180, 180);

    [SyncVar]
    [Range(0, 1)]
    public float _verticalRotation;
    public Range _verticalRange = new Range(10, 88);

    public float GetHorizontal()
    {
       return _horizontalRange.GetValue(_horizontalRotation);
    }
    public float GetVertical()
    {
       return _verticalRange.GetValue(_verticalRotation);
    }


    public void Update()
    {
        _affected.rotation = Quaternion.Euler(new Vector3(-GetVertical(), -GetHorizontal(), 0)) * _direction.rotation;
    }

    public void SetHorizontal(float pourcent)
    {
        CmdSetHorizontal(pourcent);
    }
    public void SetVertical(float pourcent)
    {

        CmdSetVertical(pourcent);
    }

    [Command]
    private void CmdSetHorizontal(float pourcent)
    {
        _horizontalRotation = pourcent;
    }
    [Command]
    private void CmdSetVertical(float pourcent)
    {

        _verticalRotation = pourcent;
    }
}
