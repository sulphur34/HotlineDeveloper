Shader "Custom/InstancedColorShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }

    SubShader
    {
        Tags
        {
            "RenderType"="Opaque"
        }
        LOD 200

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing // Enables instancing

            #include "UnityCG.cginc" // Ensure the necessary Unity macros are included

            // Declare the main texture and instanced color property
            sampler2D _MainTex;

            // The appdata structure used for passing data to the vertex shader
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            // The v2f structure used for passing data to the fragment shader
            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 pos : SV_POSITION;
                float4 color : COLOR;
            };

            // Declare the instancing buffer
            UNITY_INSTANCING_BUFFER_START(Props)
                UNITY_DEFINE_INSTANCED_PROP(float4, _InstanceColor) // Instanced color
            UNITY_INSTANCING_BUFFER_END(Props)

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex); // Transform vertex to clip space
                o.uv = v.uv;
                o.color = UNITY_ACCESS_INSTANCED_PROP(Props, _InstanceColor); // Access instanced color
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                half4 texColor = tex2D(_MainTex, i.uv); // Sample the texture
                return texColor * i.color; // Apply the instanced color
            }
            ENDCG
        }
    }

    Fallback "Diffuse"
}