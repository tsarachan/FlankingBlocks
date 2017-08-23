/*
 * 
 * This manages the movement and combat of the blocks.
 * 
 */

using System.Collections.Generic;
using UnityEngine;


public class BlockManager {

	//time between each type of block getting to move
	private float playerBlockMoveDelay = 0.1f;
	private float playerBlockMoveTimer = 0.0f;


	//transforms where blocks are organized
	private Transform playerOrganizer;
	private const string PLAYER_ORGANIZER = "Players";


	//blocks the block manager can instantiate
	private const string PLAYER_1_BLOCK = "Player 1";


	//lists of blocks; this manager iterates through these
	private List<PlayerBlock> playerBlocks = new List<PlayerBlock>();


	public void Init(){
		//initialize organizers
		playerOrganizer = GameObject.Find(PLAYER_ORGANIZER).transform;

		GameObject player1 = Object.Instantiate(Resources.Load(PLAYER_1_BLOCK), playerOrganizer) as GameObject;
		player1.GetComponent<BlockSandbox>().Init(0, 0, 1);
		Services.GridManage.EnterGridSpace(0, 0, player1.name);
		playerBlocks.Add(player1.GetComponent<PlayerBlock>());
	}


	/// <summary>
	/// This is the loop that controls block movement and combat. In general, the loop is:
	/// 
	/// MOVEMENT
	/// 1. Iterate through the blocks. For those that want to move (IsMoving == true), call their TryMove(), which indicates which space they want to move into.
	/// At this step, any block that is going to go out of bounds stops wanting to move (IsMoving == false).
	/// 
	/// 2. Iterate through the blocks again. For each one that (a) still wants to move (IsMoving == true) and (b) is trying to go into a space that only
	/// one block wants to enter (GridManager's IntendingToEnter for that space == 1), move that block.
	/// 
	/// Player blocks are resolved first, so that they feel as responsive as possible. To maximize player control, IsMoving is set to false for player blocks
	/// after each move. Other blocks keep IsMoving == true until something else stops them.
	/// 
	/// Player blocks are resolved on a very short timer for better game feel. Non-player blocks are resolved on a longer timer to create the turn order.
	/// </summary>
	public void Tick(){
		playerBlockMoveTimer += Time.deltaTime;

		if (playerBlockMoveTimer >= playerBlockMoveDelay){
			foreach (PlayerBlock player in playerBlocks){
				if (player.IsMoving){
					player.TryMove();
				}
			}

			foreach (PlayerBlock player in playerBlocks){
				if (player.IsMoving && player.GetMovePermission()) { player.Move(); }
				player.IsMoving = false;
			}

			playerBlockMoveTimer = 0.0f;
		}
	}
}
