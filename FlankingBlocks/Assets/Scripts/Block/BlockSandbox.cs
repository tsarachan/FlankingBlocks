/*
 * 
 * This script includes everything a block can do--all of the "verbs" available to blocks.
 * 
 * All blocks inherit from this script.
 * 
 */

using UnityEngine;

public abstract class BlockSandbox : MonoBehaviour {


	//is this player 1's block, or player 2's?
	protected int playerNum = 0;
	protected const int PLAYER_1_NUM = 1;
	protected const int PLAYER_2_NUM = 2;


	//used to move about the grid
	protected Tuple<int, int> currentLocation;
	protected Tuple<int, int> currentFacing;


	//directions a block can face
	//c# doesn't like making these constant, but treat them as such!
	protected Tuple<int, int> UP = new Tuple<int, int>(0, 1);
	protected Tuple<int, int> DOWN = new Tuple<int, int>(0, -1);
	protected Tuple<int, int> LEFT = new Tuple<int, int>(-1, 0);
	protected Tuple<int, int> RIGHT = new Tuple<int, int>(1, 0);


	//is this block in motion?
	public bool IsMoving { get; set; }


	//is this block pushable? (player-controlled pieces generally are not)
	public bool Pushable { get; protected set; }



	/// <summary>
	/// Initialize a block with a starting location and facing, and establish a starting facing
	/// based on whether this is player 1's block or player 2's.
	/// 
	/// The starting facing assumes that player 1's blocks start out facing right, while player 2's face left.
	/// 
	/// This version of Init assumes that it's initializing a pushable block.
	/// </summary>
	/// <param name="startHoriz">Starting x-position in the grid.</param>
	/// <param name="startVert">Start y-position in the grid.</param>
	/// <param name="playerNum">1 or 2.</param>
	public virtual void Init(int startX, int startY, int playerNum){
		currentLocation = new Tuple<int, int>(startX, startY);
		this.playerNum = playerNum;
		currentFacing = (playerNum == PLAYER_1_NUM) ? RIGHT : LEFT;
		IsMoving = false;
		Pushable = true;
	}


	/// <summary>
	/// Use the GridManager's functionality to announce an intent to enter a space.
	/// 
	/// If the space is out of bounds, stop trying to move.
	/// </summary>
	public virtual void TryMove(){
		IsMoving = Services.GridManage.TryEnterGridSpace(currentLocation.Value1 + currentFacing.Value1,
														 currentLocation.Value2 + currentFacing.Value2) ? true : false;
	}


	public virtual bool GetMovePermission(){
		return Services.GridManage.CheckGridSpaceRoom(currentLocation.Value1 + currentFacing.Value1,
													  currentLocation.Value2 + currentFacing.Value2) ? true : false;
	}


	/// <summary>
	/// Use the GridManager's functionality to update the block's position in the grid. Then update this
	/// block's understanding of its own position, and move on screen.
	/// </summary>
	public virtual void Move(){
		Services.GridManage.LeaveGridSpace(currentLocation.Value1, currentLocation.Value2);
		Services.GridManage.EnterGridSpace(currentLocation.Value1 + currentFacing.Value1,
										   currentLocation.Value2 + currentFacing.Value2,
										   gameObject.name);
		
		currentLocation.Value1 += currentFacing.Value1;
		currentLocation.Value2 += currentFacing.Value2;

		transform.position = new Vector3(currentLocation.Value1,
										 currentLocation.Value2,
										 0.0f);
	}


	public virtual void ReceiveInput(string input){
		switch (input){
			case Constants.UP:
				currentFacing = UP;
				break;
			case Constants.DOWN:
				currentFacing = DOWN;
				break;
			case Constants.LEFT:
				currentFacing = LEFT;
				break;
			case Constants.RIGHT:
				currentFacing = RIGHT;
				break;
			default:
				Debug.Log("Illegal input: " + input);
				break;
		}
	}


	public virtual void GetPushed(){
		if (Pushable) { IsMoving = true; }
	}


	public abstract void GetDestroyed();
}
