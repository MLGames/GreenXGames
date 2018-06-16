#pragma strict

function OnTriggerEnter (other:Collider) {
	if(other.tag=="Player"){
		GetComponent.<AudioSource>().Play();
	}
}
function OnTriggerExit (other:Collider) {
	if(other.tag=="Player"){
		GetComponent.<AudioSource>().Stop();
	}
}
