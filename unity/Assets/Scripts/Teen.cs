using UnityEngine;
using System.Collections;

public class Teen : MonoBehaviour {
	
	[SerializeField] private Transform playerCam;
	[SerializeField] private Transform playerCamCont;
	
	[SerializeField] private float MoveSpeed = 1f;
	[SerializeField] private float LookXSpeed = 1f;
	[SerializeField] private float LookYSpeed = 1f;
	[SerializeField] private Vector2 LookYClamp = new Vector2(-30, 50);
	
	public Vector3 Forward { 
		get {
			return playerCam.forward;
		}
	}
	
	private Vector2 _rightStick;
	private Vector2 RightStick { 
		get {
			return _rightStick;
		}
	}
	
	private Vector2 _leftStick;
	private Vector2 LeftStick { 
		get {
			return _leftStick;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		UpdateInput ();
		
		UpdatePlayerPos ();
		UpdatePlayerView ();
		
	}
	
	private void UpdateInput () {
		_rightStick = new Vector2(Input.GetAxis("RightStickX1"), Mathf.Clamp(Input.GetAxis("RightStickY1"), -LookYClamp.y, -LookYClamp.x));
		_leftStick = new Vector2(Input.GetAxis("LeftStickX1"), Input.GetAxis("LeftStickY1"));
	}
	
	private void UpdatePlayerPos () {
		transform.Translate(new Vector3(LeftStick.x*MoveSpeed, 0, LeftStick.y*MoveSpeed), Space.Self);
	}
	
	private void UpdatePlayerView () {
		transform.Rotate(0, RightStick.x * LookXSpeed, 0);
		playerCam.Rotate(RightStick.y * LookYSpeed, 0, 0);
	}
}
