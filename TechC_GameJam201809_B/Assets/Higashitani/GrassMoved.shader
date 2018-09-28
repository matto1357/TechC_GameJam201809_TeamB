Shader "Custom/GrassMoved" {
	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0
		_Power("Power", Float) = 10.0
		_Speed("Speed", Float) = 3.0
        _Offset("Offset", Float) = 0
	}
		SubShader{
			Tags{ "Queue" = "Transparent"
                  "RenderType" = "Transparent" }
			LOD 200

			CGPROGRAM
#pragma surface surf Lambert alpha vertex:vert
#pragma target 3.0

		fixed4 _Color;
		sampler2D _MainTex;
		float _Speed;
		float _Power;
        float _Offset;

		struct Input {
			float2 uv_MainTex;
		};

		void vert(inout appdata_full v, out Input o)
		{
			UNITY_INITIALIZE_OUTPUT(Input, o);
			//float amp = 0.5*sin(_Time * 100 + v.vertex.x * 100);
			//v.vertex.xyz = float3(v.vertex.x + amp, v.vertex.y, v.vertex.z);

			float amp = (sin(_Time * _Speed + v.texcoord.y + _Offset) * _Power * (v.texcoord.y * v.texcoord.y));
			v.vertex.xyz = float3(v.vertex.x + amp, v.vertex.y, v.vertex.z);
		}

		void surf(Input IN, inout SurfaceOutput o) {
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
			o.Emission = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
		}
	FallBack "Diffuse"
}