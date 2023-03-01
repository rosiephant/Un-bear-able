using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class OnScreenMessage
{
    public GameObject go;
    public float timeToLive;

    public OnScreenMessage(GameObject go)
    {
        this.go = go;
    }
}

public class OnScreenMessageSystem : MonoBehaviour
{
    [SerializeField] GameObject textPrefab;

    List<OnScreenMessage> onScreenMessageList;
    List<OnScreenMessage> openList;

    private void Awake()
    {
        onScreenMessageList = new List<OnScreenMessage>();
        openList = new List<OnScreenMessage>();
    }

    private void Update()
    {
        for(int i = onScreenMessageList.Count -1; i >= 0; i--)
        {
            onScreenMessageList[i].timeToLive -= Time.deltaTime;
            if (onScreenMessageList[i].timeToLive < 0)
            {
                onScreenMessageList[i].go.SetActive(false);

                openList.Add(onScreenMessageList[i]);

                onScreenMessageList.RemoveAt(i);
            }
        }
    }

    public void PostMessage(Vector3 worldPosition, string message)
    {
        worldPosition.z = -1f;

        if (openList.Count > 0)
        {
            ReuseObjectFromOpenList(worldPosition, message);
        }
        else
        {
           CreateNewOnScreenMessageObject(worldPosition, message);
        }
    }
    private void ReuseObjectFromOpenList(Vector3 worldPosition, string message)
    {
        OnScreenMessage osm = openList[0];
        osm.go.SetActive(true);
        osm.timeToLive = 6f;
        osm.go.GetComponent<TextMeshPro>().text = message;
        osm.go.transform.position = worldPosition;
        openList.RemoveAt(0);
        onScreenMessageList.Add(osm);
    }

    private void CreateNewOnScreenMessageObject(Vector3 worldPosition, string message)
    {
        GameObject textGO = Instantiate(textPrefab, transform);
        textGO.transform.position = worldPosition;

        TextMeshPro tmp = textGO.GetComponent<TextMeshPro>();
        tmp.text = message;

        OnScreenMessage onScreenMessage = new OnScreenMessage(textGO);
        onScreenMessage.timeToLive = 6f;
        onScreenMessageList.Add(onScreenMessage);
    }
}