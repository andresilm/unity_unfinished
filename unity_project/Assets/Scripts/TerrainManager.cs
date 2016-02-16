using UnityEngine;
using System.Collections;

public class TerrainManager : MonoBehaviour {
	GameObject[] fields;
	float fieldsSize;

	void Awake () {
		fields = GameObject.FindGameObjectsWithTag("FieldType");

	}

	// Use this for initialization
	void Start () {
		fieldsSize = fields[1].transform.position.x - fields[0].transform.position.x;

	}

	void Update() {



		if (FieldIsAtExitPoint(fields[0])) {
			ArrangeField(fields[0]);
		}

		else if (FieldIsAtExitPoint(fields[1])) {
			ArrangeField(fields[1]);
		}


	}

	bool FieldIsAtExitPoint(GameObject aField) {
		Vector3 fieldPos = aField.transform.TransformPoint(Vector3.right);
		Vector3 thisPos = this.transform.TransformPoint(Vector3.right);

		return fieldPos.x   <= thisPos.x - fieldsSize/4.0f;
	}



	void ArrangeField(GameObject aField) {
		float x = aField.transform.position.x;
		float y = aField.transform.position.y;
		float z = aField.transform.position.z;

		aField.transform.position = new Vector3(x+fieldsSize*2,y,z);
	}


}
