using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerDirectionTarget : NetworkBehaviour {
    
    public Transform m_PivotCanon;
    public Transform m_DirectionUpDown;

    [SyncVar]
    public float m_horizontalFloat;
    public Range m_horizontalRange = new Range(-180, 180);
    [SyncVar]
    public float m_verticalFloat;
    public Range m_verticalRange = new Range(10, 88);


    public void SliderDirectionUpDown(Slider _slider)
    {
        Cmd_SliderDirection(_slider.value);
    }

    public void SliderDirectionLeftRight(Slider _slider)
    {
        Cmd_SliderPivot(_slider.value);
    }


    private void FixedUpdate()
    {
        m_PivotCanon.rotation = Quaternion.Euler(new Vector3(-m_verticalFloat, -m_horizontalFloat, 0f));
    }



    [Command]
    private void Cmd_SliderDirection(float _value)
    {
        m_verticalFloat = m_verticalRange.GetValue(_value);
    }

    [Command]
    private void Cmd_SliderPivot(float _value)
    {
        m_horizontalFloat = m_horizontalRange.GetValue(_value);
    }
}
