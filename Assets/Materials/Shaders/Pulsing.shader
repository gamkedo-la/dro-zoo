Shader "Custom/Pulsing"
{
    Properties
	{
		_Vertexoffsetperaxis("Vertex offset per axis", Vector) = (0.01,0.01,0.01,0)
		_Emission("Emission", Float) = 2
		_Emissioncolour("Emission colour", Color) = (0.136644,0.2894089,0.9245283,0)
		_Smoothness("Smoothness", Float) = 0.95
		_Extrusionamount("Extrusion amount", Float) = 0
		_minimumvertexoffset("minimum vertex offset", Float) = 0
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows vertex:vertexDataFunc 
		struct Input
		{
			float4 vertexColor : COLOR;
			float3 worldPos;
		};

		uniform float3 _Vertexoffsetperaxis;
		uniform float _Extrusionamount;
		uniform float _minimumvertexoffset;
		uniform float _Emission;
		uniform float4 _Emissioncolour;
		uniform float _Smoothness;

		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float3 ase_vertexNormal = v.normal.xyz;
			float3 ase_vertex3Pos = v.vertex.xyz;
			v.vertex.xyz += ( v.color.a * ( _Vertexoffsetperaxis * ase_vertexNormal ) * ase_vertex3Pos.y * _Extrusionamount * max( _SinTime.z , _minimumvertexoffset ) );
			v.vertex.w = 1;
		}

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			o.Albedo = i.vertexColor.rgb;
			float3 ase_vertex3Pos = mul( unity_WorldToObject, float4( i.worldPos , 1 ) );
			o.Emission = ( max( _SinTime.z , 0.5 ) * _Emission * _Emissioncolour * i.vertexColor.r * ( ase_vertex3Pos.y + 0.2 ) ).rgb;
			o.Smoothness = _Smoothness;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
}
