Shader "Custom/AnimatedPerlinNoiseHLSL"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Speed ("Animation Speed", Float) = 1.0
        _Scale ("Noise Scale", Float) = 1.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _Speed;
            float _Scale;

            static const int perm[512] = {
                151,160,137,91,90,15, // Permutation array...
                131,13,201,95,96,53,194,233,7,225,140,36,103,30,69,142,
                8,99,37,240,21,10,23, // and repeated for lookup speed
                190, 6,148,247,120,234,75,0,26,197,62,94,252,219,203,117,35,11,32,57,177,33,
                88,237,149,56,87,174,20,125,136,171,168, // ...
                68,175,74,165,71,134,139,48,27,166,
                77,146,158,231,83,111,229,122,60,211,133,230,220,105,92,41,55,46,245,40,244,102,
                143,54,65,25,63,161,1,216,80,73,209,76,132,187,208,89,18,169,200,196,135,130,
                116,188,159,86,164,100,109,198,173,186, // ...
                3,64,52,217,226,250,124,123,5,202,38,147,118,126,255,82,85,212,207,206,59,227,47,
                16,58,17,182,189,28,42,223,183,170,213,119,248,152,2,44,154,163,70,221,153,101,
                155,167,43,172,9,129,22,39,253,19,98,108,110,79,113,224,232,178,185,112,104,
                218,246,97,228,251,34,242,193,238,210,144,12,191,179,162,241,81,51,145,235,249,
                14,239,107,49,192,214,31,181,199,106,157,184,84,204,176,115,121,50,45,127,4,150,
                254,138,236,205,93,222,114,67,29,24,72,243,141,128,195,78,66,215,61,156,180,
                151,160,137,91,90,15, // Permutation array...
                131,13,201,95,96,53,194,233,7,225,140,36,103,30,69,142,
                8,99,37,240,21,10,23, // and repeated for lookup speed
                190, 6,148,247,120,234,75,0,26,197,62,94,252,219,203,117,35,11,32,57,177,33,
                88,237,149,56,87,174,20,125,136,171,168, // ...
                68,175,74,165,71,134,139,48,27,166,
                77,146,158,231,83,111,229,122,60,211,133,230,220,105,92,41,55,46,245,40,244,102,
                143,54,65,25,63,161,1,216,80,73,209,76,132,187,208,89,18,169,200,196,135,130,
                116,188,159,86,164,100,109,198,173,186, // ...
                3,64,52,217,226,250,124,123,5,202,38,147,118,126,255,82,85,212,207,206,59,227,47,
                16,58,17,182,189,28,42,223,183,170,213,119,248,152,2,44,154,163,70,221,153,101,
                155,167,43,172,9,129,22,39,253,19,98,108,110,79,113,224,232,178,185,112,104,
                218,246,97,228,251,34,242,193,238,210,144,12,191,179,162,241,81,51,145,235,249,
                14,239,107,49,192,214,31,181,199,106,157,184,84,204,176,115,121,50,45,127,4,150,
                254,138,236,205,93,222,114,67,29,24,72,243,141,128,195,78,66,215,61,156,180
            };

            float fade(float t)
            {
                return t * t * t * (t * (t * 6 - 15) + 10);
            }

            float lerp(float a, float b, float t)
            {
                return a + t * (b - a);
            }

            float grad(int hash, float x, float y, float z)
            {
                int h = hash & 15;
                float u = h < 8 ? x : y;
                float v = h < 4 ? y : (h == 12 || h == 14 ? x : z);
                return ((h & 1) == 0 ? u : -u) + ((h & 2) == 0 ? v : -v);
            }

            float noise(float3 p)
            {
                int X = (int)floor(p.x) & 255;
                int Y = (int)floor(p.y) & 255;
                int Z = (int)floor(p.z) & 255;

                p.x -= floor(p.x);
                p.y -= floor(p.y);
                p.z -= floor(p.z);

                float u = fade(p.x);
                float v = fade(p.y);
                float w = fade(p.z);

                int A = perm[X] + Y;
                int AA = perm[A] + Z;
                int AB = perm[A + 1] + Z;
                int B = perm[X + 1] + Y;
                int BA = perm[B] + Z;
                int BB = perm[B + 1] + Z;

                return lerp(w, lerp(v, lerp(u, grad(perm[AA], p.x, p.y, p.z), grad(perm[BA], p.x - 1, p.y, p.z)), 
                                    lerp(u, grad(perm[AB], p.x, p.y - 1, p.z), grad(perm[BB], p.x - 1, p.y - 1, p.z))),
                           lerp(v, lerp(u, grad(perm[AA + 1], p.x, p.y, p.z - 1), grad(perm[BA + 1], p.x - 1, p.y, p.z - 1)),
                                    lerp(u, grad(perm[AB + 1], p.x, p.y - 1, p.z - 1), grad(perm[BB + 1], p.x - 1, p.y - 1, p.z - 1))));
            }

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                float time = _Time.y * _Speed;
                float3 pos = float3(i.uv * _Scale, time);
                float n = noise(pos);
                return half4(n, n, n, 1.0);
            }
            ENDHLSL
        }
    }
}