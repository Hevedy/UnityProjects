using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class UIPanel_Mobile : MonoBehaviour
{

	public GameObject UIPanelUsers; // // = GameObject.Find( "ObjectName" );
	public GameObject UIPanelChats;
	public GameObject UIPanelProfile;

	[SerializeField]
	public CanvasGroup UIPanelCustom;

	public IPanel MyPanel;


	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	//UIPanelUsers.GetComponent<CanvasGroup>.block
	//UIPanelUsers.GetComponent(CanvasGroup)
	//UIPanelUsers.SetActive(false);
	/*
	UIPanelUsers.GetComponent<Renderer>().enabled = false; //Only view
	UIPanelUsers.GetComponent<CanvasGroup>().blocksRaycasts = true; //Only view
	CanvasGroup uiPanelCustom = UIPanelUsers.GetComponent<CanvasGroup>();
	uiPanelCustom.blocksRaycasts = true;*/

	public void Panel_Users() {
		Panels_Disable();
		UIPanelUsers.SetActive( true );
	}

	public void Panel_Chats() {
		Panels_Disable();
		UIPanelChats.SetActive( true );

	}

	public void Panel_Profile() {
		Panels_Disable();
		UIPanelProfile.SetActive( true );
	}

	public void Panels_Disable() {
		UIPanelUsers.SetActive( false );
		UIPanelChats.SetActive( false );
		UIPanelProfile.SetActive( false );
	}
}
