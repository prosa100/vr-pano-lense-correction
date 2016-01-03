using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class LensMesh : MonoBehaviour
{
    public float fov = 235;
    public Func<Vector2, Vector2> lensFunc;
    public float spacingAlg(int x) { return (x + 1) / layers; }

    public int vertsPerLayer = 10;
    public int layers = 3;

    // Use this for initialization
    void Start()
    {
        MakeMesh();
    }

    #region Helpers
    static Vector2 AngleVector(float angle)
    {
        return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }
    static IEnumerable<int> Range(int n)
    {
        return Enumerable.Range(0, n);
    }
    static IEnumerable<float> RangeF(int n)
    {
        return Range(n).Select(i => (float)i / n);
    }
    static IEnumerable<float> RangeF(float from, float to, int steps)
    {
        return RangeF(steps).Select(x => Mathf.Lerp(from, to, x));
    }

    public Vector2 ImgOffset = Vector2.zero;
    public Vector2 ImgScale  = Vector2.one;

    static void PrintAll<T>(IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            print(item);
        }
    }
    #endregion

    Vector3 MakeMagicHappen(Vector2 uv)
    {
        var r = uv.magnitude;
        var zAngle = Mathf.Atan2(uv.y, uv.x);
        //TODO: Change to match the camera.


        var angle = r * fov / 2; //The most important line in the entire program!

        //var focalLength = 1e-6f;
        //var angle = Mathf.Atan(r / focalLength);

        return Quaternion.Euler(0, 0, -zAngle * Mathf.Rad2Deg) * Quaternion.Euler(0, angle, 0) * Vector3.forward;
    }

    void MakeMesh()
    {
        var m = new Mesh();
        var dirs = RangeF(0, 2 * Mathf.PI, vertsPerLayer).Select(t => AngleVector(t) / (layers + 1)).ToArray();
        var verts = Range(layers + 1).SelectMany(l => dirs.Select(d => d * (l + 1))).Concat(new[] { Vector2.zero }).ToArray();

        m.vertices = verts.Select<Vector2, Vector3>(this.MakeMagicHappen).ToArray();
        m.normals = m.vertices;
        //UV is fliped reltive to cords
        m.uv = verts.Select(v => new Vector2(((v.x + 1) / 2) * ImgScale.x, (1 - ((v.y + 1) / 2)) * ImgScale.y) + ImgOffset).ToArray();

        var numTriangles = vertsPerLayer * (layers * 2 + 1);

        /*
        C-D
        |/|
        A-B
         
        ABD, ADC
        */
        var layerProto = Range(vertsPerLayer).SelectMany(v =>
        {
            int s = vertsPerLayer,
                a = v,
                b = (a + 1) % s, c = a + s, d = b + s;
            return new[] { d, b, a, c, d, a };
        }).ToArray();

        //print(vertsPerLayer);
        //print("Hi!");

        //Put a fan in the middle.
        var middleTris = Range(vertsPerLayer).SelectMany(v => new[] { m.uv.Length - 1, v, (v + 1) % vertsPerLayer });

        var tris =
            Range(layers)
            .SelectMany(l => layerProto.Select(x => x + l * vertsPerLayer))
            .Concat(middleTris)
            .ToArray();
        //PrintAll(tris);
        m.triangles = tris;
        m.UploadMeshData(false);

        GetComponent<MeshFilter>().sharedMesh = m;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
