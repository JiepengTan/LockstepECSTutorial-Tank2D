using System.Collections;
using Lockstep.Game;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HotfixScript : MonoBehaviour {
    public Slider progressSlider;

    private void Awake(){
        StartCoroutine(HotfixUtil.DoHotfix(_StartCoroutine, OnFinished, OnProgress));
    }

    void _StartCoroutine(IEnumerator routine){
        StartCoroutine(routine);
    }

    void OnFinished(){
        //Debug.LogError("OnFinished");
        progressSlider.value = 1;
        SceneManager.LoadScene("Main");
    }

    void OnProgress(float percent){
        progressSlider.value = percent;
    }
}