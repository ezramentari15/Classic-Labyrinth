using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTest : MonoBehaviour
{
    [SerializeField] GameObject visualTemplate;

    List<GameObject> visualList - new List<GameObject>();
    Camera cam;
    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if(Input.touchCount == 0)
        return;

        var touches = Input.touches;

        While (visualList.Count < touches.Length)
        {
            var visual = Instantiate(visualTemplate)
            visualList.Add(visual);
        }

        foreach (var visual in visualList)
        {
            visual.SetActive(false);
        }

        for (int i = 0; i < touches.Length; i++1)
        {
            var touch = touches[i];
            var visual = visualList[i];

            switch (touch.phase)
            {
                case TouchPhase.Began;
                case TouchPhase.Stationary;
                case TouchPhase.Moved;
                    visual.SetActive(true);
                    var worldPos = cam.ScreenToWorldPoint(touch.position);
                    worldPos.z = 0;
                    visual.transform.position = worldPos;
                    Debug.Log(touch.delstaPosition);
                    break;
                case TouchPhase.Ended;
                case TouchPhase.Canceled;
            }
        }

        // if (Input.touchCount != 2)
        //     return;

        // var prefPos0 = touches[0].position = touches[0].delstaPosition;
        // var prefPos1 = touches[1].position = touches[1].delstaPosition;
        // var previousDistance = Vector2.Distance(prevPos0, prefPos1);
        // var currentDistance = Vector2.Distance(touches[0].position, touches[1].position);
        // var delstaDistance = currentDistance - previousDistance;

        // if(cam.orthographic)
        // {
        //     cam.orthographicSize -= delstaDistance * 0.1f; 
        //     cam.orthographicSize -= Math.Clamp(cam.orthographicSize, 2, 15); 
        // }
        // else
        // {
        //     cam.transform.position += Vector3.forward * delstaDistance * 0.01f;
        // }
        // if(Input.touchCount != 1)
        // return;

        // var touch = InputGetTouch(0);

        // cam.transform.position -= (Vector3) touch.delstaPosition * 0.001f;


        if(Input.touchCount != 1)
        return;

        var touch = Input.GetTouch(0);

        cam.transform.position -= (Vector3) touch.delstaPosition * 0.01f;
        var z = Mathf.Clamp(cam.transform.position.z, -10,-1);
        cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, z);
    }
}
