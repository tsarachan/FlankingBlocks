/*
 * 
 * This script includes everything a block can do--all of the "verbs" available to blocks.
 * 
 * All blocks inherit from this script.
 * 
 */

using UnityEngine;

public class BlockSandbox : MonoBehaviour {


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



	/// <summary>
	/// Initialize a block with a starting location and facing, and establish a starting facing
	/// based on whether this is player 1's block or player 2's.
	/// 
	/// The starting facing assumes that player 1's blocks start out facing right, while player 2's face left.
	/// </summary>
	/// <param name="startHoriz">Starting x-position in the grid.</param>
	/// <param name="startVert">Start y-position in the grid.</param>
	/// <param name="playerNum">1 or 2.</param>
	public virtual void Init(int startX, int startY, int playerNum){
		currentLocation = new Tuple<int, int>(startX, startY);
		this.playerNum = playerNum;
		currentFacing = (playerNum == PLAYER_1_NUM) ? RIGHT : LEFT;
	}


	public virtual void TryMove(){
		Services.GridManage.TryEnterGridSpace(currentLocation.Value1 + currentFacing.Value1,
											  currentLocation.Value2 + currentFacing.Value2);
	}


	public virtual void Move(){
		Services.GridManage.EnterGridSpace(currentLocation.Value1 + currentFacing.Value1,
										   currentLocation.Value2 + currentFacing.Value2,
										   gameObject.name);
	}
}
