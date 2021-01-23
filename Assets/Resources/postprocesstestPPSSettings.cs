// Amplify Shader Editor - Visual Shader Editing Tool
// Copyright (c) Amplify Creations, Lda <info@amplify.pt>
#if UNITY_POST_PROCESSING_STACK_V2
using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess( typeof( postprocesstestPPSRenderer ), PostProcessEvent.AfterStack, "postprocesstest", true )]
public sealed class postprocesstestPPSSettings : PostProcessEffectSettings
{
	[Tooltip( "Texture Sample 1" )]
	public TextureParameter _TextureSample1 = new TextureParameter {  };
	[Tooltip( "Vector 1" )]
	public Vector4Parameter _Vector1 = new Vector4Parameter { value = new Vector4(0f,0.02f,0f,0f) };
}

public sealed class postprocesstestPPSRenderer : PostProcessEffectRenderer<postprocesstestPPSSettings>
{
	public override void Render( PostProcessRenderContext context )
	{
		var sheet = context.propertySheets.Get( Shader.Find( "postprocesstest" ) );
		if(settings._TextureSample1.value != null) sheet.properties.SetTexture( "_TextureSample1", settings._TextureSample1 );
		sheet.properties.SetVector( "_Vector1", settings._Vector1 );
		context.command.BlitFullscreenTriangle( context.source, context.destination, sheet, 0 );
	}
}
#endif
