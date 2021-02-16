using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPlayerState : MonoBehaviour
{
    public static GPlayerState Instance;

    void Awake() {
        if ( Instance == null )
            Instance = this;

        if ( Instance != this )
            Destroy( gameObject );
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
