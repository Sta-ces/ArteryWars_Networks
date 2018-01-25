using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerDirectionTarget : NetworkBehaviour {

    public Transform m_PivotCanon;
    public Transform m_DirectionUpDown;

    [SyncVar]
    [Range(0, 1)]
    public float _horizontalRotation;
    public Range _horizontalRange = new Range(-180, 180);

    [SyncVar]
    [Range(0, 1)]
    public float _verticalRotation;
    public Range _verticalRange = new Range(10, 88);

    [System.Serializable]
    public class Range
    {
        public Range(float min = -180, float max = 180)
        {
            _min = min;
            _max = max;
        }
        public float _min = -180, _max = 180;

        public float GetValue(float pourcent)
        {
            return Mathf.Lerp(_min, _max, pourcent);
        }
    }

    public void SliderDirectionUpDown(Slider _slider)
    {
        Cmd_SliderDirection(_slider.value);
    }

    [Command]
    private void Cmd_SliderDirection(float _value)
    {
        m_PivotCanon.rotation = Quaternion.Euler(new Vector3(-_verticalRange.GetValue(_value),0f,0f));
    }

}
