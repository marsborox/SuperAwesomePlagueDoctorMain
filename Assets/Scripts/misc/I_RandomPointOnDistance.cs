using UnityEngine;

public interface I_RandomPointOnDistance
{
    public Transform ReturnRandomTransformOnDistance(Transform inputTransform,float distance)
    {
        Transform point = inputTransform;
        float randomDegree=Random.Range(0, 360);
        Debug.Log("degree = "+randomDegree);
        Debug.Log("distance = " + distance);
        float xIncrement = Mathf.Cos(randomDegree) * distance;
        float yIncrement = Mathf.Sin(randomDegree) * distance;
        Debug.Log("x = "+ xIncrement + " y = "+yIncrement);
        point.position = new Vector3(inputTransform.position.x+xIncrement,inputTransform.position.y+yIncrement, inputTransform.position.z); 

        return point;
    }
}
