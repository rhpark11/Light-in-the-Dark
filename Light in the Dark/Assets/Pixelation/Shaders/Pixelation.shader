Shader "custom/Pixelation"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
        BlockCount("block",Range(0,1000))= 5.
        BlockSize("blokc",Range(0,1000))=5.
	}
	SubShader
	{
		Pass
		{
            Cull Off ZWrite Off ZTest Always
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			sampler2D _MainTex;	
			float2 BlockCount;
			float2 BlockSize;

			fixed4 frag (v2f_img i) : SV_Target
			{
				float2 blockPos = floor(i.uv * BlockCount);
				float2 blockCenter = blockPos * BlockSize + BlockSize * 0.5;

				float3 tex = tex2D(_MainTex, i.uv);
				return float4(tex,1);
			}
			ENDCG
		}
	}
}
