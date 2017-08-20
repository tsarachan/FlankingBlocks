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
}
