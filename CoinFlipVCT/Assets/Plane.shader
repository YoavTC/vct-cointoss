Shader "Custom/Plane" {
   Properties {
       _TransparencyAmount ("Transparency Amount", Range(0,1)) = 0.5
       _MaxDistance ("Max Distance", Float) = 100.0
   }
   
   SubShader {
       Tags { "RenderType" = "Opaque" }
       LOD 200
       
       CGPROGRAM
       #pragma surface surf Standard fullforwardshadows

       // Declare input structure with world position
       struct Input {
           float2 uv_MainTex;
           float3 worldPos;
       };

       half _TransparencyAmount;
       float _MaxDistance;
       
       void surf (Input IN, inout SurfaceOutputStandard o) {
           // Calculate distance from camera
           float dist = length(_WorldSpaceCameraPos - IN.worldPos);
           
           // Calculate transparency based on distance
           half transparency = 1.0 - saturate(dist / _MaxDistance);
           transparency *= _TransparencyAmount;
           
           // Set transparency
           o.Alpha = transparency;
       }
       ENDCG
   }
}
