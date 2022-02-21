using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoHandler : MonoBehaviour
{
    static public int currentScene = 0;
 
    
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
