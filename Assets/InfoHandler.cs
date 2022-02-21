using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoHandler : MonoBehaviour
{
    static public int currentScene = 1;
 
    
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
