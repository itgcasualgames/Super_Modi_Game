Shader "Custom/rainbow"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Speed ("Speed", Range(0, 10)) = 1
    }
    
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        
        CGPROGRAM
        #pragma surface surf Lambert
        
        sampler2D _MainTex;
        float _Speed;
        
        struct Input
        {
            float2 uv_MainTex;
        };
        
        void surf(Input IN, inout SurfaceOutput o)
        {
            // Calculate rainbow color based on UV and time
            float3 rainbowColor = float3(sin(IN.uv_MainTex.x * 10 + _Time.y * _Speed),
                                         sin(IN.uv_MainTex.x * 10 + _Time.y * _Speed + 2),
                                         sin(IN.uv_MainTex.x * 10 + _Time.y * _Speed + 4));
            
            o.Albedo = rainbowColor;
            o.Alpha = 1.0;
        }
        ENDCG
    }
    
    FallBack "Diffuse"
}
