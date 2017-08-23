using Rewired;
using UnityEngine;

public class InputManager {


	//the players
	private Player player1;
	private const string PLAYER_1 = "Player1";
	private Player player2;
	private const string PLAYER_2 = "Player2";


	//the possible inputs; these match the Action names in Rewired
	private const string MOVE_VERT = "MoveVert";
	private const string MOVE_HORIZ = "MoveHoriz";


	//input dead zone for axes
	private float deadZone = 0.3f;


	public void Init(){
		player1 = ReInput.players.GetPlayer(PLAYER_1);
		player2 = ReInput.players.GetPlayer(PLAYER_2);
	}


	public void Tick(){
		if (player1.GetAxis(MOVE_VERT) > deadZone){
			Services.EventSys.Fire(new InputEvent(Constants.UP));
		} else if (player1.GetAxis(MOVE_VERT) < -deadZone){
			Services.EventSys.Fire(new InputEvent(Constants.DOWN));
		}

		if (player1.GetAxis(MOVE_HORIZ) < -deadZone){
			Services.EventSys.Fire(new InputEvent(Constants.LEFT));
		} else if (player1.GetAxis(MOVE_HORIZ) > deadZone){
			Services.EventSys.Fire(new InputEvent(Constants.RIGHT));
		}
	}
}
