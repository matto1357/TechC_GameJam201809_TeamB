Shader "Custom/UnlitColor" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
	}
	SubShader {
		Tags { "Queue" = "Transparent"
			   "RenderType" = "Transparent" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Lambert alpha

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		fixed4 _Color;

		//void vert(inout appdata_full v, out Input o)
		//{
		//	UNITY_INITIALIZE_OUTPUT(Input, o);
		//	//float amp = 0.5*sin(_Time * 100 + v.vertex.x * 100);
		//	//v.vertex.xyz = float3(v.vertex.x + amp, v.vertex.y, v.vertex.z);

		///*	float amp = (sin(_Time * _Speed + v.texcoord.y + _Offset) * _Power * (v.texcoord.y * v.texcoord.y));
		//	v.vertex.xyz = float3(v.vertex.x + amp, v.vertex.y, v.vertex.z);
		//*/}

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_CBUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_CBUFFER_END

		void surf (Input IN, inout SurfaceOutput o) {
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Emission = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
