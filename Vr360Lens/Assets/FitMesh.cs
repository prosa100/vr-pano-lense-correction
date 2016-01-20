using UnityEngine;
using System.Collections;


/// <summary>
/// This takes a diffrent aproach.
/// Insted of generating the mesh based on the data, I take a mesh and create the uv cords for it.
/// this should actully be done with a shader.
/// Or using defered rendering, but that is bad for vr.
/// </summary>
[ExecuteInEditMode]
public class FitMesh: MonoBehaviour {
    public Mesh sourceMesh;
    public float bias;
    public float defaultDistance;
    Mesh mesh;

    //intersection closest to intection along normal ray 
    void Fit()
    {
        if(!mesh)
        {
            mesh = Instantiate(sourceMesh);
            GetComponent<MeshFilter>().mesh = mesh;
        }
        var sourceVerts = sourceMesh.vertices;
        var outVerts = mesh.vertices;

        for (int i = 0; i < sourceVerts.Length; i++)
        {
            var v = sourceVerts[i].normalized;
            RaycastHit hit;
            var dist = Physics.Raycast(transform.position, transform.TransformVector(v), out hit) ? hit.distance - bias : defaultDistance;
            outVerts[i] = v * dist;

        }
        mesh.vertices = outVerts;
        mesh.UploadMeshData(false);
        
    }
    
    public bool dirty;
	// Update is called once per frame
	void Update () {
        if (dirty)
            Fit();
	}
}
