Public Class Form1

   Sub Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
      Dim w As New Widget()
      ' Create a delegate that points to the form instance.
      AddHandler w.NameChanged, AddressOf Widget_NameChanged
      SerializeToFile("c:\widget.dat", w)
   End Sub

   Private Sub Widget_NameChanged(ByVal sender As Object, ByVal e As EventArgs)
      Debug.WriteLine("Name has changed")
   End Sub

   Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
      Dim w As New Widget2()
      ' Create a delegate that points to the form instance.
      AddHandler w.NameChanged, AddressOf Widget_NameChanged
      SerializeToFile("c:\widget.dat", w)
   End Sub

End Class
