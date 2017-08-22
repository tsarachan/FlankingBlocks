public class InputEvent : Event {

	public readonly string input; //use one of the strings in Constants


	public InputEvent(string input){
		this.input = input;
	}
}
