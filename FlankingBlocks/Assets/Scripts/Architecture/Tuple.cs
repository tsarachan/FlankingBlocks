/*
 * 
 * Unity's implementation of C# doesn't support tuples, so this is a super-simple way to make them.
 * 
 */


public class Tuple<T1, T2> {

	public T1 Value1 { get; set; }
	public T2 Value2 { get; set; }


	//constructor
	public Tuple(T1 value1, T2 value2){
		Value1 = value1;
		Value2 = value2;
	}
}
