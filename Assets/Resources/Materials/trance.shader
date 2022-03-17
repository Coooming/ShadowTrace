// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0.2075472,fgcg:0.2075472,fgcb:0.2075472,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:33634,y:32602,varname:node_4795,prsc:2|emission-7089-OUT,custl-7669-OUT;n:type:ShaderForge.SFN_Tex2d,id:8543,x:32266,y:32705,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_8543,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-1108-OUT;n:type:ShaderForge.SFN_Tex2d,id:4294,x:32314,y:32916,ptovrint:False,ptlb:noise,ptin:_noise,varname:node_4294,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:dae30d1c7ebd5d34384c17577ed93b42,ntxv:2,isnm:False|UVIN-1108-OUT;n:type:ShaderForge.SFN_Time,id:8722,x:31367,y:32934,varname:node_8722,prsc:2;n:type:ShaderForge.SFN_TexCoord,id:1721,x:31367,y:32786,varname:node_1721,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Slider,id:9022,x:31210,y:33082,ptovrint:False,ptlb:uSpped,ptin:_uSpped,varname:node_9022,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-5,cur:1.992787,max:5;n:type:ShaderForge.SFN_Multiply,id:4052,x:31549,y:32934,varname:node_4052,prsc:2|A-8722-T,B-9022-OUT;n:type:ShaderForge.SFN_Add,id:1304,x:31768,y:32866,varname:node_1304,prsc:2|A-1721-U,B-4052-OUT;n:type:ShaderForge.SFN_Time,id:9470,x:31366,y:33314,varname:node_9470,prsc:2;n:type:ShaderForge.SFN_TexCoord,id:5000,x:31366,y:33166,varname:node_5000,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Slider,id:5242,x:31209,y:33462,ptovrint:False,ptlb:vSpped,ptin:_vSpped,varname:_node_9022_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-5,cur:0.8428318,max:5;n:type:ShaderForge.SFN_Multiply,id:1999,x:31548,y:33314,varname:node_1999,prsc:2|A-9470-T,B-5242-OUT;n:type:ShaderForge.SFN_Add,id:1759,x:31767,y:33246,varname:node_1759,prsc:2|A-5000-V,B-1999-OUT;n:type:ShaderForge.SFN_Append,id:1108,x:31989,y:33069,varname:node_1108,prsc:2|A-1304-OUT,B-1759-OUT;n:type:ShaderForge.SFN_Multiply,id:8482,x:32768,y:32827,varname:node_8482,prsc:2|A-8543-RGB,B-4294-G;n:type:ShaderForge.SFN_Color,id:6319,x:32382,y:32556,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_6319,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Step,id:5342,x:33059,y:32849,varname:node_5342,prsc:2|A-8482-OUT,B-6956-OUT;n:type:ShaderForge.SFN_Slider,id:6956,x:32539,y:33039,ptovrint:False,ptlb:StepMin,ptin:_StepMin,varname:node_6956,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.4690207,max:1;n:type:ShaderForge.SFN_Multiply,id:7089,x:33401,y:32641,varname:node_7089,prsc:2|A-6319-RGB,B-1249-OUT;n:type:ShaderForge.SFN_Smoothstep,id:1249,x:33281,y:32937,varname:node_1249,prsc:2|A-5342-OUT,B-8543-RGB,V-215-OUT;n:type:ShaderForge.SFN_Slider,id:215,x:32867,y:33166,ptovrint:False,ptlb:Step,ptin:_Step,varname:node_215,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.8455991,max:1;n:type:ShaderForge.SFN_Slider,id:4518,x:33150,y:33171,ptovrint:False,ptlb:Light,ptin:_Light,varname:node_4518,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.7980028,max:1;n:type:ShaderForge.SFN_Multiply,id:7669,x:33493,y:33018,varname:node_7669,prsc:2|A-1249-OUT,B-4518-OUT;proporder:8543-4294-9022-5242-6319-6956-215-4518;pass:END;sub:END;*/

Shader "Shader Forge/trance" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _noise ("noise", 2D) = "black" {}
        _uSpped ("uSpped", Range(-5, 5)) = 1.992787
        _vSpped ("vSpped", Range(-5, 5)) = 0.8428318
        _Color ("Color", Color) = (1,0,0,1)
        _StepMin ("StepMin", Range(0, 1)) = 0.4690207
        _Step ("Step", Range(0, 1)) = 0.8455991
        _Light ("Light", Range(0, 1)) = 0.7980028
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma target 2.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _noise; uniform float4 _noise_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _uSpped)
                UNITY_DEFINE_INSTANCED_PROP( float, _vSpped)
                UNITY_DEFINE_INSTANCED_PROP( float4, _Color)
                UNITY_DEFINE_INSTANCED_PROP( float, _StepMin)
                UNITY_DEFINE_INSTANCED_PROP( float, _Step)
                UNITY_DEFINE_INSTANCED_PROP( float, _Light)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
////// Lighting:
////// Emissive:
                float4 _Color_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Color );
                float4 node_8722 = _Time;
                float _uSpped_var = UNITY_ACCESS_INSTANCED_PROP( Props, _uSpped );
                float4 node_9470 = _Time;
                float _vSpped_var = UNITY_ACCESS_INSTANCED_PROP( Props, _vSpped );
                float2 node_1108 = float2((i.uv0.r+(node_8722.g*_uSpped_var)),(i.uv0.g+(node_9470.g*_vSpped_var)));
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_1108, _MainTex));
                float4 _noise_var = tex2D(_noise,TRANSFORM_TEX(node_1108, _noise));
                float _StepMin_var = UNITY_ACCESS_INSTANCED_PROP( Props, _StepMin );
                float _Step_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Step );
                float3 node_1249 = smoothstep( step((_MainTex_var.rgb*_noise_var.g),_StepMin_var), _MainTex_var.rgb, float3(_Step_var,_Step_var,_Step_var) );
                float3 emissive = (_Color_var.rgb*node_1249);
                float _Light_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Light );
                float3 finalColor = emissive + (node_1249*_Light_var);
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0.2075472,0.2075472,0.2075472,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
