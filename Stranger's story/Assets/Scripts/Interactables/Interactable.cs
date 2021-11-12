using UnityEngine;
using UnityEngine.AI;

/*	
	This component is for all objects that the player can
	interact with such as enemies, items etc. It is meant
	to be used as a base class.
*/

//[RequireComponent(typeof(ColorOnHover))]
public class Interactable : MonoBehaviour
{

	
	//public BoxCollider interactionZone;

	bool isInRange = false;   // Is this interactable currently being focused?
	Transform player;       // Reference to the player transform

	
	
	void Update()
	{
		
		// If we haven't already interacted and the player is close enough
		if (!hasInteracted && isInRange)
		{
			//Intaract with chest
			if (Input.GetKeyDown(KeyCode.Keypad9))
			{
				Debug.Log("Interacring with object :)");
				// Interact with the object
				hasInteracted = true;
				Interact();
			}

		}
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player") && !isInRange)
		{
			Debug.Log("Player is in range");
			isInRange = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Player") && isInRange)
		{
			Debug.Log("Player is out of range");
			isInRange = false;
		}
	}

	

	// This method is meant to be overwritten
	public virtual void Interact()
	{

	}

}