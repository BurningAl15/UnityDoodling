Shader "Holistic/MyFirstShader" {
	Properties {
		_myColour("Colour Sample", Color) = (1,1,1,1)
		_myEmission("Emission Sample", Color) = (1,1,1,1)
		_myNormal("Normal Sample",Color)=(1,0,0,1)
	}
	SubShader {

		CGPROGRAM
			#pragma surface surf Lambert
			
			struct Input {
				float2 uvMainTex;
			};
			//If we want to see the variables up here (_myColour ("colour....
			//We need to declare it here
			fixed4 _myColour;
			fixed4 _myEmission;
			fixed4 _myNormal;
			void surf(Input IN, inout SurfaceOutput o) {
				o.Albedo = _myColour.rgb;
				o.Emission = _myEmission.rgb;
				o.Normal = _myNormal.rgb;
			}

		ENDCG
	}
	FallBack "Diffuse" 
}
