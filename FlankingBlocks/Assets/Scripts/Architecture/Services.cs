/*
 * 
 * This service locator provides one-stop access to esssential architectural elements of the code.
 * 
 */

using UnityEngine;

public abstract class Services {

	//event system
	private static EventSystem eventSys;
	public static EventSystem EventSys {
		get { 
			Debug.Assert(eventSys != null);
			return eventSys;
		}

		set { eventSys = value; }
	}


	//input manager
	private static InputManager inputManage;
	public static InputManager InputManage {
		get {
			Debug.Assert(inputManage != null);
			return inputManage;
		}

		set { inputManage = value; }
	}


	//grid
	private static GridManager gridManage;
	public static GridManager GridManage {
		get {
			Debug.Assert(gridManage != null);
			return gridManage;
		}

		set { gridManage = value; }
	}


	//block manager
	private static BlockManager blockManage;
	public static BlockManager BlockManage {
		get {
			Debug.Assert(blockManage != null);
			return blockManage;
		}

		set { blockManage = value; }
	}
}
