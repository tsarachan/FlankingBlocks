/*
 * 
 * This script handles the top-level logic of actual gameplay: setting up the board, checking for the players' actions, etc.
 * 
 */

using UnityEngine;

public class PlayManager : MonoBehaviour {


	/// <summary>
	/// Initialize variables and objects
	/// </summary>
	private void Start(){
		Services.EventSys = new EventSystem();
	}


	/// <summary>
	/// The core update loop of the game. For ease of handling things like pausing, this is the game's single update loop;
	/// no object is allowed to have its own.
	/// </summary>
	private void Update(){

	}
}
