using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationTest : MonoBehaviour
{
    [SerialiField] TMP_Text SystemInfoText ;
    // Start is called before the first frame update
    void Start()
    {
        SystemInfotext. = "Sensors ";
        if(SystemInfo.supportsAccelerometer)
            Debug.Log("Accelerometer");
        if(SystemInfo.supportsGyroscope)
            Debug.Log("Gyroscope");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
