using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Text;

public class requestESM
{
    public string server = "https://d469-191-156-157-181.ngrok-free.app/transfer-native-token";

    public void request(string pubKey, int numESM)
    {
        Debug.LogError("Peticion");

        PeticionMinar p = new PeticionMinar();
        p.pubKey = pubKey;
        p.numESM = numESM;
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





