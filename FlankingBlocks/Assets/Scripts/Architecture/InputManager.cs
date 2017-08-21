using Rewired;
using UnityEngine;

public class InputManager {


	//the players
	private Player player1;
	private const string PLAYER_1 = "Player1";


	//the possible inputs; these match the Action names in Rewired
	private const string MOVE_VERT = "MoveVert";
	private const string MOVE_HORIZ = "MoveHoriz";


	//input dead zone for axes
	private float deadZone = 0.3f;


	public void Init(){
		player1 = ReInput.players.GetPlayer(PLAYER_1);
	}


	public void Tick(){
		if (player1.GetAxis(MOVE_VERT) > deadZone){
			Debug.Log("Detected a vertical movement");
		}
	}
}
