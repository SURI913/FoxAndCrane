Shader "URP/SimpleWater"
{
    Properties
    {
        _WaterNormal("Water Normal", 2D) = "bump" {}
        _NormalScale("Normal Scale", Float) = 0
        _DeepColor("Deep Color", Color) = (0,0,0,0)
        _ShalowColor("Shalow Color", Color) = (1,1,1,0)
        _WaterDepth("Water Depth", Float) = 0
        _WaterFalloff("Water Falloff", Float) = 0
        _Distortion("Distortion", Float) = 0.5
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue"="Transparent+0" }
        LOD 200

        Pass
        {
            Name "ForwardLit"
            Tags { "LightMode"="UniversalForward" }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float3 positionOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
                float4 screenPos : TEXCOORD1;
            };

            // Declare textures
            TEXTURE2D(_CameraOpaqueTexture);
            SAMPLER(sampler_CameraOpaqueTexture);

            TEXTURE2D(_WaterNormal);
            SAMPLER(sampler_WaterNormal);

            float4 _DeepColor;
            float4 _ShalowColor;
            float _WaterDepth;
            float _WaterFalloff;
            float _Distortion;

            Varyings vert(Attributes v)
            {
                Varyings o;
                o.positionHCS = TransformObjectToHClip(v.positionOS);
                o.uv = v.uv;
                o.screenPos = TransformObjectToHClip(v.positionOS);
                return o;
            }

            half4 frag(Varyings i) : SV_Target
            {
                float2 uv_WaterNormal = i.uv;
                float2 distortionUV = uv_WaterNormal + SAMPLE_TEXTURE2D(_WaterNormal, sampler_WaterNormal, uv_WaterNormal).rg * _Distortion;

                // Fetch screen texture for refraction
                float4 screenColor = SAMPLE_TEXTURE2D(_CameraOpaqueTexture, sampler_CameraOpaqueTexture, distortionUV);

                // Blend shallow and deep colors based on depth
                float depthFactor = saturate(_WaterDepth * _WaterFalloff);
                float4 waterColor = lerp(_DeepColor, _ShalowColor, depthFactor);

                return lerp(waterColor, screenColor, depthFactor);
            }
            ENDHLSL
        }
    }

    Fallback "Diffuse"
}
