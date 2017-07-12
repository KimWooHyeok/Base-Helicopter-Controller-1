using UnityEngine;

public class FollowTargetCamera : MonoBehaviour
{
    public Transform Target;
    public float PositionFolowForce = 90f;
    public float RotationFolowForce = 90f;
	void Start ()
	{

	}

    void FixedUpdate()
    {
        if (Target == null) return;

        var vector = Vector3.forward;
        var dir = Target.rotation * Vector3.forward;
		dir.y = 0f;
        if (dir.magnitude > 0f) vector = dir / dir.magnitude;
        
        transform.position = Vector3.Lerp(transform.position, Target.position, PositionFolowForce * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(vector), RotationFolowForce * Time.deltaTime);
	}
}

