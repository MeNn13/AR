using System;
using System.Collections;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    [SerializeField] private GameObject _UI;

    public void OnScreenshot()
    {
        StartCoroutine(TakeScreenshot());
    }

    private IEnumerator TakeScreenshot()
    {
        _UI.SetActive(false);
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();


        NativeGallery.SaveImageToGallery(ss, "AR_Screenshots", DateTime.Now.ToString().Replace("/","-"));
        _UI.SetActive(true);
    }
}
