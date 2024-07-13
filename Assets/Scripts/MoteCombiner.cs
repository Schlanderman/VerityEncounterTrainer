using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoteCombiner : MonoBehaviour
{
    private Dictionary<(Mote2DFormen.ShapeType, Mote2DFormen.ShapeType), Mote3DFormen.ShapeType> combinationDict;

    // Start is called before the first frame update
    void Start()
    {
        combinationDict = new Dictionary<(Mote2DFormen.ShapeType, Mote2DFormen.ShapeType), Mote3DFormen.ShapeType>
        {
            {(Mote2DFormen.ShapeType.Circle, Mote2DFormen.ShapeType.Circle), Mote3DFormen.ShapeType.Sphere},
            {(Mote2DFormen.ShapeType.Square, Mote2DFormen.ShapeType.Square), Mote3DFormen.ShapeType.Cube},
            {(Mote2DFormen.ShapeType.Triangle, Mote2DFormen.ShapeType.Triangle), Mote3DFormen.ShapeType.Pyramid},
            {(Mote2DFormen.ShapeType.Circle, Mote2DFormen.ShapeType.Square), Mote3DFormen.ShapeType.Cylinder},
            {(Mote2DFormen.ShapeType.Square, Mote2DFormen.ShapeType.Circle), Mote3DFormen.ShapeType.Cylinder},  //Beide Richtungen
            {(Mote2DFormen.ShapeType.Circle, Mote2DFormen.ShapeType.Triangle), Mote3DFormen.ShapeType.Cone},
            {(Mote2DFormen.ShapeType.Triangle, Mote2DFormen.ShapeType.Circle), Mote3DFormen.ShapeType.Cone},    //Beide Richtungen
            {(Mote2DFormen.ShapeType.Square, Mote2DFormen.ShapeType.Triangle), Mote3DFormen.ShapeType.Prism},
            {(Mote2DFormen.ShapeType.Triangle, Mote2DFormen.ShapeType.Square), Mote3DFormen.ShapeType.Prism}    //Beide Richtungen
        };
    }

    public void CombineMotes(GameObject mote1, GameObject mote2)
    {
        Mote2DFormen.ShapeType shape1 = mote1.GetComponent<Mote>().currentShape2D;
        Mote2DFormen.ShapeType shape2 = mote2.GetComponent<Mote>().currentShape2D;

        if (combinationDict.TryGetValue((shape1, shape2), out Mote3DFormen.ShapeType combinedShape) ||
            combinationDict.TryGetValue((shape2, shape1), out combinedShape))
        {
            MoteSpawner.Instance.SpawnMote3D(mote1, combinedShape);

            Destroy(mote1.gameObject);
            Destroy(mote2.gameObject);
        }
        else
        {
            Debug.LogError("Combination not found for shapes: " + shape1 + " and " + shape2);
        }
    }
}
