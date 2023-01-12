Public Class Form1



    Private Sub SaveBtn_Click(sender As Object, e As EventArgs) Handles SaveBtn.Click
        SaveFileDialog1.Filter = "TXT|*.txt"
        SaveFileDialog1.Title = "Save .txt"
        SaveFileDialog1.ShowDialog()
        Dim sciezka As String = SaveFileDialog1.FileName()

        If sciezka <> "" Then
            My.Computer.FileSystem.WriteAllText(sciezka, "", False)
            For Each item As String In ListBox1.Items
                My.Computer.FileSystem.WriteAllText(sciezka, item + Environment.NewLine + Environment.NewLine, True)
            Next
            MsgBox("File saved as " + sciezka)
        Else
            MsgBox("Nothing was saved. Try again.")
        End If

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Dim wycinek As String = My.Computer.Clipboard.GetText()
        Dim OstatniaTabela As String = ListBox1.Items(0).ToString()
        Dim IloscDoUsun As Int16 = 0
        If CheckBoxTime.Checked And OstatniaTabela.Length > 10 Then
            IloscDoUsun = 10
        End If
        If CheckBoxDate.Checked And OstatniaTabela.Length > 12 Then
            IloscDoUsun = 12
        End If
        If CheckBoxDate.Checked And CheckBoxTime.Checked And OstatniaTabela.Length > 22 Then
            IloscDoUsun = 22
        End If
        OstatniaTabela = OstatniaTabela.Remove(0, IloscDoUsun)

        Dim wynik As Int16 = OstatniaTabela = wycinek


        If wynik = 0 Then
            Dim czas As String = ""
            Dim rok As String = ""
            If CheckBoxTime.Checked Then
                czas = DateTime.Now.ToString("  HH:mm:ss")

            End If

            If CheckBoxDate.Checked Then
                rok = DateTime.Now.ToString("  yyyy/MM/dd")
            End If

            Dim okres As String = rok + czas + ": "
            Dim Informacja As String = okres + wycinek
            Informacja = Informacja.Remove(0, 2)


            Dim dane As New List(Of String)
            For Each item As String In ListBox1.Items
                dane.Add(item)
            Next
            dane.Reverse()
            dane.Add(Informacja)
            dane.Reverse()


            ListBox1.DataSource = dane
            ListBox1.Update()



        End If



    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListBox1.Items.Add("---Program started---")
    End Sub

    Private Sub ButtonRestore_Click(sender As Object, e As EventArgs) Handles ButtonRestore.Click
        Clipboard.SetText(ListBox1.SelectedItem.ToString())
        MsgBox("''" + ListBox1.SelectedItem.ToString() + "'' copied to clipboard.")
    End Sub
End Class
