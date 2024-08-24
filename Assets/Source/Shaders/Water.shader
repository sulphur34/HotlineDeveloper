Shader "Custom/WaterSurfaceShader"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _WaveSpeed ("Wave Speed", Range(0,1)) = 0.5
        _WaveHeight ("Wave Height", Range(0,1)) = 0.1
        _WaterColor ("Water Color", Color) = (0, 0.5, 1, 1)
        _SpecColor ("Specular Color", Color) = (1, 1, 1, 1)
        _Shininess ("Shininess", Range(0, 1)) = 0.5
    }
    SubShader
    {
        Tags
        {
            "RenderType"="Transparent" "Queue"="Transparent"
        }
        LOD 200

        CGPROGRAM
        #pragma surface surf Lambert

        sampler2D _MainTex;
        half _WaveSpeed;
        half _WaveHeight;
        fixed4 _WaterColor;
        half _Shininess;

        struct Input
        {
            float2 uv_MainTex;
            float3 worldPos;
            float3 viewDir;
        };

        void surf(Input IN, inout SurfaceOutput o)
        {
            // Sample the base texture
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _WaterColor;

            // Add wave effect
            float wave = sin((IN.worldPos.x + _Time.y * _WaveSpeed) * 2.0) * _WaveHeight;
            o.Albedo = c.rgb;
            o.Alpha = c.a;

            // Specular lighting
            float3 viewDir = normalize(IN.viewDir);
            float3 normal = float3(0.0, 1.0, wave);
            float3 reflectDir = reflect(-viewDir, normal);
            float spec = pow(max(dot(viewDir, reflectDir), 0.0), _Shininess);
            o.Emission = _SpecColor.rgb * spec;
        }
        ENDCG
    }
    FallBack "Diffuse"
}