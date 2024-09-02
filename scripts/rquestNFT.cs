using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Text;

public class rquestNFT : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void Click()
    {
        string server = "http://localhost:3000/obtain-nft";
        Debug.LogError("Peticion");

        PeticionMinar p = new PeticionMinar();
        p.pubKey = "0xb18B217e7af74646f18BCd2E4d70BB43F3485845";
        p.numESM = 0;
        string json = JsonUtility.ToJson(p);

        var request = new UnityWebRequest(server, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
        request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            Debug.LogError(request.error);
        else
            Debug.LogError("Si se pudo");
    }
}





