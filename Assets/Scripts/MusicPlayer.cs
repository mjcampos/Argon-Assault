using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {
    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(LoadFirstScene());
    }

    IEnumerator LoadFirstScene() {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
}
