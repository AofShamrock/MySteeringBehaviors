using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyStateMachine : MonoBehaviour {
	
	public List<string> levels = new List<string>();
	public enum State{PauseState,Pursuing,FleeState,StartState,AvoidState}
	public State state = State.PauseState;
	GameObject leader;

	void Switching()
	{
		switch(state)
		{
		case State.PauseState:
			PauseState ();
			break;
		case State.StartState:
			StartState();
			break;
		case State.FleeState:
			FleeState();
			break;
		case State.Pursuing:
			Pursuing();
			break;
		case State.AvoidState:
			AvoidState();
			break;
		}
	}

	void Update()
	{
		/*switch(state)
		{
		case State.PauseState:
			PauseState ();
			break;
		case State.StartState:
			StartState();
			break;
		case State.FleeState:
			FleeState();
			break;
		case State.Pursuing:
			Pursuing();
			break;
		case State.Flee:
			Flee();
			break;
		}*/

		
		if (Input.GetKeyDown (KeyCode.A))
		{
			//state = State.AttackState;
			//myGameObject.GetComponent<StateMachine>().SwitchState (new TrackState(myGameObject));
			GetComponent<SteeringBehaviours>().TurnOffAll();
			FleeState();
			Debug.Log("Cells are Fleeing");
			//state = State.AttackState;
		}

		if (Input.GetKeyDown (KeyCode.W))
		{
			//state = State.StartState;
			//myGameObject.GetComponent<StateMachine>().SwitchState (new TrackState(myGameObject));
			GetComponent<SteeringBehaviours>().TurnOffAll();
			StartState();
			Debug.Log("Cells are moving!");
			//state = State.StartState;
		}

		if (Input.GetKeyDown (KeyCode.D))
		{
			//state = State.InGame;
			//myGameObject.GetComponent<StateMachine>().SwitchState (new TrackState(myGameObject));
			GetComponent<SteeringBehaviours>().TurnOffAll();
			Pursuing();
			Debug.Log("cells are Pursuing");
			//state = State.InGame;
		}

		if (Input.GetKeyDown (KeyCode.S))
		{
			//state = State.InGame;
			//myGameObject.GetComponent<StateMachine>().SwitchState (new TrackState(myGameObject));
			GetComponent<SteeringBehaviours>().TurnOffAll();
			AvoidState();
			Debug.Log("cells are Avoiding");
			//state = State.Flee;
		}
	}

	void PauseState ()
	{
		GetComponent<SteeringBehaviours>().TurnOffAll();
		Debug.Log("PauseState");
		state = State.PauseState;
	}

	void StartState()
	{
		//GetComponent<SteeringBehaviours>().TurnOffAll();
		state = State.StartState;
		GetComponent<SteeringBehaviours>().pathFollowEnabled = true;
		GetComponent<SteeringBehaviours>().seperationEnabled = true;
		GetComponent<SteeringBehaviours>().cohesionEnabled = true;
		GetComponent<SteeringBehaviours>().alignmentEnabled = true;
		//Debug.Log("Cells are moving!");
	}

	void FleeState()
	{
		//GetComponent<SteeringBehaviours>().TurnOffAll();
		state = State.FleeState;
		GetComponent<SteeringBehaviours>().seekTargetPos = new Vector3(0, 0, 5000f);
		GetComponent<SteeringBehaviours>().seekEnabled = true;
		GetComponent<SteeringBehaviours>().seperationEnabled = true;
		GetComponent<SteeringBehaviours>().cohesionEnabled = true;
		GetComponent<SteeringBehaviours>().alignmentEnabled = true;
		//Debug.Log("Cells are attacking");
	}

	void Pursuing()
	{
		state = State.Pursuing;
		if(GetComponent<SteeringBehaviours>().target == null) //if this boid hasn't already got a target (leader)
		{
			leader = GameObject.Find ("Leader"); //then find the leader in the scene
			GetComponent<SteeringBehaviours>().target = leader; //assign the leader to the target 
		}
		//This is where you toggle the steering behaviours ON!
		GetComponent<SteeringBehaviours>().pursueEnabled = true;
		GetComponent<SteeringBehaviours>().seperationEnabled = true;
		GetComponent<SteeringBehaviours>().cohesionEnabled = true;
		GetComponent<SteeringBehaviours>().alignmentEnabled = true;
		//Debug.Log("cells are Pursuing");
	}

	void AvoidState()
	{
		//Fleeing = GameObject.Find ("Flee");
		//GetComponent<Renderer>
		state = State.AvoidState;
		GetComponent<SteeringBehaviours>().fleeEnabled = true;
		//Debug.Log("cells are Fleeing");
	}
}