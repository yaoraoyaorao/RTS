using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS;
using LitJson;
public class Test1 : MonoBehaviour
{

    void Start()
    {
        List<Build> builds = LoadExcel.GeneratePlaceBuildData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
