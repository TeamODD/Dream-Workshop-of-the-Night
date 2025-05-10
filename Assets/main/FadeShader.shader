Shader "UI/FadeShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _Fade ("Fade", Range(0, 1)) = 0
    }
    SubShader
    {
        Tags { "Queue" = "Overlay" }
        Pass
        {
            ZWrite Off
            Cull Off
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            fixed4 _Color;
            float _Fade;

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

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 center = float2(0.5, 0.5);
                
                float aspect = _ScreenParams.x / _ScreenParams.y;
                float2 uv = i.uv;
                uv.x = (uv.x - 0.5) * aspect + 0.5;

                float dist = distance(uv, center);
                float alpha = smoothstep(_Fade, _Fade + 0.2, dist);
                return fixed4(_Color.rgb, alpha);
            }
            ENDCG
        }
    }
}
