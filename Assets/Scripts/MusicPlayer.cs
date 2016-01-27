using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	
	private static MusicPlayer instance = null;
	
	public static MusicPlayer Instance {
		get { return instance; }
	}
	
	void Awake() {
		if(instance != null && instance != this){
			Destroy(this.gameObject);
			Debug.Log("Self destructing");
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}	
}

