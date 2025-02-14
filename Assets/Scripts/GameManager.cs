using System.Drawing;
using UnityEngine;
using Color = UnityEngine.Color;

public class GameManager : MonoBehaviour
{
    PrimitiveType primitiveToPlace;
    Vector3 nextShapePreviewPos = new Vector3(-7, 1, 1); 
    GameObject previewObject;

    void GenerateNextShape()
    {
        switch (Random.Range(0, 4)) //4 excluded
        {
            case 0: primitiveToPlace = PrimitiveType.Cube; break;
            case 1: primitiveToPlace = PrimitiveType.Sphere; break;
            case 2: primitiveToPlace = PrimitiveType.Capsule; break;
            case 3: primitiveToPlace = PrimitiveType.Cylinder; break;
            default: primitiveToPlace = PrimitiveType.Cube; break;
        }

        if (previewObject) Destroy(previewObject);

        previewObject = GameObject.CreatePrimitive(primitiveToPlace); 
        previewObject.name = "Preview shape";
        previewObject.transform.position = nextShapePreviewPos;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateNextShape();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                GameObject go = GameObject.CreatePrimitive(primitiveToPlace);
                go.transform.localScale = Vector3.one * 0.3f;
                go.transform.position = hit.point + new Vector3(0, 1f, 0); 
                go.transform.rotation = Random.rotation;

                Block block = go.AddComponent<Block>();

                switch (primitiveToPlace)
                {
                    case PrimitiveType.Cube: block.Points = 5; break;
                    case PrimitiveType.Sphere: block.Points = 10; break;
                    case PrimitiveType.Capsule: block.Points = 15; break;
                    case PrimitiveType.Cylinder: block.Points = 25; break;
                }

                go.AddComponent<Rigidbody>();

                Color randomColor = Random.ColorHSV();
                float H, S, V;
                Color.RGBToHSV(randomColor, out H, out S, out V);

                S = 0.8f;
                V = 0.8f;

                randomColor = Color.HSVToRGB(H, S, V);
                go.GetComponent<MeshRenderer>().material.color = randomColor;

                Texture texture = Resources.Load<Texture>("wood_texture");
                Debug.Log(texture);
            }
        }
    }
}
