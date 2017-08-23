/*
 * 
 * Script for the block controlled by the player.
 * 
 */

using UnityEngine;

public class PlayerBlock : BlockSandbox {


	//handler for input events; used to receive events from the InputManager
	private InputEvent.Handler inputHandler;
	private const string INPUT_EVENT_NAME = "InputEvent";


	/// <summary>
	/// Specialized Init function for player blocks; among other things, this registers for input events.
	/// </summary>
	/// <param name="startHoriz">Starting x-position in the grid.</param>
	/// <param name="startVert">Start y-position in the grid.</param>
	/// <param name="playerNum">1 or 2.</param>
	/// <param name="startX">Start x.</param>
	/// <param name="startY">Start y.</param>
	public override void Init(int startX, int startY, int playerNum){
		base.Init(startX, startY, playerNum);

		Pushable = false; //change this value specifically for player blocks

		inputHandler = new InputEvent.Handler(InputResponse);
		Services.EventSys.Register<InputEvent>(inputHandler);
	}


	private void InputResponse(Event e){
		Debug.Assert(e.GetType().Name == INPUT_EVENT_NAME);

		InputEvent inputEvent = e as InputEvent;

		ReceiveInput(inputEvent.input);
	}


	public override void ReceiveInput(string input){
		base.ReceiveInput(input);

		IsMoving = true;
	}


	/// <summary>
	/// Unregisters for input events.
	/// </summary>
	public override void GetDestroyed(){
		Services.EventSys.Unregister<InputEvent>(inputHandler);
	}
}
