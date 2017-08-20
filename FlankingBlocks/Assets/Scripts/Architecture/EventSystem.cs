/*
 * 
 * This is the logic for a synchronous event system. Special thanks to Mattia Romeo for this implementation!
 * 
 */

using System;
using System.Collections.Generic;


//abstract class for events
public abstract class Event {
	public delegate void Handler(Event e);
}


/*
 * 
 * This is the logic other classes use to register for, fire, and unregister for events.
 * 
 * Broadly, the registeredHandlers dictionary contains delegates indexed by types of events. When an event is fired, all registered
 * delegates are called.
 * 
 */
public class EventSystem {

	private Dictionary<Type, Event.Handler> registeredHandlers = new Dictionary<Type, Event.Handler>();


	//register for events
	public void Register<T>(Event.Handler handler) where T : Event {
		Type type = typeof(T);

		if (registeredHandlers.ContainsKey(type)){
			registeredHandlers[type] += handler;
		} else {
			registeredHandlers[type] = handler;
		}
	}


	//unregister for events
	public void Unregister<T>(Event.Handler handler) where T : Event {
		Type type = typeof(T);
		Event.Handler handlers;

		if (registeredHandlers.TryGetValue(type, out handlers)){
			handlers -= handler;

			if (handlers == null){
				registeredHandlers.Remove(type);
			} else {
				registeredHandlers[type] = handlers;
			}
		}
	}


	//send out events
	public void Fire(Event e){
		Type type = e.GetType();
		Event.Handler handlers;

		if (registeredHandlers.TryGetValue(type, out handlers)){
			handlers(e);
		}
	}
}
