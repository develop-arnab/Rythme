using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour
{
    public int _band;
    public float _startScale, _scaleMultiplier;
    public bool _useBuffer;
    Material material;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (_useBuffer)
        {
/*            transform.localScale = new Vector3(transform.localScale.x, (AudioVisualiser._bandBuffer[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
*/
            Color _color = new Color(AudioVisualiser._audioBandBuffer[_band], AudioVisualiser._audioBandBuffer[_band], AudioVisualiser._audioBandBuffer[_band]);
            /*if(_color > 0.5)
            {

            }*/
           /* _color = _color * 0.5;*/
            Debug.Log("Emission Color : "+ _color);
            material.SetColor("_EmissionColor", _color);

        }
        if (!_useBuffer)
        {
/*            transform.localScale = new Vector3(transform.localScale.x, (AudioVisualiser._freqBands[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
*/            Color _color = new Color(AudioVisualiser._audioBand[_band], AudioVisualiser._audioBand[_band], AudioVisualiser._audioBand[_band]);
            material.SetColor("_EmissionColor", _color);

        }
    }
}
