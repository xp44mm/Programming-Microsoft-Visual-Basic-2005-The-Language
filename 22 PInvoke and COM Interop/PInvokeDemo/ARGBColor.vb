Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Explicit)> _
Structure RGBColor
   <FieldOffset(0)> Public Red As Byte
   <FieldOffset(1)> Public Green As Byte
   <FieldOffset(2)> Public Blue As Byte
   <FieldOffset(3)> Public Alpha As Byte
   <FieldOffset(0)> Public Value As Integer
End Structure
