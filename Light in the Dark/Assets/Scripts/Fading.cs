/**
 * Load a scene with a fade effect
 * 
 * @author Maurizio Lepora <lemaur@gmail.com>
 * @source Taken from Asbjørn Thirslund's guide on https://youtu.be/0HwZQt94uHQ
 */


using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class Fading : MonoBehaviour {

	public Texture2D ProgressBar;
	public Texture2D ProgressBarBackground;
	public Texture2D fadeOutTexture;		// the texture that will overlay the screen
	public float fadeSpeed 	= 0.8f;			// the fading speed

	private int drawDepth 	= -999;		// the texture's order in the draw hierarchy: a low number means it renders on top
	private float alpha 	= 1.0f;			// the texture's alpha value between 0 and 1
	private int fadeDir 	= -1;			// the direction to fade: in = -1 or out = 1
	private AsyncOperation Async;

	void OnGUI () {

		// fade out/in the alpha value using a direction, a speed and Time.deltatime to convert the operation to seconds
		alpha += fadeDir * fadeSpeed * Time.fixedDeltaTime;

		// force (Clamp) the number between 0 and 1 because GUI.color uses alpha values between 0 and 1
		alpha = Mathf.Clamp01 (alpha);

		// set color of our GUI (in this case our texture). All color values remain the same & the Alpha is set to the alpha variable
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);				// set the alpha value
		GUI.depth = drawDepth;																// make the texture render on top (drawn last)
		GUI.DrawTexture (new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);		// draw the texture to fit the entire screen area
		
		if (Async != null) {
			
			// Progress Bar Size
			int Width = Screen.width / 3;
			int Heigth = 60;

			// Center in the screen
			int X = (Screen.width / 2) - (Width / 2);
			int Y = (Screen.height / 2) - (Heigth / 2);

			// Draw on screen
			GUI.depth = drawDepth;																// make the texture render on top (drawn last)
			//GUI.DrawTexture (new Rect (X, Y, Width, Heigth), ProgressBarBackground);			// draw the progress bar background
			//GUI.DrawTexture (new Rect (X, Y, Width * Async.progress, Heigth), ProgressBar);		// draw the progress bar		

			//GUIStyle gs = new GUIStyle();
			//gs.fontSize = 40;
			//gs.alignment = TextAnchor.MiddleCenter;

			//GUI.skin.label.alignment = TextAnchor.MiddleCenter;
			//GUI.Label (new Rect(X, Y, Width, Heigth), string.Format("{0:N0}%", Async.progress * 100), gs);
        }
	}


	// sets fadeDir to the direction parameter making the scene fade in if -1 and out if 1
	public float BeginFade (int direction) {
		
		fadeDir = direction;
		return fadeSpeed;		// return the fadeSpeed variable so it's easy to time the Application.LoadLevel();
	}


	// OnLevelWasLoaded is called when a level is loaded. It takes loaded level index (int) as a parameter so you can limit the fade in to certain scenes
	void OnLevelWasLoaded () {

		alpha = 1;			// uncomment this if the alpha is not set to 1 by default
		BeginFade (-1);			// call the fade in function
	}


	/**
	 * Load scene with fade in/out effect
	 * 
	 * @param string SceneName
	 * @param float WaitFor = 0.6f
	 * @return void
	 */
	public void LoadScene (string SceneName, float WaitFor = 0.6f) {
		
		StartCoroutine (ChangeScene(SceneName, WaitFor));
	}


	/**
	 * Load scene with fade in/out effect asynchronously
	 * 
	 * @param string SceneName
	 * @param float WaitFor = 0.6f
	 * @return void
	 */
	public void LoadSceneAsync (string SceneName, float WaitFor = 0.6f) {
		
		StartCoroutine (ChangeSceneAsync(SceneName, WaitFor));
	}


	/**
	 * Change the specified scene
	 * 
	 * @param string SceneName
	 * @param float WaitFor = 0.6f
	 * @return void
	 */
	IEnumerator ChangeScene (string SceneName, float WaitFor = 0.6f) {

		// wait for animation to stop playing
		yield return StartCoroutine(WaitForRealSeconds (WaitFor));

		// fade out the game and load a new scene
		float fadeTime = BeginFade(1);
		yield return StartCoroutine(WaitForRealSeconds (fadeTime));

		SceneManager.LoadScene (SceneName);
	}


	/**
	 * Change the specified scene asynchronously
	 * 
	 * @param string SceneName
	 * @param float WaitFor = 0.6f
	 * @return void
	 */
	IEnumerator ChangeSceneAsync (string SceneName, float WaitFor = 0.6f) {

		// wait for animation to stop playing
		yield return StartCoroutine(WaitForRealSeconds (WaitFor));

		// fade out the game and load a new scene
		BeginFade(1);

		Async = SceneManager.LoadSceneAsync (SceneName);
		yield return Async;
	}


	/**
	 * This function does not break when Time.timeScale is equal zero
	 * 
	 * @param float time
	 * @return yield
	 */
	public static IEnumerator WaitForRealSeconds(float time) {
		
		float start = Time.realtimeSinceStartup;

		while (Time.realtimeSinceStartup < start + time) {
			
			yield return null;
		}
	}
}