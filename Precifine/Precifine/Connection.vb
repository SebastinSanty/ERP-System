Module Connection
    Public connString As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=" & Application.StartupPath & "\Precifine.mdf;Integrated Security=True;User Instance=True"
    Public itemconstring As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=" & Application.StartupPath & "\ItemsDB.mdf;Integrated Security=True;User Instance=True"
    Public entryconstring As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=" & Application.StartupPath & "\Entry.mdf;Integrated Security=True;User Instance=True"
End Module
