Shader "Custom/VertexAlphaSmEmMet"
{
    Properties
	{
		_Emissionpower("Emission power", Float) = 1
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float4 vertexColor : COLOR;
		};

		uniform float _Emissionpower;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float4 temp_output_1_0 = i.vertexColor;
			o.Albedo = temp_output_1_0.rgb;
			float vertexalpha28 = i.vertexColor.a;
			float4 temp_cast_1 = (0.0).xxxx;
			float4 Vertexbaseemission12 = ( i.vertexColor.a >= 0.67 ? ( i.vertexColor * ( 3.0 * ( vertexalpha28 - 0.67 ) ) * _Emissionpower ) : temp_cast_1 );
			o.Emission = Vertexbaseemission12.rgb;
			float temp_output_9_0 = ( vertexalpha28 >= 0.335 ? 0.0 : 1.0 );
			float metalness20 = ( 1.0 * temp_output_9_0 );
			o.Metallic = metalness20;
			float Vertexbasedsmooth11 = ( temp_output_9_0 == 1.0 ? ( 3.0 * vertexalpha28 ) : ( 3.0 * ( vertexalpha28 - 0.335 ) ) );
			o.Smoothness = Vertexbasedsmooth11;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
}
