using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {
    [Tooltip("In ms^-1")] [SerializeField] private float _xSpeed = 4f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * _xSpeed * Time.deltaTime;
        
        Debug.Log(xOffset);
    }
}
