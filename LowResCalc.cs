using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Pixelation")]

public class NewBehaviourScript : MonoBehaviour{
    public int w = 720;
    int h; 

    void Update(){
        float ratio = ((float)Camera.main.pixelHeight / (float)Camera.main.pixelWidth);
        h = Mathf.RoundToInt(w * ratio);
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination){
        source.filterMode = FilterMode.Point;
        RenderTexture buffer = RenderTexture.GetTemporary(w, h, -1);

        buffer.filterMode = FilterMode.Point;
        Graphics.Blit(source, buffer);
        Graphics.Blit(buffer, destination);
        RenderTexture.ReleaseTemporary(buffer);
    }
}
