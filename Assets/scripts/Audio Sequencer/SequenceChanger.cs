using UnityEngine;
using System.Collections;

public class SequenceChanger : MonoBehaviour {

    public Sequencer seq;
    public string button;
    public bool toggle;
    public int index;
    private MeshRenderer col;
    public Material mat1;
    public Material mat2;
    public Material mat3;

    // Use this for initialization
    void Start () {
        col = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        seq.sequence[index] = toggle;

        if(Input.GetKeyDown(button))
        {
            toggle = !toggle;
        }
        if (toggle)
        {
            col.material = mat1;
        }
        else
        {
            col.material = mat2;
        }

        if (index == this.transform.parent.GetComponent<Sequencer>()._currentStep-1){
            col.material = mat3;
        }
    }
}
