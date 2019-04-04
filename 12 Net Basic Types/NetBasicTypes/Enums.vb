' This Enum defines the data type accepted for a value entered by the end user.
Enum DataEntry As Integer            ' As Integer is optional.
   IntegerNumber
   FloatingNumber
   CharString
   DateTime
End Enum

<Flags()> Enum ValidDataEntry
   None = 0              ' Always define an Enum value equal to 0.
   IntegerNumber = 1
   FloatingNumber = 2
   CharString = 4
   DateTime = 8
End Enum

