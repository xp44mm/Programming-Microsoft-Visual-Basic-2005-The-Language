Public Class PersonCompanyRelation
   Inherits Relation(Of Person, Company)

   Public Sub New(ByVal person As Person, ByVal company As Company)
      MyBase.New(person, company)
   End Sub
End Class

Public Class PersonCompanyRelationList
   Inherits List(Of PersonCompanyRelation)
End Class
