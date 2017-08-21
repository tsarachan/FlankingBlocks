/*
 * 
 * This script handles the top-level logic of actual gameplay: setting up the board, checking for the players' actions, etc.
 * 
 */

using UnityEngine;

public class PlayManager : MonoBehaviour {


	/// <summary>
	/// Initialize services
	/// </summary>
	private void Start(){
		Services.EventSys = new EventSystem();
		Services.InputManage = new InputManager();
		Services.InputManage.Init();
		Services.GridManage = new GridManager();
		Services.GridManage.Init();
	}


	/// <summary>
	/// The core update loop of the game. For ease of handling things like pausing, this is the game's single update loop;
	/// no object is allowed to have its own.
	/// </summary>
	private void Update(){
		Services.InputManage.Tick();
	}
}
