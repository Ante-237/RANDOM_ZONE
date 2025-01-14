Shader "Graph/Pointer Surface GPU"
{
    Properties
    {
        _Smoothness ("Smoothness", Range(0,1)) = 0.5
    }
    SubShader
    {
        // Tags { "RenderType"="Opaque" }
        // LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows addshadow
        #pragma instancing_options assumeuniformscaling procedural:ConfigureProcedural
        #pragma editor_sync_compilation
        #pragma target 4.5

        #include "PointGPU.hlsl"
 
      
        struct Input{
            float worldPos;
            };

         float _Smoothness;

        void surf (Input input, inout SurfaceOutputStandard surface)
        {
            surface.Albedo = saturate(input.worldPos * 0.5 + 0.5);
			surface.Smoothness = _Smoothness;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
