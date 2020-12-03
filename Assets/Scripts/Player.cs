using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {
    [Tooltip("In ms^-1")] [SerializeField] private float _speed = 4f;
    [SerializeField] private float _xRange = 5f;
    [SerializeField] private float _yRange = 5f;
    [SerializeField] private float _positionPitchFactor = -5f;
    [SerializeField] private float _controlPitchFactor = -20f;
    [SerializeField] private float _positionYawFactor = 5f;
    [SerializeField] private float _positionRollFactor = 5f;

    private float _xThrow, _yThrow;
    
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation() {
        float pitch = transform.localPosition.y * _positionPitchFactor + _yThrow * _controlPitchFactor;
        float yaw = transform.localPosition.x * _positionYawFactor;
        float roll = _xThrow * _positionRollFactor;
        
        transform.localRotation = Quaternion.Euler(-pitch, yaw, roll);  // Quaternion.Euler(pitch, yaw, roll)
    }

    private void ProcessTranslation() {
        float _xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = _xThrow * _speed * Time.deltaTime;
        float yOffset = _yThrow * _speed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -_xRange, _xRange);

        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -_yRange, _yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
