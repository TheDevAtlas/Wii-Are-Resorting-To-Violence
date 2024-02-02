Shader "Custom/WaterShader"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _WaveSpeed("Wave Speed", Float) = 1.0
        _WaveHeight("Wave Height", Float) = 0.5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        // Vertex movement
        #pragma vertex vert
        #include "UnityCG.cginc"

        struct Input
        {
            float2 uv_MainTex;
        };

        sampler2D _MainTex;
        float _WaveSpeed;
        float _WaveHeight;

        void vert(inout appdata_full v)
        {
            float wave = sin(_Time.y * _WaveSpeed + v.vertex.x + v.vertex.z) * _WaveHeight;
            v.vertex.y += wave;
        }

        void surf(Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
