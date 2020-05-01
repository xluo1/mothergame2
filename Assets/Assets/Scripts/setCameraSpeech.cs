using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setCameraSpeech : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas speechCanvas;
    void Start()
    {
        
    }

    public void setCanvasCamera(Camera camera)
    {
        speechCanvas.GetComponent<Canvas>().worldCamera = camera;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
