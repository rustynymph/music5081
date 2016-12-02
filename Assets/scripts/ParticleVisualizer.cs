using UnityEngine;
using System.Collections;

public class ParticleVisualizer : MonoBehaviour {

	private ParticleSystem particleSystem;
	private int numActiveSteps;

	void Start() {
		particleSystem = gameObject.GetComponent<ParticleSystem>();
	}

	void Update(){
		numActiveSteps = 0;
		Sequencer hihat = GameObject.Find("Hihat").GetComponent<Sequencer>();
		Sequencer kick = GameObject.Find("Kick").GetComponent<Sequencer>();
		Sequencer snare = GameObject.Find("Snare").GetComponent<Sequencer>();
		Sequencer tom1 = GameObject.Find("Tom1").GetComponent<Sequencer>();
		Sequencer tom2 = GameObject.Find("Tom2").GetComponent<Sequencer>();
		for (int i = 0; i < 8; i++){
			if (hihat.sequence[i]) numActiveSteps++;
			if (kick.sequence[i]) numActiveSteps++;
			if (snare.sequence[i]) numActiveSteps++;
			if (tom1.sequence[i]) numActiveSteps++;
			if (tom2.sequence[i]) numActiveSteps++;
		}

	    var emission = particleSystem.emission;
	    if (numActiveSteps <= 0) {
	    	particleSystem.Stop();
	    }
	    else{
	    	emission.rate = 1000.0f;
	    	particleSystem.gravityModifier = 0.75f;
	    	if (numActiveSteps > 0){
	    		particleSystem.gravityModifier = 0.66f;
	    	}
	    	if (numActiveSteps > 4){
	    		particleSystem.gravityModifier = 0.40f;
	    	}
	    	if (numActiveSteps > 10){
	    		particleSystem.gravityModifier = 0.20f;
	    	}
	    	if (numActiveSteps > 16){
	    		emission.rate = 1000.0f;
	    		particleSystem.gravityModifier = 0.0f;
	    	} else if(numActiveSteps > 20){
	    		emission.rate = 2000.0f;
	    		particleSystem.gravityModifier = 0.0f;
	    	}
	    	particleSystem.Play();
	    }
	}

}
