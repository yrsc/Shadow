using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Projector))]
public class ShadowCameraGenerator : MonoBehaviour 
{
	public LayerMask shadowCasterLayer;
	private RenderTexture _renderTex;

	void Awake()
	{
		Projector projector = GetComponent<Projector>();
		Camera camera = gameObject.AddComponent<Camera>();
		camera.cullingMask = shadowCasterLayer;
		camera.orthographic = true;
		camera.orthographicSize = projector.orthographicSize;
		camera.clearFlags = CameraClearFlags.SolidColor;
		camera.backgroundColor = new Color(1.0f,1.0f,1.0f,0.0f);
		_renderTex = new RenderTexture(1024,1024,0,RenderTextureFormat.ARGB32);
		camera.targetTexture = _renderTex;
		camera.SetReplacementShader(Shader.Find("Unlit/ReplaceShadowRender"),null);
		projector.material.SetTexture("_ShadowTex",_renderTex);
	}

	//ignore black quad occur when editor stop play
	#if UNITY_EDITOR
	void OnApplicationQuit()
	{	
		Projector projector = GetComponent<Projector>();	
		projector.material.SetTexture("_ShadowTex",null);
	}
	#endif
}
