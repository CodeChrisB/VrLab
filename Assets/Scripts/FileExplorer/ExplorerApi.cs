using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ExplorerApi : MonoBehaviour
{
    private void Start(){OpenFileExplorer();
    }
    public GameObject obj;
    public RawImage image;

    public void OpenFileExplorer()
    {
        string model = EditorUtility.OpenFilePanel("Select obj file", "", "");
        string texture  = EditorUtility.OpenFilePanel("Select texture file", "", "");
        if (model.EndsWith(".obj"))
        {
            obj = OBJLoader.LoadOBJFile(model);
            StartCoroutine(GetTexture(obj, texture));

            Shader shader = Shader.Find("Unlit/Texture");
            foreach(Renderer part in obj.GetComponentsInChildren<Renderer>())
            {
                part.material.shader = shader;
            }
        }


    }

    IEnumerator GetTexture(GameObject model,string texutrePath)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("file:///" + texutrePath);

        yield return www.SendWebRequest();

        if(www.result != UnityWebRequest.Result.ConnectionError)
        {
            Texture texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            image.texture = texture;
            GetComponent<Material>().SetTexture(0, texture);
        }
    }

   

}
