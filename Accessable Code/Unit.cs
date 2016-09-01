using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {
    [SerializeField] protected GameObject BottomCube;
    protected GameObject _movementCircle = null;
    //Distance for the default movement circle should be close to a 1627.5km 
    //The in game units works out to be around 1627533
    protected float _distancePerTurn = 30700f; //Not sure what units this is in
    protected float _distancePerTurnRadians = .266f; //Using radians seems to work alot better than kronnet units

    public GameObject movementCircle
    {
        get { return _movementCircle; }
        set { if (value != null) _movementCircle = value; }
    }

    //Even using the bottomCube there is still a slight offset, there should be a way to get the position at the bottom of the capsule.
    public GameObject bottomCube
    {
        get
        {
            return BottomCube;
        }
    }

    public float distancePerTurn { get { return _distancePerTurn; } }
    public float distancePerTurnRadians { get { return _distancePerTurnRadians; } }

    //bool _mouseIsOverUnit;
    /// Returns true is mouse has entered the Earth's collider.
    /*public Unit mouseIsOverUnit
    {
        
            return ;
        }
    }*/

    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DestroyMovementCircle()
    {
        Destroy(_movementCircle);
        _movementCircle = null;
    }

    void OnTriggerStay(Collider other)
    {
        //Debug.Log("Unit collided with: " + other.gameObject.tag);
        if(other.gameObject.tag == "Unit")
            Destroy(other.gameObject);
        //other
    }

}
