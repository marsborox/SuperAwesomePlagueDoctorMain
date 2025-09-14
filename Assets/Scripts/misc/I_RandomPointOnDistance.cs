using UnityEngine;

public interface I_RandomPointOnDistance
{
    public Transform ReturnRandomTransformOnDistance(Transform inputTransform,float distance)
    {
        Transform point = inputTransform;
        float randomDegree=Random.Range(0, 360);
        float xIncrement = Mathf.Cos(randomDegree*distance);
        float yIncrement = Mathf.Cos(randomDegree*distance);

        point.position = new Vector3(inputTransform.position.x+xIncrement,inputTransform.position.y+yIncrement, inputTransform.position.z); 

        return point;
    }
}
