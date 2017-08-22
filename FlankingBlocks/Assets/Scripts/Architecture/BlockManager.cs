/*
 * 
 * This manages the movement and combat of the blocks.
 * 
 */

using System.Collections.Generic;
using UnityEngine;


public class BlockManager {


	//transforms where blocks are organized
	private Transform playerOrganizer;
	private const string PLAYER_ORGANIZER = "Players";


	//blocks the block manager can instantiate
	private const string PLAYER_1_BLOCK = "Player 1";


	public void Init(){
		//initialize organizers
		playerOrganizer = GameObject.Find(PLAYER_ORGANIZER).transform;

		GameObject player1 = Object.Instantiate(Resources.Load(PLAYER_1_BLOCK), playerOrganizer) as GameObject;
		player1.GetComponent<BlockSandbox>().Init(0, 0, 1);
	}
}
