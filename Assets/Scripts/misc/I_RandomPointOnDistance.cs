using UnityEngine;

public interface I_RandomPointOnDistance
{
    public Transform ReturnRandomTransformOnDistance(Transform inputTransform,float distance)
    {
        Transform point = inputTransform;
        float randomDegree=Random.Range(0, 360);
        //Debug.Log("DoWeGet any Log???");
        //Debug.Log("degree = "+randomDegree.ToString());
        //Debug.Log("distance = " + distance.ToString());
        float xIncrement = Mathf.Cos(randomDegree) * distance;
        float yIncrement = Mathf.Sin(randomDegree) * distance;
        //Debug.Log("x = "+ xIncrement.ToString() + " y = "+yIncrement.ToString());
        point.position = new Vector3(inputTransform.position.x+xIncrement,inputTransform.position.y+yIncrement, inputTransform.position.z); 

        return point;
    }
}
