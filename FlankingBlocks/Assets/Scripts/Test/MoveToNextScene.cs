//advances to the next scene upon any input

namespace Test
{
	using UnityEngine;
	using UnityEngine.SceneManagement;

	public class MoveToNextScene : MonoBehaviour {


		//the scene to load
		private int nextScene = 0;


		//determine the index of the next scene
		//if at the last scene, loop back to start
		private void Start(){
			nextScene = SceneManager.GetActiveScene().buildIndex + 1;
			if (nextScene == SceneManager.sceneCount - 1){
				nextScene = 0;
			}
		}


		//load the next scene upon any input
		private void Update(){
			if (Input.anyKeyDown) { SceneManager.LoadScene(nextScene); }
		}
	}
}
