Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Explicit)> _
Structure IntegerTypes
   ' A 64-bit integer
   <FieldOffset(0)> Public Long0 As Long
   ' Two 32-bit integers
   <FieldOffset(0)> Public Integer0 As Integer
   <FieldOffset(4)> Public Integer1 As Integer
   ' Four 16-bit integers
   <FieldOffset(0)> Public Short0 As Short
   <FieldOffset(2)> Public Short1 As Short
   <FieldOffset(4)> Public Short2 As Short
   <FieldOffset(6)> Public Short3 As Short
   ' Eight 8-bit integers
   <FieldOffset(0)> Public Byte0 As Byte
   <FieldOffset(1)> Public Byte1 As Byte
   <FieldOffset(2)> Public Byte2 As Byte
   <FieldOffset(3)> Public Byte3 As Byte
   <FieldOffset(4)> Public Byte4 As Byte
   <FieldOffset(5)> Public Byte5 As Byte
   <FieldOffset(6)> Public Byte6 As Byte
   <FieldOffset(7)> Public Byte7 As Byte
End Structure
