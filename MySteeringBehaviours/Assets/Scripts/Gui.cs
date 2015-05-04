using UnityEngine;
using System.Collections;

public class Gui : MonoBehaviour {

	public  GameObject pauseHide;
	public  GameObject fleeHide;
	public  GameObject avoidHide;
	public  GameObject pursueHide;
	public  GameObject roamHide;

		
		void Start()
		{
		pauseHide.renderer.enabled = true;
		fleeHide.renderer.enabled = false;
		avoidHide.renderer.enabled = false;
		pursueHide.renderer.enabled = false;
		roamHide.renderer.enabled = false;
		}
		
		void Update()
		{
		if(Input.GetKeyDown (KeyCode.W))
		{
			pauseHide.renderer.enabled = false;
			fleeHide.renderer.enabled = false;
			avoidHide.renderer.enabled = true;
			pursueHide.renderer.enabled = false;
			roamHide.renderer.enabled = false;
		}
		if (Input.GetKeyDown (KeyCode.A))
		{
			pauseHide.renderer.enabled = false;
			fleeHide.renderer.enabled = true;
			avoidHide.renderer.enabled = false;
			pursueHide.renderer.enabled = false;
			roamHide.renderer.enabled = false;
		}
		if (Input.GetKeyDown (KeyCode.S))
		{
			pauseHide.renderer.enabled = false;
			fleeHide.renderer.enabled = false;
			avoidHide.renderer.enabled = false;
			pursueHide.renderer.enabled = false;
			roamHide.renderer.enabled = true;
		}
		if (Input.GetKeyDown (KeyCode.D))
		{
			pauseHide.renderer.enabled = false;
			fleeHide.renderer.enabled = false;
			avoidHide.renderer.enabled = false;
			pursueHide.renderer.enabled = true;
			roamHide.renderer.enabled = false;
		}

		}
	}