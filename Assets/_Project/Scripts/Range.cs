using UnityEngine;

[System.Serializable]
public class Range {

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
