Shader "Custom/URPOutline"
{
    Properties
    {
        _OutlineColor ("Outline Color", Color) = (0, 0, 0, 1)
        _OutlineWidth ("Outline Width", Float) = 0.05
        _MainTex ("Base Texture", 2D) = "white" { }
    }
    SubShader
    {
        Tags {"Queue"="Overlay" "RenderType"="Opaque"}
        Pass {
            Name "OUTLINE"
            Tags {"LightMode"="UniversalForward"}

            ZWrite On
            Offset 10, 10 // Make the outline render in front
            ColorMask RGB
            Blend SrcAlpha OneMinusSrcAlpha

            Cull Front // Render back faces to make an outline
            Stencil
            {
                Ref 1
                Comp always
                Pass replace
            }

            SetTexture[_MainTex] {
                combine primary
            }

            // Outline color
            ColorMask RGB
            Blend SrcAlpha OneMinusSrcAlpha
            Color [_OutlineColor]
        }
    }
    Fallback "Unlit/Transparent"
}
