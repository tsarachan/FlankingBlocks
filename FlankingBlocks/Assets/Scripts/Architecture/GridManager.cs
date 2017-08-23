public class GridManager {


	//the size of the grid
	private int horizSize = 20;
	private int vertSize = 20;


	//the grid is a 2D array, and cannot be jagged
	private GridData[,] grid;


	//used in GridData, below, to indicate that a space is unoccupied
	private const string NONE = "None";


	//initialize the grid
	public void Init(){
		grid = new GridData[horizSize,vertSize];

		for (int i = 0; i < horizSize; i++){
			for (int j = 0; j < vertSize; j++){
				grid[i,j] = new GridData();
			}
		}
	}



	/// <summary>
	/// Marks that a block is trying to enter a space on the grid.
	/// </summary>
	/// <param name="horizCoord">The horizontal coordinate of the space to be entered.</param>
	/// <param name="vertCoord">The vertical coordinate of the space to be entered.</param>
	public bool TryEnterGridSpace(int xCoord, int yCoord){
		if (xCoord >= 0 &&
			xCoord < horizSize &&
			yCoord >= 0 &&
			yCoord < vertSize){
			grid[xCoord, yCoord].IntendingToEnter++;
			return true;
		}

		return false;
			
	}


	public bool CheckGridSpaceRoom(int xCoord, int yCoord){
		return grid[xCoord, yCoord].IntendingToEnter == 1 ? true : false;
	}


	/// <summary>
	/// Puts a block into a space in the grid. This invovles listing it as the space's Occupant, and zeroing the number of
	/// blocks that are Intending to Enter (since the Occupant successfully moved in, it is necessarily the case that no one else was
	/// intending to enter).
	/// </summary>
	/// <param name="horizCoord">The horizontal coordinate of the space the block is entering.</param>
	/// <param name="vertCoord">The vertical coordinate of the space the block is entering.</param>
	/// <param name="name">The name of the entering block.</param>
	public void EnterGridSpace(int xCoord, int yCoord, string name){
		grid[xCoord, yCoord].IntendingToEnter = 0;
		grid[xCoord, yCoord].Occupant = name;
	}


	/// <summary>
	/// Takes a block out of a space in the grid.
	/// </summary>
	/// <param name="horizCoord">The horizontal coordinate of the space the block is leaving.</param>
	/// <param name="vertCoord">The vertical coordinate of the space the block is leaving.</param>
	public void LeaveGridSpace(int xCoord, int yCoord){
		grid[xCoord, yCoord].Occupant = NONE;
	}


	/// <summary>
	/// This class includes everything a grid space needs to know to be useful. Every space has a GridData assocated with it.
	/// 
	/// The Occupant is the name of the block currently in the space.
	/// 
	/// IntendingToEnter is used to determine whether multiple blocks are trying to move into the same space at the same time.
	/// </summary>
	private class GridData {
		public string Occupant { get; set; }
		public int IntendingToEnter { get; set; }


		public GridData(){
			Occupant = NONE;
			IntendingToEnter = 0;
		}
	}
}
