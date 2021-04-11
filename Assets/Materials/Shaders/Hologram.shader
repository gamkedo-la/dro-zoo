Shader "Custom/Hologram"
{
    Properties
	{
		_Opacity("Opacity", Float) = 1
		_Emission("Emission", Float) = 2
		_bias("bias", Float) = 1
		_scale("scale", Float) = 1
		_power("power", Float) = 1
		_TextureSample0("Texture Sample 0", 2D) = "white" {}
		_pannerspeed("panner speed", Range( 0 , 0.01)) = 0.0009
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Standard alpha:fade keepalpha noshadow 
		struct Input
		{
			float3 worldPos;
			float3 worldNormal;
			float4 vertexColor : COLOR;
			float4 screenPos;
		};

		uniform float _bias;
		uniform float _scale;
		uniform float _power;
		uniform float _Emission;
		uniform float _Opacity;
		uniform sampler2D _TextureSample0;
		uniform float _pannerspeed;
		float4 _TextureSample0_TexelSize;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float3 ase_worldPos = i.worldPos;
			float3 ase_worldViewDir = normalize( UnityWorldSpaceViewDir( ase_worldPos ) );
			float3 ase_worldNormal = i.worldNormal;
			float fresnelNdotV3 = dot( ase_worldNormal, ase_worldViewDir );
			float fresnelNode3 = ( _bias + _scale * pow( 1.0 - fresnelNdotV3, _power ) );
			float2 temp_cast_0 = (_pannerspeed).xx;
			float4 ase_screenPos = float4( i.screenPos.xyz , i.screenPos.w + 0.00000000001 );
			float4 ase_screenPosNorm = ase_screenPos / ase_screenPos.w;
			ase_screenPosNorm.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm.z : ase_screenPosNorm.z * 0.5 + 0.5;
			float2 panner39 = ( 1.0 * _Time.y * temp_cast_0 + (( ase_screenPosNorm * _ScreenParams * _TextureSample0_TexelSize )).xy);
			float4 temp_output_10_0 = ( _Opacity * tex2D( _TextureSample0, panner39 ) );
			o.Emission = ( fresnelNode3 * i.vertexColor * _Emission * temp_output_10_0 ).rgb;
			o.Alpha = temp_output_10_0.r;
		}

		ENDCG
	}
}
