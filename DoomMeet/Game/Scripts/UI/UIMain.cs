using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public enum EURLs { eMainWebPage };

public class UIMain : MonoBehaviour
{

	public GameObject UIPanelBar;
	public GameObject UIPanelMobile;


	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void LaunchURL( EURLs _URL ) {
		string url;
		switch( _URL ) {
			case EURLs.eMainWebPage:
				url = "ww.hevedy.com";
				break;
			default:
				url = "";
				break;
		}
		Application.OpenURL( url );
	}

	public void Panels_Setup() {
		//UIPanelMobile.GetComponentInChildren<UIPanel_Mobile>().name;
	}
}
